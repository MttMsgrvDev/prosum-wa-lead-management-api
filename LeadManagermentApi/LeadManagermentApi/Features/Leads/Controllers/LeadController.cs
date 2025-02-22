using AutoMapper;
using LeadManagermentApi.Features.Leads.Commands.Create;
using LeadManagermentApi.Features.Leads.DTOs;
using LeadManagermentApi.Features.Leads.Queries.GetList;
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
/// <param name="mapper">Provides object mapping services.</param>
[Route("api/[controller]")]
[ApiController]
public class LeadController(
    IMediator mediator,
    IMapper mapper) : ControllerBase
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
    public async Task<ActionResult<IEnumerable<LeadDto>>> GetLeads()
    {
        var query = new GetListLeadQuery();

        var result = await mediator.Send(query);

        return Ok(result);
    }
}