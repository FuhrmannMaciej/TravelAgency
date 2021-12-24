using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelAgencyAPI.Models;

namespace TravelAgencyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelServicesController : ControllerBase
    {
        private readonly TravelAgencyContext _context;

        public HotelServicesController(TravelAgencyContext context)
        {
            _context = context;
        }

        // GET: api/HotelServices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelService>>> GetHotelServices()
        {
            return await _context.HotelServices.ToListAsync();
        }

        // GET: api/HotelServices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelService>> GetHotelService(int id)
        {
            var hotelService = await _context.HotelServices.FindAsync(id);

            if (hotelService == null)
            {
                return NotFound();
            }

            return hotelService;
        }

        // PUT: api/HotelServices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelService(int id, HotelService hotelService)
        {
            if (id != hotelService.ID)
            {
                return BadRequest();
            }

            _context.Entry(hotelService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelServiceExists(id))
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

        // POST: api/HotelServices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HotelService>> PostHotelService(HotelService hotelService)
        {
            _context.HotelServices.Add(hotelService);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHotelService", new { id = hotelService.ID }, hotelService);
        }

        // DELETE: api/HotelServices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelService(int id)
        {
            var hotelService = await _context.HotelServices.FindAsync(id);
            if (hotelService == null)
            {
                return NotFound();
            }

            _context.HotelServices.Remove(hotelService);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HotelServiceExists(int id)
        {
            return _context.HotelServices.Any(e => e.ID == id);
        }
    }
}
