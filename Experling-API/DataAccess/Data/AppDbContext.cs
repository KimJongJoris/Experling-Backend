using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;

namespace DataAccess.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<BandModel> Bands { get; set; }
        public DbSet<VenueModel> Venues { get; set; }
        public DbSet<TicketModel> Tickets { get; set; }
        public DbSet<EventModel> Events { get; set; }
    }
}
