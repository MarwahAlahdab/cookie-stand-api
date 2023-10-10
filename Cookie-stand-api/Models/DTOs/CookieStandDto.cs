using CookieStandApi.Models.Entities;
using CookieStandAPI.Models.DTOs;

namespace CookieStandAPI.Models.DTOs
{
    public class CookieStandDto
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string? Description { get; set; }
        public int Minimum_Customers_Per_Hour { get; set; }
        public int Maximum_Customers_Per_Hour { get; set; }
        public double Average_Cookies_Per_Sale { get; set; }
        public string? Owner { get; set; }

        public List<int>? HourlySales { get; set; }

        //    public List<HourlySaleDto>? HourlySalesDto { get; set; }

    }



}