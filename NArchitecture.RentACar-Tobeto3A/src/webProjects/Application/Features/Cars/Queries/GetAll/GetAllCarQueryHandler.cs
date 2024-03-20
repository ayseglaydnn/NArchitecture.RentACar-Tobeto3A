using Application.Features.Cars.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Responses;
using Core.CrossCuttingConcers.Utilities.Results;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Cars.Queries.GetAll;

public class GetAllCarQueryHandler : IRequestHandler<GetAllCarQuery, List<GetCarResponse>>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public GetAllCarQueryHandler(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public async Task<List<GetCarResponse>> Handle(GetAllCarQuery request, CancellationToken cancellationToken)
    {
        List<Car> cars = await _carRepository.GetAllAsync(include: x => x.Include(x => x.Model).Include(x => x.Model.Brand));

        List<GetCarResponse> responses = _mapper.Map<List<GetCarResponse>>(cars);

        return responses;
    }
}
