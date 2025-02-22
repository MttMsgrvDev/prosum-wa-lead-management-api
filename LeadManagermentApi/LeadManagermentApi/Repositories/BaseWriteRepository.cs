using LeadManagermentApi.Data.Context;
using LeadManagermentApi.Data.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace LeadManagermentApi.Repositories;

/// <summary>
/// A base repository for writing TEntity records to.
/// </summary>
/// <typeparam name="TEntity">The type of entity of the repository.</typeparam>
public class BaseWriteRepository<TEntity>(IDbContextFactory<LeadContext> dbContextFactory) : IWriteRepository<TEntity>
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
        using var context = await dbContextFactory.CreateDbContextAsync(cancellationToken);

        var result = await context.AddAsync<TEntity>(entity, cancellationToken);

        await context.SaveChangesAsync(cancellationToken);

        return result.Entity;

    }

    /// <summary>
    /// Asynchronously deletes the entity record identified by the given id.
    /// </summary>
    /// <param name="id">Identifies the record to be deleted.</param>
    /// <param name="cancellationToken">Allows for task cancellation.</param>
    /// <returns>A task to delete the entity.</returns>
    public async Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        using var context = await dbContextFactory.CreateDbContextAsync(cancellationToken);

        var result = context.Remove(entity);

        await context.SaveChangesAsync(cancellationToken);

        return result.Entity;

    }

    // <summary>
    /// Asynchronously updates the given entity.
    /// </summary>
    /// <param name="entity">The entity to be updated.</param>
    /// <param name="cancellationToken">Allows for task cancellation.</param>
    /// <returns>A task to update the entity.</returns>
    public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        using var context = await dbContextFactory.CreateDbContextAsync(cancellationToken);

        var results = context.Update(entity);

        await context.SaveChangesAsync(cancellationToken);

        return results.Entity;

    }
}