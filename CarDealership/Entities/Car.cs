namespace CarDealership.Entities;

public class Car : IEntity
{
    public int Id { get; set; }
    public string? Manufacturer { get; set; }
    public string? Model { get; set; }
    public DateTime ProductionDate { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public bool IsSold { get; set; }
}