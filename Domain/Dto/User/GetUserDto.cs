namespace Domain.Dto.User;

public class GetUserDto : CreateUserDto
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
}