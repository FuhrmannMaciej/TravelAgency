using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TravelAgencyAPI.Models
{
    public class TravelAgencyContext : DbContext
    {
        public TravelAgencyContext(DbContextOptions<TravelAgencyContext> options) 
            : base(options)
        {

        }

        public DbSet<BookingStatus> BookingStatuses { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
