namespace Domain.Entities;

public class Country : BaseEntity
{
    public string Name { get; set; } = String.Empty;
    public string Capital { get; set; } = String.Empty;
    public string? State { get; set; }
    
    public int? UserId {get; set;}
    //navigations
    public User? President {get; set;}
    public List<City>? Cities { get; set; } 
}