using AutoMapper;
using LeadManagermentApi.Features.Contact.DTOs;
using LeadManagermentApi.Features.Contact.Excceptions;
using LeadManagermentApi.Repositories;
using MediatR;

namespace LeadManagermentApi.Features.Contact.Commands.Create;

/// <summary>
/// Handler class for CreateContactCommand.
/// </summary>
public class CreateContactCommandHandler(
    IReadWriteRepository<Data.Models.Contact> repository,
    IMapper mapper) : IRequestHandler<CreateContactCommand, ContactDto>
{
    /// <summary>
    /// Handles a request to create a new contact.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <exception cref="ContactAlreadyExistsException">Throws a ContactAlreadyExistsException when a contact with the same email already exists.</exception>
    /// <returns></returns>
    public async Task<ContactDto> Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        await CheckContactExists(request, cancellationToken);

        var entity = mapper.Map<Data.Models.Contact>(request);

        var result = await repository.CreateAsync(entity, cancellationToken);

        return mapper.Map<ContactDto>(result);
    }

    /// <summary>
    /// Checks to see if the contact already exists.
    /// </summary>
    /// <param name="request">The request to create a contact.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    private async Task CheckContactExists(CreateContactCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Email))
        {
            return;
        }

        var result = await repository.GetManyAsync(c => c.Email == request.Email, cancellationToken);

        if (result.Any())
        {
            throw new ContactAlreadyExistsException();
        }
    }
}