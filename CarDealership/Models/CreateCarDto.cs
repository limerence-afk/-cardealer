namespace CarDealership.Models;

public class CreateCarDto
{
    public string? Manufacturer { get; set; }
    public string? Model { get; set; }
    public DateTime ProductionDate { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
}