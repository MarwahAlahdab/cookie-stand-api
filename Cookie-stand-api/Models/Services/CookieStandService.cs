using System;
using Cookie_stand_api.Data;
using Cookie_stand_api.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cookie_stand_api.Models.Services
{
	public class CookieStandService : ICookieStandService
	{

        private readonly CookieStandDBContext _context;
        public CookieStandService(CookieStandDBContext context)
		{
            _context = context;

        }

        public async Task<CookieStand> CreateCookieStand(CookieStand cookieStand)
        {
            _context.CookieStands.Add(cookieStand);
            await _context.SaveChangesAsync();
            return cookieStand;
        }

     

        public async Task<IEnumerable<CookieStand>> GetAllCookieStands()
        {
            return await _context.CookieStands.ToListAsync();
        }


        public async Task<CookieStand> GetCookieStand(int id)
        {
            return await _context.CookieStands.FirstOrDefaultAsync(c => c.Id == id);
        }





        public async Task<CookieStand> UpdateCookieStand(int id, CookieStand updatedCookieStand)
        {
            var cookieStand = await _context.CookieStands.FirstOrDefaultAsync(c => c.Id == id);
            if (cookieStand != null)
            {
                cookieStand.Location = updatedCookieStand.Location;
                cookieStand.Description = updatedCookieStand.Description;
                cookieStand.MinimumCustomersPerHour = updatedCookieStand.MinimumCustomersPerHour;
                cookieStand.MaximumCustomersPerHour = updatedCookieStand.MaximumCustomersPerHour;
                cookieStand.AverageCookiesPerSale = updatedCookieStand.AverageCookiesPerSale;
                cookieStand.Owner = updatedCookieStand.Owner;
                cookieStand.HourlySales = updatedCookieStand.HourlySales;

                _context.SaveChanges();
            }
            return cookieStand;
        }



        public async Task DeleteCookieStand(int id)
        {
            var cookieStand = _context.CookieStands.Find(id);
            if (cookieStand != null)
            {
                _context.CookieStands.Remove(cookieStand);
                _context.SaveChanges();
            }
        }



    }
}

