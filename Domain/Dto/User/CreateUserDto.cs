using Domain.Enums;

namespace Domain.Dto.User;

public class CreateUserDto
{
    public string Name { get; set; } = String.Empty;
    public string Phone { get; set; } = String.Empty;
    public string Email { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    public DateTime BirthDate { get; set; }
    
}