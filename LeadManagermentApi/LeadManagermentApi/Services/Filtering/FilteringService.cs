using LeadManagermentApi.Data.Models;
using LeadManagermentApi.DTOs;
using System.Linq.Expressions;

namespace LeadManagermentApi.Services.Filtering;

public class FilteringService<TEntity> : IFilteringService<TEntity>
{
    private readonly IDictionary<FieldFilterOperator, Func<Expression, Expression, BinaryExpression>> _binaryExpressions;

    public FilteringService()
    {
        _binaryExpressions = new Dictionary<FieldFilterOperator, Func<Expression, Expression, BinaryExpression>>
        {
            { FieldFilterOperator.Equal, (left, right) => Expression.Equal(left, right) },
            { FieldFilterOperator.GreaterThan, (left, right) => Expression.GreaterThan(left, right) },
            { FieldFilterOperator.GreaterThanOrEqual, (left, right) => Expression.GreaterThanOrEqual(left, right) },
            { FieldFilterOperator.LessThan, (left, right) => Expression.LessThan(left, right) },
            { FieldFilterOperator.LessThanOrEqual, (left, right) => Expression.LessThanOrEqual(left, right) },
        };
    }

    /// <summary>
    /// Applies the filters to the query.
    /// </summary>
    /// <param name="query">The query to be executed.</param>
    /// <param name="filters">GThe filters to apply to the query.</param>
    /// <returns>The query with the applied filters.</returns>
    public IQueryable<TEntity> Filter(IQueryable<TEntity> query, FilterOptions filters)
    {
        if (null == query) {
            throw new ArgumentNullException(nameof(query));
        }

        if (null == filters)
        {
            throw new ArgumentNullException(nameof(filters));
        }

        if (null == filters.Filters)
        {
            throw new ArgumentException("Expected filters to contain field filters.", nameof(filters));
        }

        using var enumerator = filters.Filters.GetEnumerator();

        if (!enumerator.MoveNext())
        {
            throw new Exception("Expected there to be filters.");
        }

        var parameterExp = Expression.Parameter(typeof(TEntity), "e");

        var predicate = GetFilterExpression(enumerator.Current, parameterExp);

        while (enumerator.MoveNext())
        {
            var fieldExpression = GetFilterExpression(enumerator.Current, parameterExp);
            predicate = Expression.AndAlso(predicate, fieldExpression);
        }

        var lambdaExp = Expression.Lambda<Func<TEntity, bool>>(predicate, parameterExp);

        return query.Where(lambdaExp);
    }

    /// <summary>
    /// Returns the expression that should be used for the given field filter.
    /// </summary>
    /// <param name="filter">The field filter.</param>
    /// <returns>The expression used in the where clause to apply the given field filter.</returns>
    /// <exception cref="Exception">If the field filter operator is not supported.</exception>
    private Expression GetFilterExpression(FieldFilter filter, ParameterExpression parameterExp)
    {
        var memberExp = Expression.Property(parameterExp, filter.Field);
        var constantExp = Expression.Constant(filter.Value);

        if (!_binaryExpressions.TryGetValue(filter.Operator, out var expressionBuilder))
        {
            throw new Exception($@"Unsupported filter operator ""{filter.Operator}""");
        }

        return expressionBuilder(memberExp, constantExp);
    }
}