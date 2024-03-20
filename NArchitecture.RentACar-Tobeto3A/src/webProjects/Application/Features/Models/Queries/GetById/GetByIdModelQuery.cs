using Application.Features.Models.Dtos;
using Core.CrossCuttingConcers.Utilities.Results;
using MediatR;

namespace Application.Features.Models.Queries.GetById;

public class GetByIdModelQuery : IRequest<IDataResult<GetModelResponse>>
{
    public Guid Id { get; set; }
}

