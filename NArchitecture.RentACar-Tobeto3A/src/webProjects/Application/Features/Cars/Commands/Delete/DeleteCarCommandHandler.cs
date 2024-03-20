using Application.Features.Cars.Commands.SoftDelete;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Cars.Commands.Delete;

public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, DeleteCarResponse>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public DeleteCarCommandHandler(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }
    public async Task<DeleteCarResponse> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
    {
        var car = await _carRepository.GetAsync(predicate: car => car.Id == request.Id);

        CheckIfCarExists(car);

        var deletedCar = await _carRepository.DeleteAsync(car);

        var response = _mapper.Map<DeleteCarResponse>(deletedCar);

        return response;
    }

    private void CheckIfCarExists(Car car)
    {
        if (car is null) throw new ArgumentException("Car does not exist.");
    }
}
