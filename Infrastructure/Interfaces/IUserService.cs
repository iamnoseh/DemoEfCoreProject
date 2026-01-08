using Domain.Dto.User;
using Domain.Responses;

namespace Infrastructure.Interfaces;

public interface IUserService
{
    Response<string> CreateUser(CreateUserDto dto);
    Response<string> UpdateUser(int userId, UpdateUserDto dto);
    Response<string> DeleteUser(int userId);
    Response<List<GetUserDto>> GetAllUsers();
    Response<GetUserDto?> GetUserById(int userId);
}