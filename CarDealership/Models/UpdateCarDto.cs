namespace CarDealership.Models;

public class UpdateCarDto
{
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public bool? IsSold { get; set; }
}