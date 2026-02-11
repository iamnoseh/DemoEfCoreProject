using System.Net;
using AutoMapper;
using Domain.Dto.User;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Service;

public class UserService(ApplicationDataContext context,
    IMapper mapper) : IUserService
{
    public Response<string> CreateUser(CreateUserDto dto)
    {
        try
        {
            var user = mapper.Map<User>(dto);
            context.Users.Add(user);
            var res =context.SaveChanges();
            return res > 0
                ? new Response<string>(HttpStatusCode.Created, "User created successfully")
                : new Response<string>(HttpStatusCode.BadRequest, "Error creating user");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, "Internal Server Error");
        }
    }

    public Response<string> UpdateUser(int userId, UpdateUserDto dto)
    {
        var oldUser = context.Users.FirstOrDefault(x => x.Id == userId);
        oldUser.Name = dto.Name ?? oldUser.Name;
        oldUser.Phone = dto.Phone ?? oldUser.Phone;
        oldUser.Email = dto.Email ?? oldUser.Email;
        oldUser.BirthDate = dto.BirthDate ?? oldUser.BirthDate;
        oldUser.Gender = dto.Gender ?? oldUser.Gender;
        var res = context.SaveChanges();
        return res > 0 ? 
            new Response<string>(HttpStatusCode.OK, "User updated successfully") 
            : new Response<string>(HttpStatusCode.BadRequest, "Error updating user");
    }

    public Response<string> DeleteUser(int userId)
    {
        var res =context.Users.FirstOrDefault(x => x.Id == userId);
        if(res == null) return new Response<string>(HttpStatusCode.NotFound, "User not found");
        context.Users.Remove(res);
        var effect = context.SaveChanges();
        return effect > 0 
            ? new Response<string>(HttpStatusCode.OK, "User deleted successfully") 
            : new Response<string>(HttpStatusCode.BadRequest, "Error deleting user");
    }

    public Response<List<GetUserDto>> GetAllUsers()
    {
        var users = context.Users.ToList();
        var res = mapper.Map<List<GetUserDto>>(users);
        return new Response<List<GetUserDto>>(res);
    }

    public Response<GetUserDto?> GetUserById(int userId)
    {
        var res = context.Users.FirstOrDefault(x => x.Id == userId);
        if (res == null) return new Response<GetUserDto?>(HttpStatusCode.NotFound, "User not found");
        var dto = mapper.Map<GetUserDto>(res);
        return new Response<GetUserDto?>(dto);
    }
}