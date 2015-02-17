// -----------------------------------------------------------------------
// <copyright file="Money.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Model.Common
{
    using System.ComponentModel.DataAnnotations;

    public class Money
    {
        public const string DefaultCurrency = "PLN";

        public Money()
        {
            Currency = DefaultCurrency;
        }

        [UIHint("Decimal")]
        public decimal Amount { get; set; }

        public string Currency { get; set; }
    }
}
