using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelAgencyAPI.Attributes;
using TravelAgencyAPI.Models;
using TravelAgencyAPI.Models.OtherModels;

namespace TravelAgencyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey]
    public class OffersController : ControllerBase
    {
        private readonly TravelAgencyContext _context;

        public OffersController(TravelAgencyContext context)
        {
            _context = context;
        }

        /*// GET: api/Offers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Offer>>> GetOffers()
        {
            return await _context.Offers.ToListAsync();
        }*/

        // GET: api/Offers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Offer>> GetOffer(int id)
        {
            var offer = await _context.Offers.FindAsync(id);

            if (offer == null)
            {
                return NotFound();
            }

            return offer;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Offer>>> GetOffers(string offerID ,string fromDate)
        {
            var offers = from o in _context.Offers
                         select o;

            if (!string.IsNullOrEmpty(offerID))
            {
                offers = offers.Where(o => o.ID.ToString().Equals(offerID));
            }
            if (!string.IsNullOrEmpty(fromDate))
            {
                offers = offers.Where(o => o.FromDate.Date.ToString().Contains(fromDate));
            }

            return await offers.ToListAsync();
        }


        // POST: api/Offers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Offer>> PostOffer(Offer offer)
        {
            _context.Offers.Add(offer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOffer", new { id = offer.ID }, offer);
        }

        // DELETE: api/Offers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOffer(int id)
        {
            var offer = await _context.Offers.FindAsync(id);
            if (offer == null)
            {
                return NotFound();
            }

            _context.Offers.Remove(offer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OfferExists(int id)
        {
            return _context.Offers.Any(e => e.ID == id);
        }
    }
}
