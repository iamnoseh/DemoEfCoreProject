using Domain.Dto;
using Domain.Dto.Country;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Interfaces;


namespace Infrastructure.Service;

public class CountryService(DataContext context) : ICountryService
{
    #region CreateCountry

    public bool CreateCountry(CreateCountryDto dto)
    {
        var country = new Country()
        {
            Name = dto.Name,
            Code = dto.Code,
            Population = dto.Population,
            Created = DateTime.UtcNow,
            PresidentName = dto.PresidentName,
            Capital = dto.Capital
        };
        context.Countries.Add(country);
        var res = context.SaveChanges();
        return res > 0;
    }

    #endregion

    #region UpdateCountry
    public bool UpdateCountry(int id, UpdateCountryDto dto)
    {
        var res = context.Countries.FirstOrDefault(x => x.Id == id);
        if (res == null) return false;
        res.Name = dto.Name;
        res.Code = dto.Code;
        res.Population = dto.Population;
        res.PresidentName = dto.PresidentName;
        res.Capital = dto.Capital;
        var effect =  context.SaveChanges();
        return effect > 0;
    }
    #endregion
    
    #region DeleteCountry

    public bool DeleteCountry(int id)
    {
        var oldCountry = context.Countries.FirstOrDefault(x => x.Id == id);
        if (oldCountry == null) return false;
        context.Countries.Remove(oldCountry);
        var res = context.SaveChanges();
        return res > 0;
    }
    #endregion
    
    public List<GetCountryDto> GetAllCountry()
    {
        var res = context.Countries.ToList();
        var dto = res.Select(x => new GetCountryDto()
        {
            Id = x.Id,
            Name = x.Name,
            Code = x.Code,
            Population = x.Population,
            PresidentName = x.PresidentName,
            Capital = x.Capital,
            Created = x.Created
        }).ToList();
        return dto;
    }

    public GetCountryDto GetCountryById(int id)
    {
        var res =  context.Countries.FirstOrDefault(x => x.Id == id);
        if (res == null) return null;
        var dto = new GetCountryDto()
        {
            Id = res.Id,
            Name = res.Name,
            Code = res.Code,
            Population = res.Population,
            PresidentName = res.PresidentName,
            Capital = res.Capital,
            Created = res.Created
        };
        return dto;
    }
}