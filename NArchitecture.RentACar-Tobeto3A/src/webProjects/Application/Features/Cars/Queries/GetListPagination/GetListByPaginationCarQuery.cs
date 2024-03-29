﻿using Application.Features.Cars.Dtos;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using MediatR;

namespace Application.Features.Cars.Queries.GetListPagination;

public class GetListByPaginationCarQuery : IRequest<GetListResponse<GetCarResponse>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public bool BypassCache { get; }

    public string CacheKey => "car-list";

    public TimeSpan? SlidingExpiration { get; }
}
