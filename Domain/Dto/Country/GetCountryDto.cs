namespace Domain.Dto.Country;

public class GetCountryDto : CreateCountryDto
{
    public int Id { get; set; }
    public DateTime Created { get; set; }
    public int UserId { get; set; }
    public string? PresidentName { get; set; }
}