using Application.Features.Brands.Dtos;
using Core.CrossCuttingConcers.Utilities.Results;
using MediatR;

namespace Application.Features.Brands.Queries.GetById;

public class GetByIdBrandQuery : IRequest<IDataResult<GetBrandResponse>>
{
    public Guid Id { get; set; }
}
