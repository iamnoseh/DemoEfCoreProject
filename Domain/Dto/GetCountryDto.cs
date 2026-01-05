namespace Domain.Dto;

public class GetCountryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string PresidentName { get; set; }
    public string Capital { get; set; }
    public string Code { get; set; }
    public long Population { get; set; }
    public DateTime Created { get; set; }
}