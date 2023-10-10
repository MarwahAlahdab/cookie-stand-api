using CookieStandApi.Models.Entities;
using CookieStandAPI.Models.DTOs;

namespace CookieStandAPI.Models.Interfaces
{
    public interface ICookieStand
    {
        Task<CookieStandDto> Create(CookieStandDto cookieStandDto);
        Task<List<CookieStandDto>> GetCookieStands();
        Task<CookieStandDto> GetCookieStandById(int id);
        Task Delete(int id);
        Task<CookieStandDto> Update(int id, CookieStandDto cookieStandDto);

        Task<List<int>> GenerateHourlySales(int CookieStandId, int Minimum_Customers_Per_Hour, int Maximum_Customers_Per_Hour, double Average_Cookies_Per_Sale);

        //public Task<List<HourlySales>> UpdateGenerateHourlySales(int CookieStandID, int Minimum_Customers_Per_Hour,
        //   int Maximum_Customers_Per_Hour, double Average_Cookies_Per_Sale);

    }
}
