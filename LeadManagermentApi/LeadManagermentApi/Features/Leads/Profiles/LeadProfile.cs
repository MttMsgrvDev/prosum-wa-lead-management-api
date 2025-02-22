using AutoMapper;
using LeadManagermentApi.Data.Models;
using LeadManagermentApi.Features.Contact.Commands.Create;
using LeadManagermentApi.Features.Contact.Queries.Find;
using LeadManagermentApi.Features.Leads.Commands.Create;
using LeadManagermentApi.Features.Leads.DTOs;

namespace LeadManagermentApi.Features.Leads.Profiles;

public class LeadProfile : Profile
{
    public LeadProfile()
    {
        CreateMap<CreateLeadCommand, FindContactQuery>();
        CreateMap<CreateLeadCommand, CreateContactCommand>();
        CreateMap<CreateLeadCommand, Lead>();

        CreateMap<Lead, LeadDto>();
    }
}