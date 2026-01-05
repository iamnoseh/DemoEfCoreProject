namespace Domain.Dto;

public class CreateCountryDto
{
    public string Name { get; set; }
    public string PresidentName { get; set; }
    public string Capital { get; set; }
    public string Code { get; set; }
    public long Population { get; set; }
}