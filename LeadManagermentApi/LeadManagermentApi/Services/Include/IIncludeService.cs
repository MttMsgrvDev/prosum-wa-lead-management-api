using LeadManagermentApi.DTOs;

namespace LeadManagermentApi.Services.Include;

/// <summary>
/// Provides services for including child properties of an entity record.
/// </summary>
/// <typeparam name="TEntity">The type of entity to inlcude child properties for.</typeparam>
public interface IIncludeService<TEntity>
{

    /// <summary>
    /// Applies the include options to the query.
    /// </summary>
    /// <param name="query">The query to be executed.</param>
    /// <param name="includeOptions">Describes the includes to be applied.</param>
    /// <returns>The query with the child properties included.</returns>
    IQueryable<TEntity> IncludeChildren(IQueryable<TEntity> query, IncludeOptions includeOptions);

}