using AutoMapper;
using LeadManagermentApi.DTOs;
using LeadManagermentApi.Features.Leads.DTOs;
using LeadManagermentApi.Repositories;
using MediatR;

namespace LeadManagermentApi.Features.Leads.Queries.GetList;

/// <summary>
/// Handler class for GetListLeadQuery.
/// </summary>
public class GetLeadListQueryHandler(
    IReadRepository<Data.Models.Lead> leadRepository,
    IMapper mapper) : IRequestHandler<GetListQuery<LeadDto>, IEnumerable<LeadDto>>
{

    public async Task<IEnumerable<LeadDto>> Handle(GetListQuery<LeadDto> request, CancellationToken cancellationToken)
    {
        var leads = await leadRepository.GetManyAsync(
            request.FilterOptions,
            request.IncludeOptions,
            request.SortOptions,
            cancellationToken);

        return mapper.Map<List<LeadDto>>(leads);
    }
}