using AutoMapper;
using LeadManagermentApi.Data.Models;
using LeadManagermentApi.Features.Contact.Commands.Create;
using LeadManagermentApi.Features.Contact.DTOs;
using LeadManagermentApi.Features.Contact.Queries.Find;
using LeadManagermentApi.Features.Leads.DTOs;
using LeadManagermentApi.Repositories;
using MediatR;

namespace LeadManagermentApi.Features.Leads.Commands.Create;

/// <summary>
/// Handler class for the CreateLeadCOmmand.
/// </summary>
public class CreateLeadCommandHandler(
    IWriteRepository<Lead> leadRepository,
    IMediator mediator,
    IMapper mapper) : IRequestHandler<CreateLeadCommand, LeadDto>
{



    /// <summary>
    /// Handles a CreateLeadCommand request.
    /// </summary>
    /// <param name="command">The request to be handled.</param>
    /// <param name="cancellationToken">Allows for cancellation.</param>
    /// <returns>A LeadDto object with the created lead.</returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<LeadDto> Handle(CreateLeadCommand command, CancellationToken cancellationToken)
    {
        var contact = await FindContact(command, cancellationToken) ??
            await CreateContact(command, cancellationToken);

        var lead = mapper.Map<Data.Models.Lead>(command);

        lead.ContactId = contact.Id;

        lead.CreatedDate = DateTime.UtcNow;

        var result = await leadRepository.CreateAsync(lead, cancellationToken);

        // I would like to try to find a way to avoid this.
        result.Contact = mapper.Map<Data.Models.Contact>(contact);

        return mapper.Map<LeadDto>(result);
    }

    /// <summary>
    /// Attempts to finds an existing contact.
    /// </summary>
    /// <param name="command">The create lead command.</param>
    /// <param name="cancellationToken">Allows fior cancellation.</param>
    /// <returns>A contact if it was found, or null if not found.</returns>
    public async Task<ContactDto?> FindContact(CreateLeadCommand command, CancellationToken cancellationToken)
    {
        var findContactQuery = mapper.Map<FindContactQuery>(command);

        return await mediator.Send(findContactQuery, cancellationToken);
    }

    public async Task<ContactDto> CreateContact(CreateLeadCommand command, CancellationToken cancellationToken)
    {
        var createContactCommand = mapper.Map<CreateContactCommand>(command);

        return await mediator.Send(createContactCommand, cancellationToken);
    }
}