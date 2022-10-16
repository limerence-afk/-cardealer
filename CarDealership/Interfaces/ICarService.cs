using CarDealership.Entities;
using CarDealership.Models;

namespace CarDealership.Interfaces;

public interface ICarService
{
    Car AddCar(CreateCarDto carDto);
    IEnumerable<Car> GetCars();
    Car? GetById(int id);
    void DeleteById(int id);
    void Patch(int id, UpdateCarDto patchEntity);
    IEnumerable<Car> FindCars(Func<Car, bool> predicate);
}