using AutoMapper;
using Domain.Dto.Country;
using Domain.Dto.User;
using Domain.Entities;

namespace Infrastructure.Profiles;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<CreateUserDto,User>().ReverseMap();
        CreateMap<User,GetUserDto>().ReverseMap();

        CreateMap<Country, CreateCountryDto>().ReverseMap();
        CreateMap<GetCountryDto,Country>().ReverseMap();
    }
}