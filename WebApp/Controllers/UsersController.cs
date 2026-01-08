using Domain.Dto.User;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(IUserService service) : Controller
{
    [HttpPost]
    public IActionResult CreateUser(CreateUserDto dto)
    {
        var res = service.CreateUser(dto);
        return StatusCode(res.StatusCode, res);
    }

    [HttpPut]
    public IActionResult UpdateUser(int id,UpdateUserDto dto)
    {
        var res = service.UpdateUser(id,dto);
        return StatusCode(res.StatusCode, res);
    }

    [HttpDelete]
    public IActionResult DeleteUser(int id)
    {
        var res = service.DeleteUser(id);
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet]
    public IActionResult GetUsers()
    {
        var res = service.GetAllUsers();
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet("id")]
    public IActionResult GetUser(int id)
    {
        var res = service.GetUserById(id);
        return StatusCode(res.StatusCode, res);
    }

}