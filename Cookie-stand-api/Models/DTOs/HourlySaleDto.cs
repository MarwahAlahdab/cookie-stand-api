using CookieStandApi.Models.Entities;
using CookieStandAPI.Models.DTOs;

namespace CookieStandAPI.Models.DTOs
{
    public class HourlySaleDto
    {
        public int Id { get; set; }
        public int HourSale { get; set; }

        public int CookieStandId { get; set; }

        public CookieStand? CookieStand { get; set; }
    }
}

