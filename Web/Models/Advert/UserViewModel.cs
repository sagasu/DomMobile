namespace Trader.Web.Models.Advert
{
    using System.ComponentModel.DataAnnotations;

    using Trader.Model.Common;

    public class UserViewModel
    {
        public string Address { get; set; }

        public string City { get; set; }

        [UIHint("Email")]
        public EmailViewModel Email { get; set; }

        [UIHint("Phone")]
        public PhoneViewModel Phone { get; set; }

        public string ZipCode { get; set; }

    }
}