namespace Domain.Dto.Country;

public class UpdateCountryDto
{
    public string? Name { get; set; }
    public string? Capital { get; set; }
    public string? State { get; set; }
    public int? UserId { get; set; }
}