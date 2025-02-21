using LeadManagermentApi.Features.Contact.DTOs;
using MediatR;

namespace LeadManagermentApi.Features.Contact.Queries.Find;

/// <summary>
/// A query to find a contact.
/// </summary>
/// <param name="Email">The email address to search for.</param>
/// <param name="PhoneNumber">The phone number to search for.</param>
/// <param name="LastName">The last name to look for.</param>
public record FindContactQuery(string? Email, string? PhoneNumber, string? LastName) : IRequest<ContactDto?>;