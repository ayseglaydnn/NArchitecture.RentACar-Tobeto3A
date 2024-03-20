using Application.Features.Cars.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcers.Utilities.Results;
using Domain.Entities;
using MediatR;

namespace Application.Features.Cars.Queries.GetById;

public class GetByIdCarQueryHandler : IRequestHandler<GetByIdCarQuery, IDataResult<GetCarResponse>>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public GetByIdCarQueryHandler(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }
    public async Task<IDataResult<GetCarResponse>> Handle(GetByIdCarQuery request, CancellationToken cancellationToken)
    {
        var car = await _carRepository.GetAsync(predicate: car => car.Id == request.Id);

        CheckIfCarExists(car);

        GetCarResponse response = _mapper.Map<GetCarResponse>(car);

        return new SuccessDataResult<GetCarResponse>(response, "Showed Successfully");
    }

    private void CheckIfCarExists(Car car)
    {
        if (car is null) throw new ArgumentException("Car does not exist.");
    }
}
