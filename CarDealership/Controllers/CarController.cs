using CarDealership.Entities;
using CarDealership.Interfaces;
using CarDealership.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarDealership.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[ApiVersion("2.0")]
public class CarController : ControllerBase
{
    private readonly ICarService _carService;

    public CarController(ICarService carService)
    {
        _carService = carService;
    }

    [HttpPost]
    public IActionResult AddCar(CreateCarDto carDto)
    {
        return StatusCode(201, _carService.AddCar(carDto));
    }

    [MapToApiVersion("1.0")]
    [HttpGet]
    public ActionResult<IEnumerable<Car>> GetCars([FromQuery] string? manufacturer)
    {
        return Ok(manufacturer is null
            ? _carService.GetCars()
            : _carService.FindCars(car => car.Manufacturer == manufacturer));
    }

    [HttpGet("{id}")]
    public ActionResult<Car> GetCarById(int id)
    {
        return Ok(_carService.GetById(id));
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteById(int id)
    {
        _carService.DeleteById(id);
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult PatchById(int id, [FromBody] UpdateCarDto patchEntity)
    {
        _carService.Patch(id, patchEntity);
        return Ok();
    }
}