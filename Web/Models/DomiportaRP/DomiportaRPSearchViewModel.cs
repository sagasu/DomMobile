namespace Trader.Web.Models.DomiportaRP
{
    public class DomiportaRPSearchViewModel
    {
        public int CategoryId { get; set; }

        public string Localization { get; set; }

        public int? RoomCountFrom { get; set; }

        public int? RoomCountTo { get; set; }

        public int? PriceFrom { get; set; }

        public int? PriceTo { get; set; }

        public int? AreaFrom { get; set; }

        public int? AreaTo { get; set; }

    }
}