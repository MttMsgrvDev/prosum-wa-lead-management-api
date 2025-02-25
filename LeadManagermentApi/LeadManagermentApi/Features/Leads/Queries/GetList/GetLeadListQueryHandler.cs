using AutoMapper;
using LeadManagermentApi.Features.Leads.DTOs;
using LeadManagermentApi.Repositories;
using MediatR;

namespace LeadManagermentApi.Features.Leads.Queries.GetList;

/// <summary>
/// Handler class for GetListLeadQuery.
/// </summary>
public class GetLeadListQueryHandler(
    IReadRepository<Data.Models.Lead> leadRepository,
    IMapper mapper) : IRequestHandler<GetLeadListQuery, IEnumerable<LeadDto>>
{

    public async Task<IEnumerable<LeadDto>> Handle(GetLeadListQuery request, CancellationToken cancellationToken)
    {
        var leads = await leadRepository.GetManyAsync(
            request.FilterOptions,
            request.IncludeOptions,
            request.SortOptions,
            cancellationToken);

        return mapper.Map<List<LeadDto>>(leads);
    }
}