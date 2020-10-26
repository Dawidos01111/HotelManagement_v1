using Contentful.Core.Models.Management;
using HotelManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
namespace HotelManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Booking> bookings { get; set; }

        public DbSet<BookingStatus> bookingStatuses { get; set; }

        public DbSet<Payments> payments { get; set; }

        public DbSet<PaymentTypes> paymentTypes { get; set; }

       // public DbSet<Rooms> rooms { get; set; }
        public DbSet<RoomTypes> roomTypes { get; set; }

        public DbSet<Customers> customers { get; set; }
        public DbSet<Rooms2> rooms2s { get; set; }
        public DbSet<SignInUserModel> signInUserModels { get; set; }
        public DbSet<SignUpUserModel> signUpUserModels { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<SelectListItem>();
            modelBuilder.Ignore<SelectListGroup>();
            //  modelBuilder.Entity<CommodityViewModel>().Ignore(c => c.CommoditiesList);
        }
    }
}



