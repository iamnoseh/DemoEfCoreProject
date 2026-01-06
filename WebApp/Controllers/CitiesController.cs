using Domain.Dto.City;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CitiesController(ICityService service) :  ControllerBase
{
    [HttpPost]
    public IActionResult CreateCity(CreateCityDto dto)
    {
        var res = service.Create(dto);
        return Ok(res);
    }

    [HttpPut]
    public IActionResult UpdateCity(int id,UpdateCityDto dto)
    {
        var res = service.Update(id,dto);
        return Ok(res);
    }

    [HttpDelete]
    public IActionResult DeleteCity(int id)
    {
        var res = service.Delete(id);
        return Ok(res);
    }

    [HttpGet]
    public IActionResult GetAllCountries()
    {
        var res = service.GetAllCities();
        return Ok(res);
    }

    [HttpGet("id")]
    public IActionResult GetCity(int id)
    {
        var res = service.GetCityById(id);
        return Ok(res);
    }
    
}