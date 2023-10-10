namespace CookieStandApi.Models.Entities
{
    public class HourlySale
    {
            public int Id { get; set; }
        public int HourSale { get; set; }


        public int CookieStandId { get; set; }

            public CookieStand? CookieStand { get; set; }
        }
}
