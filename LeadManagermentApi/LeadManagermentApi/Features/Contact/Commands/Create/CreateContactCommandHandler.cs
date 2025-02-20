using LeadManagermentApi.Features.Contact.DTOs;
using MediatR;

namespace LeadManagermentApi.Features.Contact.Commands.Create;

/// <summary>
/// Handler class for CreateContactCommand.
/// </summary>
public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, ContactDto>
{
    public Task<ContactDto> Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}