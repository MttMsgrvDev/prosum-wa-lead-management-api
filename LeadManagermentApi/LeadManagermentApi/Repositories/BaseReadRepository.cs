using LeadManagermentApi.Data.Context;
using LeadManagermentApi.Data.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LeadManagermentApi.Repositories;

/// <summary>
/// A base read repsitory implementation.
/// </summary>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
/// <param name="dbContextFactory">Factory for creating database contexts.</param>
public class BaseReadRepository<TEntity>(IDbContextFactory<LeadContext> dbContextFactory) : IReadRepository<TEntity>
    where TEntity : class, IEntity
{

    /// <summary>
    /// Retrieves the record that is identified by the given id.
    /// </summary>
    /// <param name="id">UNiquely identifies trhe record to be fetched.</param>
    /// <param name="cancellationToken">Allows for cancellation.</param>
    /// <returns>A task to retrieve the entity identified by the given id.</returns>
    public async Task<TEntity?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        using var context = await dbContextFactory.CreateDbContextAsync(cancellationToken);

        var result = await context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        return result;

    }

    /// <summary>
    /// Asynchronously retrieves a collection of entity records based on a filtering expression.
    /// </summary>
    /// <param name="predicate">An expression used to filter entity records.</param>
    /// <param name="cancellationToken">Allows for cancellation.</param>
    /// <returns>A task to retrieve a collection of entity records using the given filtyer.</returns>
    public async Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        using var context = await dbContextFactory.CreateDbContextAsync(cancellationToken);

        var records_generic = context.Set<TEntity>();

        return await records_generic.AsQueryable().Where(predicate).ToListAsync(cancellationToken);

    }
}