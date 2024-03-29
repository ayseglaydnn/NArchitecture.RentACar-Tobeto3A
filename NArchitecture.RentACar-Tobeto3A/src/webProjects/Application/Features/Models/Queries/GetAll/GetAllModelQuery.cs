﻿using Application.Features.Models.Dtos;
using Core.Application.Pipelines.Caching;
using MediatR;

namespace Application.Features.Models.Queries.GetAll;

public class GetAllModelQuery : IRequest<List<GetModelResponse>>//, ICachableRequest
{
    //public bool BypassCache { get; }

    //public string CacheKey => "model-list";

    //public TimeSpan? SlidingExpiration { get; }
}
