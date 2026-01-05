using Domain.Dto;


namespace Infrastructure.Interfaces;

public interface ICountryService
{
    bool CreateCountry(CreateCountryDto dto);
    bool UpdateCountry(int id,UpdateCountryDto dto);
    bool DeleteCountry(int id);
    List<GetCountryDto> GetAllCountry();
    GetCountryDto GetCountryById(int id);
}
