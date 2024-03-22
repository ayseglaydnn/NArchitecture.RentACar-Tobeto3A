using Application.Services.Repositories;
using Core.CrossCuttingConcers.Exceptions.Types;
using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.Services.CarImageService;

public class CarImageBusinessRules
{
    private readonly ICarImageRepository _carImageRepository;

    public CarImageBusinessRules(ICarImageRepository carImageRepository)
    {
        _carImageRepository = carImageRepository;
    }

    public async Task<List<CarImage>> CheckIfCarImageNull(Guid carId)
    {
        try
        {
            string path = @"\Images\default.jpg";
            var result = await _carImageRepository.GetAllAsync(predicate: c => c.CarId == carId);
            if(result is null)
            {
                List<CarImage> carImages = new List<CarImage>();
                carImages.Add(new CarImage {  CarId = carId, ImagePath = path });
            }
        }
        catch(Exception ex)
        {
            throw new BusinessException(ex.Message);
        }
        return await _carImageRepository.GetAllAsync(c => c.CarId == carId);
    }

    public Task CheckIfImageLimit(Guid carId)
    {
        var carImageCount = _carImageRepository.GetAllAsync(predicate: c => c.CarId == carId).Result.Count;

        if(carImageCount >= 5)
        {
            throw new BusinessException("Exceeded the image limit.");
        }
        return Task.CompletedTask;
    }

    public Task CheckIfCarImageFormat(IFormFile formFile)
    {
        string fileExtension = Path.GetExtension(formFile.FileName).ToLower();
        if(fileExtension != ".jpg" && fileExtension !=".jpeg" &&  fileExtension != ".png")
        {
            throw new BusinessException("Only .jpg, .jpeg and .png type file are allowed.");
        }

        return Task.CompletedTask;
    }

    public async Task CarImageIdShouldExistsWhenSelected(Guid id)
    {
        CarImage? result = await _carImageRepository.GetAsync(c => c.Id == id);
        if (result is null) throw new BusinessException("Car Image Not Exists");
    }

    public async Task CarImageCarIdShouldExistsWhenSelected(Guid carId)
    {
        CarImage? result = await _carImageRepository.GetAsync(c => c.CarId == carId);
        if (result is null) throw new BusinessException("Car Id Not Exists");
    }
}
