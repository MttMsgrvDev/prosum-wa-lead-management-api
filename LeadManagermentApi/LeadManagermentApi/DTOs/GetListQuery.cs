using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LeadManagermentApi.DTOs;

/// <summary>
/// A query to get a list of records.
/// </summary>
/// <typeparam name="TRecord">The type of records to get.</typeparam>
/// <param name="FilterOptions">Options for filtering records.</param>
/// <param name="SortOptions">Options for sorting.</param>
/// <param name="IncludeOptions">Options for including child objects.</param>
public record GetListQuery<TRecord>(
    [FromQuery] FilterOptions? FilterOptions = null,
    [FromQuery] SortOptions? SortOptions = null,
    [FromQuery] IncludeOptions? IncludeOptions = null
) : IRequest<IEnumerable<TRecord>>;