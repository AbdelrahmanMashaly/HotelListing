

using System.ComponentModel.DataAnnotations;

namespace HotelListing.Dto
{
    public abstract class BaseCountryDto
    {
        [Required]
        public string Name { get; set; }
        public string ShortName { get; set; }

    }
}
