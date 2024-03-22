using Application.Features.Brands.Dtos;
using Core.Application.Pipelines.Caching;
using MediatR;


namespace Application.Features.Brands.Queries.GetAll;

public class GetAllBrandQuery : IRequest<List<GetBrandResponse>>//, ICachableRequest
{
    //public bool BypassCache { get; }
    //public string CacheKey => "brand-list";
    //public TimeSpan? SlidingExpiration { get; }
}