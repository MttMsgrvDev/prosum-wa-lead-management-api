using AutoMapper;
using LeadManagermentApi.Features.Contact.Commands.Create;
using LeadManagermentApi.Features.Contact.DTOs;

namespace LeadManagermentApi.Features.Contact.Profiles;

/// <summary>
/// Mapping profile for contacts.
/// </summary>
public class ContactProfile : Profile
{
    public ContactProfile()
    {
        CreateMap<CreateContactCommand, Data.Models.Contact>();
        CreateMap<Data.Models.Contact, ContactDto>().ReverseMap();
    }
}