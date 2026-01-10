using Domain.Dto.Country;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("api/Country")]
public class CountryController(ICountryService service) : Controller
{
    [HttpPost]
    public IActionResult CreateCountry(CreateCountryDto dto)
    {
        var res = service.CreateCountry(dto);
        return StatusCode(res.StatusCode, res);
    }

    [HttpPut]
    public IActionResult UpdateCountry(int id, UpdateCountryDto dto)
    {
        var res = service.UpdateCountry(id, dto);
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet]
    public IActionResult GetAllCountries()
    {
        var res = service.GetAllCountries();
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet("id")]
    public IActionResult GetCountry(int id)
    {
        var res = service.GetCountryById(id);
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet("get-with-cities")]
    public IActionResult GetCountryWithCities()
    {
        var res = service.GetCountryWithCities();
        return StatusCode(res.StatusCode, res);
    }
}