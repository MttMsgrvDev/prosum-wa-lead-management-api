using LeadManagermentApi.Data.Models.Entity;

namespace LeadManagermentApi.Repositories;

/// <summary>
/// Represents a repository to write TEntity records to.
/// </summary>
/// <typeparam name="TEntity">The type of entity of the repository.</typeparam>
public interface IWriteRepository<TEntity>
    where TEntity : class, IEntity
{

    /// <summary>
    /// Asynchronously creates a new entity record.
    /// </summary>
    /// <param name="entity">The entity to create.</param>
    /// <param name="cancellationToken">Allows for task cancellation.</param>
    /// <returns>A task to create a new entity record.</returns>
    Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously updates the given entity.
    /// </summary>
    /// <param name="entity">The entity to be updated.</param>
    /// <param name="cancellationToken">Allows for task cancellation.</param>
    /// <returns>A task to update the entity.</returns>
    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously deletes the entity record identified by the given id.
    /// </summary>
    /// <param name="entity">The entity record to be deleted.</param>
    /// <param name="cancellationToken">Allows for task cancellation.</param>
    /// <returns>A task to delete the entity.</returns>
    Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);

}