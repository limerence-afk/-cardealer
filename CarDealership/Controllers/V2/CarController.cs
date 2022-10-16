using CarDealership.Entities;
using CarDealership.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarDealership.Controllers.V2;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("2.0")]
public class CarController : ControllerBase
{
    private readonly ICarService _carService;

    public CarController(ICarService carService)
    {
        _carService = carService;
    }

    [MapToApiVersion("2.0")]
    [HttpGet]
    public ActionResult<IEnumerable<Car>> GetCars([FromQuery] string? manufacturer)
    {
        Func<Car, bool> predicate = manufacturer is null
            ? car => !car.IsSold
            : car => car.Manufacturer == manufacturer && !car.IsSold;
        return Ok(_carService.FindCars(predicate));
    }
}