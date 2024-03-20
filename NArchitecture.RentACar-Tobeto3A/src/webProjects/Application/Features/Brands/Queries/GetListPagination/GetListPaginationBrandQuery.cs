using Application.Features.Brands.Dtos;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using MediatR;


namespace Application.Features.Brands.Queries.GetListPagination;

public class GetListPaginationBrandQuery : IRequest<GetListResponse<GetBrandResponse>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public bool BypassCache { get; }

    public string CacheKey => "brand-list";

    public TimeSpan? SlidingExpiration { get; }
}
