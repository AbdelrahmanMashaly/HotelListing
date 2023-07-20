using HotelListing.Data;

namespace HotelListing.Dto
{
    public class CountryDto : BaseCountryDto
    {
        public int Id { get; set; }
        public virtual IList<HotelDto> Hotels { get; set; }
    }
}
