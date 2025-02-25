using LeadManagermentApi.Data.Models.Entity;
using LeadManagermentApi.DTOs;
using System.Linq.Expressions;

namespace LeadManagermentApi.Repositories;

/// <summary>
/// Represents a repository to read TEntity records from.
/// </summary>
/// <typeparam name="TEntity">The type of entity of the repository.</typeparam>
public interface IReadRepository<TEntity>
    where TEntity : class, IEntity
{

    /// <summary>
    /// Asynchronously retrieves an entity by its globally unique identifier.
    /// </summary>
    /// <param name="guid">The globally unique ID of the record to retrieve.</param>\
    /// <param name="includeOptions">The options for including child items.</param>
    /// <param name="cancellationToken">Allows for task cancellation.</param>
    /// <returns>A task to retrieve the entity record identified by the given guid.</returns>
    Task<TEntity?> GetAsync(
        Guid guid,
        IncludeOptions? includeOptions = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously retrieves a collection of entity records based on a filtering expression.
    /// </summary>
    /// <param name="filterOptions">The options used to filter entity records.</param>
    /// <param name="includeOptions">The options for including child items.</param>
    /// <param name="sortOptions">Options for sorting records.</param>
    /// <param name="cancellationToken">Allows for cancellation.</param>
    /// <returns>A task to retrieve a collection of entity records using the given filter.</returns>
    Task<IEnumerable<TEntity>> GetManyAsync(
        FilterOptions? filterOptions = null,
        IncludeOptions? includeOptions = null,
        SortOptions? sortOptions = null,
        CancellationToken cancellationToken = default);
}