using LeadManagermentApi.DTOs;

namespace LeadManagermentApi.Services.Filtering;

/// <summary>
/// Provides filtering services for entities of type TEntity.
/// </summary>
/// <typeparam name="TEntity">The type of entity to provide filtering services for.</typeparam>
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