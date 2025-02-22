using LeadManagermentApi.Features.Leads.DTOs;
using MediatR;

namespace LeadManagermentApi.Features.Leads.Queries.GetList;

/// <summary>
/// A query to get a list of leads.
/// </summary>
public record GetListLeadQuery() : IRequest<IEnumerable<LeadDto>>;