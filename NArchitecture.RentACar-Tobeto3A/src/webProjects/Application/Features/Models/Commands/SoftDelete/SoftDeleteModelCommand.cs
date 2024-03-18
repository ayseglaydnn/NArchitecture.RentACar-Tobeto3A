using MediatR;

namespace Application.Features.Models.Commands.SoftDelete;

public class SoftDeleteModelCommand:IRequest<SoftDeleteModelResponse>
{
    public Guid Id { get; set; }
}
