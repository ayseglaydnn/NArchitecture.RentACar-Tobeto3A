using MediatR;

namespace Application.Features.Brands.Commands.Delete;

public class DeleteBrandCommand : IRequest<DeleteBrandResponse>
{
    public Guid Id { get; set; }
}
