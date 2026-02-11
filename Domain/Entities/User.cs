using Domain.Enums;

namespace Domain.Entities;

public class User : BaseEntity
{
    public string Name { get; set; } = String.Empty;
    public string Phone { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public DateTime BirthDate { get; set; } 
    public Gender Gender { get; set; } 
    public Country? Country { get; set; } 
}