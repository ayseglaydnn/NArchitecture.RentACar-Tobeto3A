
using Application.Features.Brands.Commands.SoftDelete;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Cars.Commands.SoftDelete;

public class SoftDeleteCarCommandHandler : IRequestHandler<SoftDeleteCarCommand, SoftDeleteCarResponse>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public SoftDeleteCarCommandHandler(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }
    public async Task<SoftDeleteCarResponse> Handle(SoftDeleteCarCommand request, CancellationToken cancellationToken)
    {
        var car = await _carRepository.GetAsync(predicate: car => car.Id == request.Id);

        CheckIfCarExists(car);

        var deletedCar = await _carRepository.SoftDeleteAsync(car);

        var response = _mapper.Map<SoftDeleteCarResponse>(deletedCar);

        return response;
    }

    private void CheckIfCarExists(Car car)
    {
        if (car is null) throw new ArgumentException("Car does not exist.");
    }
}
