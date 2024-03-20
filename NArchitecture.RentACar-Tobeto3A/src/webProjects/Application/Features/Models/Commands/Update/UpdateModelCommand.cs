using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Performance;
using Core.CrossCuttingConcers.Utilities.Results;
using MediatR;

namespace Application.Features.Models.Commands.Update;

public class UpdateModelCommand : IRequest<UpdateModelResponse>, ICacheRemoverRequest, IIntervalRequest, ILoggableRequest
{
    public Guid Id { get; set; }
    public Guid BrandId { get; set; }
    public string Name { get; set; }

    public bool BypassCache { get; }
    public string CacheKey => "model-list";

    public int Interval => 1;
}
