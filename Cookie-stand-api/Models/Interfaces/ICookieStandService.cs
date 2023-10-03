using System;
namespace Cookie_stand_api.Models.Interfaces
{
	public interface ICookieStandService
	{
        Task <CookieStand> CreateCookieStand(CookieStand cookieStand);

        Task <IEnumerable<CookieStand>> GetAllCookieStands();

        Task <CookieStand> GetCookieStand(int id);

        Task DeleteCookieStand(int id);

        Task <CookieStand> UpdateCookieStand(int id, CookieStand updatedCookieStand);

    }
}

