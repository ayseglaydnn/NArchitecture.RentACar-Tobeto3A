using Application.Features.Models.Dtos;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using MediatR;

namespace Application.Features.Models.Queries.GetListPagination;

public class GetListByPaginationModelQuery : IRequest<GetListResponse<GetListModelResponse>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public bool BypassCache { get; }

    public string CacheKey => "brand-list";

    public TimeSpan? SlidingExpiration { get; }
}
