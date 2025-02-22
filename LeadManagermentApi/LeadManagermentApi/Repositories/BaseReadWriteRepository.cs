using LeadManagermentApi.Data.Models.Entity;
using System.Linq.Expressions;

namespace LeadManagermentApi.Repositories;

/// <summary>
/// Basic implementation for a repository that can read and wrtie entity records.
/// </summary>
/// <typeparam name="TEntity"></typeparam>
/// <param name="readRepository">The read repository.</param>
/// <param name="writeRepository">The write respository.</param>
public class BaseReadWriteRepository<TEntity>(IReadRepository<TEntity> readRepository, IWriteRepository<TEntity> writeRepository) : IReadWriteRepository<TEntity>
    where TEntity : class, IEntity
{

    /// <summary>
    /// Asynchronously creates a new entity record.
    /// </summary>
    /// <param name="entity">The entity to create.</param>
    /// <param name="cancellationToken">Allows for task cancellation.</param>
    /// <returns>A task to create a new entity record.</returns>
    public async Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return await writeRepository.CreateAsync(entity, cancellationToken);
    }

    /// <summary>
    /// Asynchronously deletes the entity record identified by the given id.
    /// </summary>
    /// <param name="id">Identifies the record to be deleted.</param>
    /// <param name="cancellationToken">Allows for task cancellation.</param>
    /// <returns>A task to delete the entity.</returns>
    public async Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return await writeRepository.DeleteAsync(entity, cancellationToken);
    }

    /// <summary>
    /// Retrieves the record that is identified by the given id.
    /// </summary>
    /// <param name="id">UNiquely identifies trhe record to be fetched.</param>
    /// <param name="cancellationToken">Allows for cancellation.</param>
    /// <returns>A task to retrieve the entity identified by the given id.</returns>
    public async Task<TEntity?> GetAsync(Guid guid, CancellationToken cancellationToken = default)
    {
        return await readRepository.GetAsync(guid, cancellationToken);
    }

    /// <summary>
    /// Asynchronously retrieves a collection of entity records based on a filtering expression.
    /// </summary>
    /// <param name="predicate">An expression used to filter entity records.</param>
    /// <param name="cancellationToken">Allows for cancellation.</param>
    /// <returns>A task to retrieve a collection of entity records using the given filtyer.</returns>
    public async Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await readRepository.GetManyAsync(predicate, cancellationToken);
    }

    // <summary>
    /// Asynchronously updates the given entity.
    /// </summary>
    /// <param name="entity">The entity to be updated.</param>
    /// <param name="cancellationToken">Allows for task cancellation.</param>
    /// <returns>A task to update the entity.</returns>
    public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return await writeRepository.UpdateAsync(entity, cancellationToken);
    }
}