using Application.Features.Models.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Models.Queries.GetAll;

public class GetAllModelQueryHandler : IRequestHandler<GetAllModelQuery, List<GetModelResponse>>
{
    private readonly IModelRepository _modelRepository;
    private readonly IMapper _mapper;

    public GetAllModelQueryHandler(IModelRepository modelRepository, IMapper mapper)
    {
        _modelRepository = modelRepository;
        _mapper = mapper;
    }

    public async Task<List<GetModelResponse>> Handle(GetAllModelQuery request, CancellationToken cancellationToken)
    {
        List<Model> models = await _modelRepository.GetAllAsync(include: x => x.Include(x => x.Brand));

        List<GetModelResponse> responses = _mapper.Map<List<GetModelResponse>>(models);

        return responses;
    }
}
