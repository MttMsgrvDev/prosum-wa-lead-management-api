using LeadManagermentApi.DTOs;

namespace LeadManagermentApi.Services.Sort;

/// <summary>
/// Proivdes sorting services for entity of type TEntity.
/// </summary>
/// <typeparam name="TEntity">The type of entity to provide sorting services for.</typeparam>
public interface ISortingService<TEntity>
{

    /// <summary>
    /// Applies the sorting options to the query.
    /// </summary>
    /// <param name="query">The query to sort.</param>
    /// <param name="sortOptions">The sorting options to use.</param>
    /// <returns>An ordered query.</returns>
    IOrderedQueryable<TEntity> Sort(IQueryable<TEntity> query, SortOptions sortOptions);

}