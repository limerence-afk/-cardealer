using CarDealership.Entities;
using CarDealership.Exceptions;
using CarDealership.Interfaces;
using CarDealership.Models;

namespace CarDealership.Services;

public class CarService : ICarService
{
    private readonly IRepository<Car> _carRepository;

    public CarService(IRepository<Car> carRepository)
    {
        _carRepository = carRepository;
    }

    public Car AddCar(CreateCarDto carDto)
    {
        var car = new Car()
        {
            Description = carDto.Description,
            Price = carDto.Price,
            Manufacturer = carDto.Manufacturer,
            Model = carDto.Model,
            ProductionDate = carDto.ProductionDate
        };
        return _carRepository.Add(car);
    }

    public IEnumerable<Car> GetCars()
    {
        return _carRepository.Get();
    }

    public IEnumerable<Car> FindCars(Func<Car, bool> predicate)
    {
        return _carRepository.Find(predicate);
    }

    public Car? GetById(int id)
    {
        var car = _carRepository.GetById(id);
        if (car is null)
        {
            throw new RequestException("There is no such car on this id", 404);
        }

        return _carRepository.GetById(id);
    }

    public void DeleteById(int id)
    {
        try
        {
            _carRepository.Delete(id);
        }
        catch (Exception)
        {
            throw new RequestException("There is no such car on this id", 404);
        }
    }

    public void Patch(int id, UpdateCarDto patchEntity)
    {
        var entity = _carRepository.GetById(id);
        if (entity == null)
            throw new RequestException("There is no such car on this id", 404);
        if (patchEntity.Description is not null)
        {
            entity.Description = patchEntity.Description;
        }

        if (patchEntity.Price is not null)
        {
            entity.Price = patchEntity.Price.Value;
        }

        if (patchEntity.IsSold is not null)
        {
            entity.IsSold = patchEntity.IsSold.Value;
        }
    }
}