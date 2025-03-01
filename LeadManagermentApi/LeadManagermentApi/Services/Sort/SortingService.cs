using LeadManagermentApi.DTOs;
using System.Linq.Expressions;

namespace LeadManagermentApi.Services.Sort;

/// <summary>
/// Sorting service for the Lead type.
/// </summary>
/// <param name="sortFieldProvider">Provides sort field services.</param>
public class SortingService<TEntity>() : ISortingService<TEntity>
{
    /// <summary>
    /// Applies sorting options to Leads
    /// </summary>
    /// <param name="query">The query to retrieve lead data.</param>
    /// <param name="sortOptions">The sorting options.</param>
    /// <returns>The query with the applied sorting options.</returns>
    public IOrderedQueryable<TEntity> Sort(IQueryable<TEntity> query, SortOptions sortOptions)
    {
        if (null == sortOptions.Fields)
        {
            throw new Exception("Expected sortOptions to contain fields.");
        }

        using var enumerator = sortOptions.Fields.GetEnumerator();

        if (!enumerator.MoveNext())
        {
            throw new Exception("Expected sort options to contain fields.");
        }

        var newQuery = AddFieldSort(query, enumerator.Current);

        while (enumerator.MoveNext())
        {
            newQuery = AddFieldSort(newQuery, enumerator.Current);
        }

        return newQuery;
    }

    private IOrderedQueryable<TEntity> AddFieldSort(IQueryable<TEntity> query, KeyValuePair<string, SortDirection> field)
    {
        var parameterExp = Expression.Parameter(typeof(TEntity), "e");
        var memberExp = Expression.Property(parameterExp, field.Key);
        var lambdaExp = Expression.Lambda<Func<TEntity, object>>(memberExp, parameterExp);

        return field.Value == SortDirection.Ascending
                   ? query.OrderBy(lambdaExp)
                   : query.OrderByDescending(lambdaExp);
    }
}