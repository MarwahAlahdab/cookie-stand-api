using System;
using Cookie_stand_api.Models;
using Microsoft.EntityFrameworkCore;
namespace Cookie_stand_api.Data
{
	public class CookieStandDBContext : DbContext
	{



		public CookieStandDBContext(DbContextOptions<CookieStandDBContext> options) : base(options)
        {
		}


		public DbSet<CookieStand> CookieStands { get; set; }






        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data
            var cookieStands = new List<CookieStand>
        {
            new CookieStand
            {
                Id=1,
                Location = "Amman",
                Description = "Some description",
                MinimumCustomersPerHour = 3,
                MaximumCustomersPerHour = 7,
                AverageCookiesPerSale = 2.5,
                Owner = "Someone"
            },
        };

            // Add the data to the context
            modelBuilder.Entity<CookieStand>().HasData(cookieStands);

            modelBuilder.Entity<CookieStand>()
     .HasKey(c => c.Id);
        }



    }
}

