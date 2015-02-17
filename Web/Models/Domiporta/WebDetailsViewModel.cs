namespace Trader.Web.Models.Domiporta
{
    public class WebDetailsViewModel
    {
        public string Id { get; set; }

        public int? Preview { get; set; }

        public int? BackOffice { get; set; }
    }

    public class WebAdvertViewModel
    {
        public string AdvertId { get; set; }

        public int CategoryId { get; set; }
    }
}