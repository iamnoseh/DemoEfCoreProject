namespace Domain.Entities;

public class City :  BaseEntity
{
    public string Name { get; set; } = String.Empty;
    public int Population { get; set; } 
    public string? MayorName { get; set; }
    
    //navigation
    public int? CountryId { get; set; }
    public Country? Country { get; set; }
}