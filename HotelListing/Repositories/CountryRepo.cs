using HotelListing.Data;
using HotelListing.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.Repositories
{
    public class CountryRepo : GenericRepository<Country>, ICountriesRepo
    {
        private readonly HotelContext context;

        public CountryRepo(HotelContext context): base(context)
        {
            this.context = context;
        }
        public async Task<Country> GetCountryWithHotels(int Id)
        {
            var country = await context.Countries.Include(c=>c.Hotels).FirstOrDefaultAsync(c=>c.Id== Id);

            return country;
        }
    }
}
