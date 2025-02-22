using AutoMapper;
using LeadManagermentApi.Features.Leads.DTOs;
using LeadManagermentApi.Repositories;
using MediatR;

namespace LeadManagermentApi.Features.Leads.Queries.GetList;

/// <summary>
/// Handler class for GetListLeadQuery.
/// </summary>
public class GetListLeadQueryHandler(
    IReadRepository<Data.Models.Lead> leadRepository,
    IMapper mapper) : IRequestHandler<GetListLeadQuery, IEnumerable<LeadDto>>
{

    public async Task<IEnumerable<LeadDto>> Handle(GetListLeadQuery request, CancellationToken cancellationToken)
    {
        var leads = await leadRepository.GetManyAsync(null, ["Contact"], cancellationToken);

        return mapper.Map<List<LeadDto>>(leads);
    }
}