using System.Net;
using Domain.Dto.User;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Service;

public class UserService(ApplicationDataContext context) : IUserService
{
    #region CreateUser
    
    public Response<string> CreateUser(CreateUserDto dto)
    {
        var newUser = new User
        {
            Name = dto.Name,
            Age = dto.Age,
            Phone = dto.Phone,
        };
        context.Users.Add(newUser);
        var res = context.SaveChanges();
        if (res > 0)
        {
            return new Response<string>(HttpStatusCode.Created,"User created successfully");
        }
        else
        {
            return new Response<string>(HttpStatusCode.BadRequest,"User creation failed");
        }
    }
    
    #endregion

    #region UpdateUser
    public Response<string> UpdateUser(int userId,UpdateUserDto dto)
    {
        var oldUser = context.Users.FirstOrDefault(x=> x.Id == userId);
        if (oldUser == null) 
            return new Response<string>(HttpStatusCode.NotFound,"User not found");
        oldUser.Name = dto.Name ?? oldUser.Name;
        oldUser.Age = dto.Age ?? oldUser.Age;
        oldUser.Phone = dto.Phone ?? oldUser.Phone;
        var res =  context.SaveChanges();
        if (res > 0)
            return new Response<string>(HttpStatusCode.OK,"User updated successfully");
        else
            return new Response<string>(HttpStatusCode.BadRequest,"User updation failed");
    }
    #endregion
    
    #region DeleteUser
    public Response<string> DeleteUser(int userId)
    {
        var res = context.Users.FirstOrDefault(x=> x.Id == userId);
        if (res == null)
            return new Response<string>(HttpStatusCode.NotFound,"User not found");
        context.Users.Remove(res);
        var effect = context.SaveChanges();
        if (effect > 0)
            return new Response<string>(HttpStatusCode.OK,"User deleted successfully");
        else
            return new Response<string>(HttpStatusCode.BadRequest,"User deletion failed");
    }
    #endregion
    
    public Response<List<GetUserDto>> GetAllUsers()
    {
        var res = context.Users.ToList();
        var dtos = res.Select(x => new GetUserDto
        {
            Id = x.Id,
            Name = x.Name,
            Age = x.Age,
            Phone = x.Phone,
            CreatedAt = x.CreatedAt
        }).ToList();
        if (dtos.Count > 0)
            return new Response<List<GetUserDto>>(dtos);
        else 
            return new Response<List<GetUserDto>>(HttpStatusCode.NotFound,"User not found");
    }

    public Response<GetUserDto?> GetUserById(int userId)
    {
        var res = context.Users.FirstOrDefault(x=> x.Id == userId);
        if (res == null)
            return new Response<GetUserDto?>(HttpStatusCode.NotFound,"User not found");
        var dto = new GetUserDto
        {
            Id = res.Id,
            Name = res.Name,
            Age = res.Age,
            Phone = res.Phone,
            CreatedAt = res.CreatedAt
        };
        return new Response<GetUserDto?>(dto);
    }
}