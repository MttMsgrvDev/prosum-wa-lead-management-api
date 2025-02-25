using MediatR;

namespace LeadManagermentApi.DTOs;

/// <summary>
/// A query to get a list of records.
/// </summary>
/// <typeparam name="TRecord">The type of records to get.</typeparam>
/// <param name="FilterOptions">Options for filtering records.</param>
/// <param name="SortOptions">Options for sorting.</param>
/// <param name="IncludeOptions">Options for including child objects.</param>
public record GetListQuery<TRecord>(
    FilterOptions? FilterOptions = null,
    SortOptions? SortOptions = null,
    IncludeOptions? IncludeOptions = null
) : IRequest<IEnumerable<TRecord>>;