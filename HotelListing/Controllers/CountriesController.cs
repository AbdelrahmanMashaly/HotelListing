using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListing.Data;
using HotelListing.Dto;
using AutoMapper;
using HotelListing.Interfaces;

namespace HotelListing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountriesRepo countryRepo;
        private readonly IMapper mapper;

        public CountriesController(ICountriesRepo countryRepo, IMapper mapper)
        {
            this.countryRepo = countryRepo;
            this.mapper = mapper;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetUpdateDto>>> GetCountries()
        {
            var countries =  await countryRepo.GetAllAsync();
            
            return Ok(mapper.Map<IEnumerable<Country>, IEnumerable<GetUpdateDto>>(countries));
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDto>> GetCountry(int id)
        {
            var country = await countryRepo.GetCountryWithHotels(id);

            if (country == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<Country,CountryDto>(country));
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, GetUpdateDto UpdateCountry)
        {
            
            if (id != UpdateCountry.Id)
            {
                return BadRequest();
            }

            var country = await countryRepo.GetAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            mapper.Map(UpdateCountry, country);
            try
            {
                await countryRepo.UpdateAsync(country);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await CountryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(CreateCountryDto CreateCountry)
        {
           var country = mapper.Map<Country>(CreateCountry);
          await countryRepo.CreateAsync(country);

            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await countryRepo.GetAsync(id);
            if (country == null)
            {
                return NotFound();
            }

           countryRepo.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> CountryExists(int id)
        {
            return await countryRepo.Exists(id);
        }
    }
}
