namespace Trader.Web.Models.Common
{
    public class PriceViewModel
    {
        public decimal? Amount { get; set; }

        private string _currency = "PLN";
        public string Currency
        {
            get
            {
                return this._currency;
            }
            private set
            {
                _currency = value;
            }
        }
    }
}