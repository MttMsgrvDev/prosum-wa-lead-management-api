using LeadManagermentApi.Features.Contact.DTOs;
using MediatR;

namespace LeadManagermentApi.Features.Contact.Queries.Find;

/// <summary>
/// A query to find a contact.
/// </summary>
public record FindContactQuery(string Email, string PhoneNumber) : IRequest<ContactDto?>;