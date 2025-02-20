using AutoMapper;
using LeadManagermentApi.Features.Leads.Commands.Create;
using LeadManagermentApi.Features.Leads.DTOs;
using LeadManagermentApi.Features.Leads.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LeadManagermentApi.Features.Leads.Controllers;

/// <summary>
/// API controller for leads.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class LeadController : ControllerBase
{

    private readonly IMediator _mediator;

    private readonly IMapper _mapper;

    /// <summary>
    /// Creates a new instance of LeadController.
    /// </summary>
    /// <param name="mediator">Provides mediator services.</param>
    /// <param name="mapper">Provides object mapping services.</param>
    public LeadController(
        IMediator mediator,
        IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Endpoint to creates a new lead.
    /// </summary>
    /// <param name="command">Contains the information about the create lead command.</param>
    /// <returns>An action result with the created lead.</returns>
    [HttpPost]
    public async Task<ActionResult<LeadDto>> CreateLead(CreateLeadCommand command)
    {
        var result = await _mediator.Send(command);

        return Created("", result);
    }
}