namespace Domain.Dto.City;

public class GetCityDto : CreateCityDto
{
    public int CityId { get; set; }
    public DateTime CreatedAt { get; set; }
}