using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Performance;
using Core.CrossCuttingConcers.Utilities.Results;
using MediatR;

namespace Application.Features.Brands.Commands.Update;

public class UpdateBrandCommand : IRequest<UpdateBrandResponse>, IIntervalRequest, ILoggableRequest, ICacheRemoverRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public int Interval => 1;
    public bool BypassCache { get; }
    public string CacheKey => "brand-list";
}
