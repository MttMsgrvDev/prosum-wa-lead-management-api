using LeadManagermentApi.Data.Context;
using LeadManagermentApi.Data.Models.Entity;
using LeadManagermentApi.DTOs;
using LeadManagermentApi.Services.Filtering;
using LeadManagermentApi.Services.Include;
using LeadManagermentApi.Services.Sort;
using Microsoft.EntityFrameworkCore;

namespace LeadManagermentApi.Repositories;

/// <summary>
/// A base read repsitory implementation.
/// </summary>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
/// <param name="dbContextFactory">Factory for creating database contexts.</param>
public class BaseReadRepository<TEntity>(
    IDbContextFactory<LeadContext> dbContextFactory,
    ISortingService<TEntity> sortingService,
    IIncludeService<TEntity> includeService,
    IFilteringService<TEntity> filterService) : IReadRepository<TEntity>
    where TEntity : class, IEntity
{

    /// <summary>
    /// Retrieves the record that is identified by the given id.
    /// </summary>
    /// <param name="id">UNiquely identifies trhe record to be fetched.</param>
    /// <param name="includeOptions">The options for including child items.</param>
    /// <param name="cancellationToken">Allows for cancellation.</param>
    /// <returns>A task to retrieve the entity identified by the given id.</returns>
    public async Task<TEntity?> GetAsync(
        Guid id,
        IncludeOptions? includeOptions = null,
        CancellationToken cancellationToken = default)
    {
        using var context = await dbContextFactory.CreateDbContextAsync(cancellationToken);

        var query = context.Set<TEntity>().AsQueryable();

        query.Include("test");
        
        if (null != includeOptions)
        {
            query = ApplyIncludeOptions(query, includeOptions);
        }

        return await query.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    /// <summary>
    /// Asynchronously retrieves a collection of entity records based on a filtering expression.
    /// </summary>
    /// <param name="filterOptions">The options used to filter entity records.</param>
    /// <param name="includeOptions">The options for including child items.</param>
    /// <param name="sortOptions">Options for sorting records.</param>
    /// <param name="cancellationToken">Allows for cancellation.</param>
    /// <returns>A task to retrieve a collection of entity records using the given filter.</returns>
    public async Task<IEnumerable<TEntity>> GetManyAsync(
        FilterOptions? filterOptions = null,
        IncludeOptions? includeOptions = null,
        SortOptions? sortOptions = null,
        CancellationToken cancellationToken = default)
    {
        using var context = await dbContextFactory.CreateDbContextAsync(cancellationToken);

        var query = context.Set<TEntity>().AsQueryable();

        if (null != includeOptions)
        {
            query = ApplyIncludeOptions(query, includeOptions);
        }

        if (null != sortOptions)
        {
            query = ApplySortOptions(query, sortOptions);
        }

        if (null != filterOptions)
        {
            query = ApplyFilterOptions(query, filterOptions);
        }

        return await query.ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Applies the filtering options to the query.
    /// </summary>
    /// <param name="query">The query to be executed.</param>
    /// <param name="filterOptions">Describes the filters that need to be applied.</param>
    /// <returns>The query to executed with the applied filtering options.</returns>
    private IQueryable<TEntity> ApplyFilterOptions(
        IQueryable<TEntity> query,
        FilterOptions filterOptions)
    {
        if (null == filterService)
        {
            // TODO: figure out what type of exception to throw.
            throw new Exception($"No filter service provided for type {typeof(TEntity).Name}.");
        }

        return filterService.Filter(query, filterOptions);
    }

    /// <summary>
    /// Applies the include options.
    /// </summary>
    /// <param name="query">The query to be executed.</param>
    /// <param name="includeOptions">The include options to be applied.</param>
    /// <returns>The query with the added includes.</returns>
    protected IQueryable<TEntity> ApplyIncludeOptions(
        IQueryable<TEntity> query,
        IncludeOptions includeOptions)
    {
        if (null == includeService)
        {
            // TODO: figure out what type of exception to throw.
            throw new Exception($"No include service provided for type {typeof(TEntity).Name}.");
        }

        return includeService.IncludeChildren(query, includeOptions);
    }

    /// <summary>
    /// Applies sort options to a query.
    /// </summary>
    /// <param name="query">The query to apply the sort options to.</param>
    /// <param name="sortOptions">The sorting options</param>
    protected IOrderedQueryable<TEntity> ApplySortOptions(
        IQueryable<TEntity> query,
        SortOptions sortOptions)
    {
        if (null == sortingService)
        {
            // TODO: figure out what type of exception to throw.
            throw new Exception($"No sorting service provided for type {typeof(TEntity).Name}.");
        }

        return sortingService.Sort(query, sortOptions);
    }
}