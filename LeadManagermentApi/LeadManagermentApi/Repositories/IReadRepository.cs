using LeadManagermentApi.Models.Entity;
using System.Linq.Expressions;

namespace LeadManagermentApi.Repositories;

/// <summary>
/// Represents a repository to read TEntity records from.
/// </summary>
/// <typeparam name="TEntity">The type of entity of the repository.</typeparam>
public interface IReadRepository<TEntity>
    where TEntity : IEntity
{

    /// <summary>
    /// Asynchronously retrieves an entity by its globally unique identifier.
    /// </summary>
    /// <param name="guid">The globally unique ID of the record to retrieve.</param>
    /// <param name="cancellationToken">Allows for task cancellation.</param>
    /// <returns>A task to retrieve the entity record identified by the given guid.</returns>
    Task<TEntity?> GetAsync(Guid guid, CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously retrieves a collection of entity records based on a filtering expression.
    /// </summary>
    /// <param name="predicate">An expression used to filter entity records.</param>
    /// <returns>A task to retrieve a collection of entity records using the given filtyer.</returns>
    Task<IEnumerable<TEntity>> GetManyAsync(Expression<Predicate<TEntity>> predicate, CancellationToken cancellationToken = default);
}