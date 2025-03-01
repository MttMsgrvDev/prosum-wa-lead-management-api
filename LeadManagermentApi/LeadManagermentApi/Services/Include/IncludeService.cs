using Microsoft.EntityFrameworkCore;

using LeadManagermentApi.DTOs;

namespace LeadManagermentApi.Services.Include;

/// <summary>
/// Provides services for including child properties of an entity record.
/// </summary>
/// <typeparam name="TEntity">The type of entity to inlcude child properties for.</typeparam>
public class IncludeService<TEntity> : IIncludeService<TEntity>
    where TEntity : class
{
    /// <summary>
    /// Applies the include options to the query.
    /// </summary>
    /// <param name="query">The query to be executed.</param>
    /// <param name="includeOptions">Describes the includes to be applied.</param>
    /// <returns>The query with the child properties included.</returns>
    public IQueryable<TEntity> IncludeChildren(IQueryable<TEntity> query, IncludeOptions includeOptions)
    {
        if (null == includeOptions)
        {
            throw new ArgumentNullException(nameof(includeOptions));
        }

        if (null == includeOptions.PropertyIncludes)
        {
            throw new Exception("Expected include options to contain fields to include.");
        }

        foreach (var field in includeOptions.PropertyIncludes)
        {
            query = query.Include(field);
        }

        return query;
    }
}
