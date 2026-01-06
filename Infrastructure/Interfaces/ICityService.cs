using Domain.Dto.City;
using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface ICityService
{
    bool Create(CreateCityDto dto);
    bool Update(int id, UpdateCityDto dto);
    bool Delete(int id);
    GetCityDto? GetCityById(int id);
    List<GetCityDto>? GetAllCities();
}