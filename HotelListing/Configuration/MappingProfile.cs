using AutoMapper;
using HotelListing.Data;
using HotelListing.Dto;

namespace HotelListing.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Country, CreateCountryDto>().ReverseMap();

            CreateMap<Country, GetUpdateDto>().ReverseMap();
            CreateMap<Hotel, HotelDto>().ReverseMap();

        }
    }
}
