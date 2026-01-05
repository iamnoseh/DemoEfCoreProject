using Domain.Dto;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountriesController(ICountryService service) : ControllerBase
{
    [HttpPost]
    public IActionResult CreateCountry(CreateCountryDto dto)
    {
        var res = service.CreateCountry(dto);
        return Ok(res);
    }

    [HttpPut]
    public IActionResult UpdateCountry(int id,UpdateCountryDto dto)
    {
        var res = service.UpdateCountry(id,dto);
        return Ok(res);
    }

    [HttpDelete]
    public IActionResult DeleteCountry(int id)
    {
        var res = service.DeleteCountry(id);
        return Ok(res);
    }

    [HttpGet]
    public IActionResult GetAllCountries()
    {
        var res = service.GetAllCountry();
        return Ok(res);
    }

    [HttpGet("id")]
    public IActionResult GetCountry(int id)
    {
        var res = service.GetCountryById(id);
        return Ok(res);
    }
}