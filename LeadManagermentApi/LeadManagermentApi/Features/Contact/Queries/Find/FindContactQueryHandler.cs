using LeadManagermentApi.Features.Contact.DTOs;
using MediatR;

namespace LeadManagermentApi.Features.Contact.Queries.Find;

/// <summary>
/// Handler class for FindContactQuery.
/// </summary>
public class FindContactQueryHandler : IRequestHandler<FindContactQuery, ContactDto?>
{
    public Task<ContactDto?> Handle(FindContactQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}