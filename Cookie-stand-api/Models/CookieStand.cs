using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cookie_stand_api.Models
{
	public class CookieStand
	{
        public int Id { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public int MinimumCustomersPerHour { get; set; }
        public int MaximumCustomersPerHour { get; set; }
        public double AverageCookiesPerSale { get; set; }
        public string Owner { get; set; }

        [NotMapped] 
        public List<int> HourlySales { get; set; }


    }
}

