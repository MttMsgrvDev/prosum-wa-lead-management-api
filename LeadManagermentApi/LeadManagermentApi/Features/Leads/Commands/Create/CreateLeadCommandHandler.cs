using LeadManagermentApi.Features.Leads.DTOs;
using MediatR;

namespace LeadManagermentApi.Features.Leads.Commands.Create;

/// <summary>
/// Handler class for the CreateLeadCOmmand.
/// </summary>
public class CreateLeadCommandHandler : IRequestHandler<CreateLeadCommand, LeadDto>
{

    /// <summary>
    /// Handles a CreateLeadCommand request.
    /// </summary>
    /// <param name="request">The request to be handled.</param>
    /// <param name="cancellationToken">Allows for cancellation.</param>
    /// <returns>A LeadDto object with the created lead.</returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<LeadDto> Handle(CreateLeadCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}