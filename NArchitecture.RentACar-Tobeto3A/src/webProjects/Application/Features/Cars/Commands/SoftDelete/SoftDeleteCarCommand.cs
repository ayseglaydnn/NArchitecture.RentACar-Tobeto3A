
using Amazon.Runtime.Internal;
using MediatR;

namespace Application.Features.Cars.Commands.SoftDelete;

public class SoftDeleteCarCommand : IRequest<SoftDeleteCarResponse>
{
    public Guid Id { get; set; }
}
