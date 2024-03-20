using Application.Features.Cars.Dtos;
using Core.CrossCuttingConcers.Utilities.Results;
using MediatR;

namespace Application.Features.Cars.Queries.GetById;

public class GetByIdCarQuery : IRequest<IDataResult<GetCarResponse>>
{
    public Guid Id { get; set; }
}
