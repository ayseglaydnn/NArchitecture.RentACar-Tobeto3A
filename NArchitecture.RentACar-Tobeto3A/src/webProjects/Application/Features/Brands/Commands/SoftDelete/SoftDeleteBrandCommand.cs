using MediatR;

namespace Application.Features.Brands.Commands.SoftDelete;

public class SoftDeleteBrandCommand : IRequest<SoftDeleteBrandResponse>
{
    public Guid Id { get; set; }
}
