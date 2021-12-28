using TravelAgencyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace TravelAgency.Models
{
    public class TravelAgencyMVCContext : DbContext
    {
        public TravelAgencyMVCContext(DbContextOptions<TravelAgencyMVCContext> options)
            : base(options)
        {

        }

        public DbSet<Offer>  Offers { get; set; }

        public DbSet<Offer> Offer { get; set; }

    }
}
