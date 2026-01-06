namespace Domain.Entities;

public class City
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; } 
    public int? Population { get; set; }
    public DateTime Created { get; set; } =  DateTime.UtcNow;
}