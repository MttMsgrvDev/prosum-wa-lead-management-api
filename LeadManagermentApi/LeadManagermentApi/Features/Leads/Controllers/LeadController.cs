using LeadManagermentApi.DTOs;
using LeadManagermentApi.Features.Leads.Commands.Create;
using LeadManagermentApi.Features.Leads.DTOs;
using LeadManagermentApi.Services.Filtering;
using LeadManagermentApi.Services.Include;
using LeadManagermentApi.Services.Sort;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LeadManagermentApi.Features.Leads.Controllers;

/// <summary>
/// API controller for leads.
/// </summary>
/// <remarks>
/// Creates a new instance of LeadController.
/// </remarks>
/// <param name="mediator">Provides mediator services.</param>
/// <param name="includeStringParser">Parses include query strings.</param>
/// <param name="filterStringParser">Parses filter query strings.</param>
/// <param name="sortStringParser">Parses sort query strings.</param>
[Route("api/[controller]")]
[ApiController]
public class LeadController(
    IMediator mediator,
    IIncludeStringParser includeStringParser,
    IFilterOptionsProvider filterSetProvider,
    ISortStringParser sortStringParser) : ControllerBase
{

    /// <summary>
    /// Endpoint to creates a new lead.
    /// </summary>
    /// <param name="command">Contains the information about the create lead command.</param>
    /// <returns>An action result with the created lead.</returns>
    [HttpPost]
    public async Task<ActionResult<LeadDto>> CreateLead(CreateLeadCommand command)
    {
        var result = await mediator.Send(command);

        return Created("", result);
    }

    [HttpGet,
        Route("list")]
    public async Task<ActionResult<IEnumerable<LeadDto>>> GetLeads(
        [FromQuery] string? include,
        [FromQuery] string? sort)
    {
        var filterOptions = filterSetProvider.GetFilters();

        var includeOptions = !string.IsNullOrWhiteSpace(include)
            ? includeStringParser.Parse(include)
            : default;

        var sortOptions = !string.IsNullOrWhiteSpace(sort)
            ? sortStringParser.Parse(sort)
            : default;

        var query = new GetListQuery<LeadDto>(
            filterOptions,
            sortOptions,
            includeOptions);

        var result = await mediator.Send(query);

        return Ok(result);
    }
}