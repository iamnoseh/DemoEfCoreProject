using System.Net;
using Domain.Dto.City;
using Domain.Dto.Country;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Service;

public class CountryService(ApplicationDataContext context) : ICountryService
{
    public Response<string> CreateCountry(CreateCountryDto dto)
    {
        var newCountry = new Country()
        {
            Name = dto.Name,
            Capital = dto.Capital,
            State = dto.State,
        };
        context.Countries.Add(newCountry);
        var res = context.SaveChanges();
        return res > 0 
            ? new  Response<string>(HttpStatusCode.Created,$"Country created successfully") 
            : new  Response<string>(HttpStatusCode.BadRequest,$"Error creating country");
    }

    public Response<string> UpdateCountry(int id, UpdateCountryDto dto)
    {
        var res = context.Countries.FirstOrDefault(x=>x.Id==id);
        if (res == null)
            return new  Response<string>(HttpStatusCode.NotFound, $"Country with id {id} not found");
        res.Capital = dto.Capital ?? res.Capital;
        res.State = dto.State;
        res.Name = dto.Name ??  res.Name;
        res.UserId = dto.UserId;
        var effect =  context.SaveChanges();
        return effect > 0
            ? new  Response<string>(HttpStatusCode.OK,$"Country updated successfully")
            : new  Response<string>(HttpStatusCode.BadRequest,$"Error creating country");
    }

    public Response<List<GetCountryDto>> GetAllCountries()
    {
        var res =  context.Countries
            .Include(x=>x.President).ToList();
        var dto = res.Select(x => new GetCountryDto()
        {
            Id = x.Id,
            Name = x.Name,
            Capital = x.Capital,
            State = x.State,
            UserId = x.UserId ?? 0,
            Created = x.CreatedAt,
            PresidentName = x.President!.Name
        }).ToList();
        return new Response<List<GetCountryDto>>(dto);
    }

    public Response<GetCountryDto?> GetCountryById(int id)
    {
        var res = context.Countries.
            Include(x=> x.President).FirstOrDefault(x=>x.Id==id);
        var dto = new GetCountryDto()
        {
            Id = res!.Id,
            Name = res.Name,
            Capital = res.Capital,
            State = res.State,
            UserId = res.UserId ?? 0,
            Created = res.CreatedAt,
            PresidentName = res.President!.Name
        };
        return new Response<GetCountryDto?>(dto);
    }

    public Response<List<GetCountryWithCities>> GetCountryWithCities()
    {
        var res = context.Countries
            .Include(u => u.President).Select(x=> new GetCountryWithCities()
            {
                Id = x.Id,
                Name = x.Name,
                Capital = x.Capital,
                UserId = x.UserId ?? 0,
                State = x.State,
                PresidentName = x.President!.Name,
                Cities = x.Cities!.Select(e=> new GetCityDto()
                {
                    CityId = e.Id,
                    Name = e.Name,
                    MayorName = e.MayorName,
                    Population = e.Population
                }).ToList()
            }).ToList();
        return new Response<List<GetCountryWithCities>>(res);
    }
}