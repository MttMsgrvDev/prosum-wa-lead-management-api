using AutoMapper;
using LeadManagermentApi.DTOs;
using LeadManagermentApi.Features.Contact.DTOs;
using LeadManagermentApi.Repositories;
using MediatR;

namespace LeadManagermentApi.Features.Contact.Queries.Find;

/// <summary>
/// Handler class for FindContactQuery.
/// </summary>
public class FindContactQueryHandler(
    IReadRepository<Data.Models.Contact> contactRepository,
    IMapper mapper) : IRequestHandler<FindContactQuery, ContactDto?>
{
    public async Task<ContactDto?> Handle(FindContactQuery request, CancellationToken cancellationToken)
    {
        var result = !string.IsNullOrWhiteSpace(request.Email)
            ? await FindContactByEmail(request.Email, cancellationToken)
            : await FindContactByPhoneAndLastName(request.PhoneNumber, request.LastName, cancellationToken);

        return null != result
            ? mapper.Map<ContactDto>(result)
            : null;
    }

    private async Task<Data.Models.Contact?> FindContactByEmail(string email, CancellationToken cancellationToken)
    {
        var filterOptions = new FilterOptions([new FieldFilter("Email", "=", email)]);

        return (await contactRepository.GetManyAsync(
            filterOptions,
            null,
            null,
            cancellationToken)).FirstOrDefault();
    }

    private async Task<Data.Models.Contact?> FindContactByPhoneAndLastName(string phoneNumber, string lastName, CancellationToken cancellationToken)
    {
        var filterOptions = new FilterOptions([
            new FieldFilter("PhoneNumber", "=", phoneNumber),
            new FieldFilter("LastName", "=", lastName)
            ]);

        return (await contactRepository.GetManyAsync(
            filterOptions,
            null,
            null,
            cancellationToken)).FirstOrDefault();
    }
}