using Domain.Enums;

namespace Domain.Dto.User;

public class UpdateUserDto
{
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public Gender? Gender { get; set; }
    public DateTime? BirthDate { get; set; }
}