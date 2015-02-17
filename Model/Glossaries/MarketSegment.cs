// -----------------------------------------------------------------------
// <copyright file="MarketSegment.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Model.Glossaries
{
    using System.Collections.Generic;

    using Trader.Model.Glossaries.Providers;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class MarketSegment : AbstractGlossary<MarketSegment>, IKeptInCodeGlossary<MarketSegment>
    {
        public override IEnumerable<MarketSegment> GetValues()
        {
            return MarketSegmentProvider.MarketSegments;
        }
    }
}
