using Domain.Dto.Country;
using Domain.Responses;

namespace Infrastructure.Interfaces;

public interface ICountryService
{
    Response<string> CreateCountry(CreateCountryDto dto);
    Response<string> UpdateCountry(int id,UpdateCountryDto dto);
    Response<List<GetCountryDto>> GetAllCountries();
    Response<GetCountryDto?> GetCountryById(int id);
    Response<List<GetCountryWithCities>> GetCountryWithCities();
}