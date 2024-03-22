using Application.Features.Cars.Dtos;
using Core.Application.Pipelines.Caching;
using Core.Application.Responses;
using Core.CrossCuttingConcers.Utilities.Results;
using MediatR;

namespace Application.Features.Cars.Queries.GetAll;

public class GetAllCarQuery : IRequest<List<GetCarResponse>>//, ICachableRequest
{
    //public bool BypassCache { get; }
    //public string CacheKey => "car-list";
    //public TimeSpan? SlidingExpiration { get; }
}
