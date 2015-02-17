namespace Trader.Web.Models.Domiporta
{
    using System;

    using Trader.Common;
    using Trader.Model.Glossaries.Providers;

    public class WebSearchResultViewModel
    {
        public string City { get; set; }

        public int CategoryId { get; set; }
    }

    public abstract class WebSearchResultBase
    {
        public int TransactionTypeId { get; set; }

        public string City { get; set; }

        public string District { get; set; }

        public int CategoryId { get; set; }

        public RangeCriteria Price { get; set; }

        public RangeCriteria Area { get; set; }

        public RangeCriteria NumberOfRooms { get; set; }

        public int MarketSegmentSelectedId { get; set; }
    }

    public class WebSearchResultViewModelSecondaryMarket : WebSearchResultBase
    {
        public WebSearchResultViewModelSecondaryMarket()
        {
            MarketSegmentSelectedId = MarketSegmentProvider.SecondaryMarketId;
        }
    }

    public class WebSearchResultViewModelPrimaryMarket : WebSearchResultBase
    {
        public WebSearchResultViewModelPrimaryMarket()
        {
            MarketSegmentSelectedId = MarketSegmentProvider.PrimaryMarketId;
        }
    }

    /// <summary>
    /// This view model mimics properties that are created by IIS in UrlRewrite,
    /// Do not change it names
    /// </summary>
    public class GuessMarketViewModel
    {
        public GuessMarketViewModel()
        {
            Dzielnica2 = new string[10];
        }

        public const string PrimaryMarket = "P";
        public const string SecondaryMarket = "W";
        public const string ComercialMarket = "K";

        public const int SearchAlsoPrimaryMarket = 1; // If Developer is set to this value search both markets

        public string Rynek { get; set; }

        public int? Trn { get; set; }

        public string Deweloper { get; set; }

        public int? CategoryId { get; set; }

        public string Miasto { get; set; }

        public string Dzielnica { get; set; }

        /// <summary>
        /// In request there are many properties named dzielnica2, so they are mapped as array
        /// </summary>
        public string[] Dzielnica2 { get; set; }

        public string Ulica { get; set; }

        public string SortColumn { get; set; }

        public string SortDirection { get; set; }

        public int? Region { get; set; }

        public decimal? Cena_from { get; set; }

        public decimal? Cena_to { get; set; }

        public decimal? Powierzchnia_from { get; set; }

        public decimal? Powierzchnia_to { get; set; }

        public decimal? Liczba_pokoi_from { get; set; }

        public decimal? Liczba_pokoi_to { get; set; }

        /// <summary>
        /// If it's set to SearchAlsoPrimaryMarket => Search in both primary and secondary market
        /// </summary>
        public int? Developer { get; set; }

        public RangeCriteria Price
        {
            get
            {
                return new RangeCriteria
                    {
                        From = new GlossaryFilter<int> { SelectedValue = CastNullableDecimalToNullableInt(Cena_from) },
                        To = new GlossaryFilter<int> { SelectedValue = CastNullableDecimalToNullableInt(Cena_to) }
                    };
            }
        }

        public RangeCriteria Area
        {
            get
            {
                return new RangeCriteria
                {
                    From = new GlossaryFilter<int> { SelectedValue = CastNullableDecimalToNullableInt(Powierzchnia_from) },
                    To = new GlossaryFilter<int> { SelectedValue = CastNullableDecimalToNullableInt(Powierzchnia_to) }
                };
            }
        }

        public RangeCriteria NumberOfRooms
        {
            get
            {
                return new RangeCriteria
                {
                    From = new GlossaryFilter<int> { SelectedValue = CastNullableDecimalToNullableInt(Liczba_pokoi_from) },
                    To = new GlossaryFilter<int> { SelectedValue = CastNullableDecimalToNullableInt(Liczba_pokoi_to) }
                };
            }
        }

        private int? CastNullableDecimalToNullableInt(decimal? dec)
        {
            if (dec.HasValue)
            {
                return Convert.ToInt32(dec.Value);
            }

            return null;
        }
    }
}