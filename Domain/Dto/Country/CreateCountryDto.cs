namespace Domain.Dto.Country;

public class CreateCountryDto
{
    public string Name { get; set; } = String.Empty;
    public string Capital { get; set; } = String.Empty;
    public string? State { get; set; }
}