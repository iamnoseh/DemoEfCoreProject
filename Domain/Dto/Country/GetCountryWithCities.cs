using Domain.Dto.City;

namespace Domain.Dto.Country;

public class GetCountryWithCities 
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Capital { get; set; } = String.Empty;
    public string? State { get; set; }
    public int? UserId { get; set; }
    
    public string? PresidentName { get; set; }
    public List<GetCityDto>? Cities { get; set; } 
}