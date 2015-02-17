// -----------------------------------------------------------------------
// <copyright file="MarketSegmentProvider.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Model.Glossaries.Providers
{
    using System.Collections.Generic;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class MarketSegmentProvider : IGlossaryProvider<MarketSegment>
    {
        public const int AllId = 0;
        public const int PrimaryMarketId = 1;
        public const int SecondaryMarketId = 2;


        private static readonly MarketSegment[] _marketSegments = new[]
            {
                new MarketSegment { Id = AllId, Name = "Wszystkie oferty" },
                new MarketSegment { Id = PrimaryMarketId, Name = "Tylko z rynku pierwotnego" },
                new MarketSegment { Id = SecondaryMarketId, Name = "Tylko z rynku wtórnego" },
            };

        public static MarketSegment[] MarketSegments { 
            get { return _marketSegments; }
        }

        public IEnumerable<MarketSegment> GetValues()
        {
            return MarketSegments;
        }
    }
}
