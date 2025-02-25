using LeadManagermentApi.DTOs;
using Microsoft.EntityFrameworkCore.Query;

namespace LeadManagermentApi.Services.Include;

/// <summary>
/// Provides services for including child properties of an entity record.
/// </summary>
public interface IIncludeService<TEntity>
{

    /// <summary>
    /// Applies the include options to the query.
    /// </summary>
    /// <param name="query">The query to be executed.</param>
    /// <param name="includeOptions">Describes the includes to be applied.</param>
    /// <returns></returns>
    IQueryable<TEntity> Include(IQueryable<TEntity> query, IncludeOptions includeOptions);

}