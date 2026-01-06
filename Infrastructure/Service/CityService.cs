using Domain.Dto.City;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Service;

public class CityService(DataContext context) : ICityService
{
    #region CreateCity

    public bool Create(CreateCityDto dto)
    {
        var newCity = new City()
        {
            Name = dto.Name,
            Description = dto.Description,
            Population = dto.Population
        };
        context.Cities.Add(newCity);
        var res = context.SaveChanges();
        return res > 0;
    }

    #endregion

    #region UpdateCity
    
    public bool Update(int id, UpdateCityDto dto)
    {
        var oldCity = context.Cities.FirstOrDefault(x => x.Id == id);
        if (oldCity == null)  return false;
        oldCity.Name = dto.Name;
        oldCity.Description = dto.Description;
        oldCity.Population = dto.Population;
        var res = context.SaveChanges();
        return res > 0;
    }
    
    #endregion
    
    #region DeleteCity
    public bool Delete(int id)
    {
        var res = context.Cities.FirstOrDefault(x => x.Id == id);
        if (res == null) return false;
        context.Cities.Remove(res);
        var effect = context.SaveChanges();
        return effect > 0;
    }
    #endregion
    
    #region GetCity
    public GetCityDto? GetCityById(int id)
    {
        var res = context.Cities.FirstOrDefault(x => x.Id == id);
        if (res == null) return null;
        var resDto = new GetCityDto()
        {
            CityId = res.Id,
            Name = res.Name,
            Description = res.Description,
            Population = res.Population,
            CreatedAt = res.Created
        };
        return resDto;
    }
    #endregion

    #region GetAllCities
    
    public List<GetCityDto> GetAllCities()
    {
        var res = context.Cities.ToList();
        var dto = res.Select(x => new GetCityDto()
        {
            CityId = x.Id,
            Name = x.Name,
            Description = x.Description,
            Population = x.Population,
            CreatedAt = x.Created
        }).ToList();
        return dto;
    }
    #endregion
}