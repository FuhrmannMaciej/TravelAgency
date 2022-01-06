using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelAgencyAPI.Attributes;
using TravelAgencyAPI.Models;

namespace TravelAgencyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey]
    public class CountriesController : ControllerBase
    {
        private readonly TravelAgencyContext _context;

        public CountriesController(TravelAgencyContext context)
        {
            _context = context;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries(string countryName, string countryCode)
        {
            var countries = from c in _context.Countries
                         select c;

            if (!string.IsNullOrEmpty(countryName))
            {
                countries = countries.Where(o => o.Name.Contains(countryName));
            }
            if (!string.IsNullOrEmpty(countryCode))
            {
                countries = countries.Where(o => o.Code.Equals(countryCode));
            }

            return await countries.ToListAsync();
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountry(int id)
        {
            var country = await _context.Countries.FindAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            return country;
        }

       

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(Country country)
        {
            _context.Countries.Add(country);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCountry", new { id = country.ID }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await _context.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CountryExists(int id)
        {
            return _context.Countries.Any(e => e.ID == id);
        }
    }
}
