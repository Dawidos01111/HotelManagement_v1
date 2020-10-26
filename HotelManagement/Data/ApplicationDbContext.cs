using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HotelManagement.Models;
using System.ComponentModel;

namespace HotelManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
       public DbSet<Booking> Booking { get; set; }
        public DbSet<BookingStatus> BookingStatus { get; set; }

        public DbSet<Payments> Payments { get; set; }

        public DbSet<PaymentTypes> PaymentTypes { get; set; }

        public DbSet<Rooms> Rooms { get; set; }

        public DbSet<RoomTypes> RoomTypes { get; set; }
    }
}
