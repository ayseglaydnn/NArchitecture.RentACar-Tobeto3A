using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Performance;
using MediatR;

namespace Application.Features.Models.Commands.Create;

public class CreateModelCommand : IRequest<CreateModelResponse>, ICacheRemoverRequest, IIntervalRequest, ILoggableRequest
{
    public Guid BrandId { get; set; }
    public string Name { get; set; }

    public bool BypassCache { get; }
    public string CacheKey => "model-list";
    public TimeSpan? SlidingExpiration { get; }

    public int Interval => 1;
}
