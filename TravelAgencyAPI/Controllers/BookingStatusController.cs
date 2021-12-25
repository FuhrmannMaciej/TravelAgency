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
    public class BookingStatusController : ControllerBase
    {
        private readonly TravelAgencyContext _context;

        public BookingStatusController(TravelAgencyContext context)
        {
            _context = context;
        }

        // GET: api/BookingStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingStatus>>> GetBookingStatuses()
        {
            return await _context.BookingStatuses.ToListAsync();
        }

        // GET: api/BookingStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingStatus>> GetBookingStatus(int id)
        {
            var bookingStatus = await _context.BookingStatuses.FindAsync(id);

            if (bookingStatus == null)
            {
                return NotFound();
            }

            return bookingStatus;
        }

        
        // POST: api/BookingStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookingStatus>> PostBookingStatus(BookingStatus bookingStatus)
        {
            _context.BookingStatuses.Add(bookingStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookingStatus", new { id = bookingStatus.ID }, bookingStatus);
        }

        // DELETE: api/BookingStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookingStatus(int id)
        {
            var bookingStatus = await _context.BookingStatuses.FindAsync(id);
            if (bookingStatus == null)
            {
                return NotFound();
            }

            _context.BookingStatuses.Remove(bookingStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookingStatusExists(int id)
        {
            return _context.BookingStatuses.Any(e => e.ID == id);
        }
    }
}
