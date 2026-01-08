namespace Domain.Entities;

public class User : BaseEntity
{
    public string Name { get; set; } = String.Empty;
    public string Phone { get; set; } = String.Empty;
    public int Age { get; set; } = 35;
    
    //navigation
    public Country? Country { get; set; } 
}