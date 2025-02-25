using LeadManagermentApi.DTOs;

namespace LeadManagermentApi.Services.Filtering;

/// <summary>
/// Provides filtering services for entities of type TEntity.
/// </summary>
public interface IFilteringService<TEntity>
{

    /// <summary>
    /// Applies the filters to the query.
    /// </summary>
    /// <param name="query">The query to be executed.</param>
    /// <param name="filters">GThe filters to apply to the query.</param>
    /// <returns>The query with the applied filters.</returns>
    IQueryable<TEntity> Filter(IQueryable<TEntity> query, FilterOptions filters);

}