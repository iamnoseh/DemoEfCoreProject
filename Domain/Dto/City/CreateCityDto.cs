namespace Domain.Dto.City;

public class CreateCityDto
{
    public string Name { get; set; } = String.Empty;
    public int Population { get; set; } 
    public string? MayorName { get; set; }
}