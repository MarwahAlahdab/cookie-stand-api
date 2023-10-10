using CookieStandApi.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace CookieStandApi.Data
{
    public class CookieStandDbContext: DbContext
    {
        public CookieStandDbContext(DbContextOptions options) : base(options)
        {

        }
     

        public DbSet<CookieStand> CookieStands { get; set; }

        public DbSet<HourlySale> HourlySales { get; set; }







    }

}
