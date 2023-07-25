using HotelListing.Data;
using HotelListing.Interfaces;

namespace HotelListing.Repositories
{
    public class HotelRepo : GenericRepository<Hotel>, IHotelRepo
    {
        private readonly HotelContext context;

        public HotelRepo(HotelContext context): base(context) 
        {
            this.context = context;
        }
    }
}
