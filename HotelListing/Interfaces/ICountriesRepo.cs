using HotelListing.Data;

namespace HotelListing.Interfaces
{
    public interface ICountriesRepo : IGenericRepository<Country>
    {
        Task<Country> GetCountryWithHotels(int Id);
    }
}
