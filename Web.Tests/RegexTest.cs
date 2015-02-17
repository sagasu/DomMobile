// -----------------------------------------------------------------------
// <copyright file="RegexTest.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Web.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Web.Mvc;

    using Moq;
    using Moq.Mvc;

    using Trader.Web.Attributes;
    using Trader.Web.Helpers;

    using Xunit;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class RegexTest
    {
        [Fact]
        public void Regex()
        {
            Console.WriteLine(new Regex(@"[\w]*$").Match("ogloszenia,191,Katowice").Value);
        }

        [Fact]
        public void WebSearchResultSecondaryMarketBinder_Success()
        {
            // primaryMarket:  oferty/{transactionTypeName}/{categoryTypeName}/{location}/{district}/{street}/{parameters}

            var pirmaryMarketUrl = @"oferty//////foo";

            Assert.Equal("", RegexHelper.Map(
                    pirmaryMarketUrl, WebSearchResultSecondaryMarketBinder.TransactionTypeLongRegex, WebSearchResultSecondaryMarketBinder.TransactionTypeShortRegex));

            pirmaryMarketUrl = @"oferty/Kupie/////foo";

            Assert.Equal("Kupie", RegexHelper.Map(
                    pirmaryMarketUrl, WebSearchResultSecondaryMarketBinder.TransactionTypeLongRegex, WebSearchResultSecondaryMarketBinder.TransactionTypeShortRegex));

            pirmaryMarketUrl = @"oferty/Kupie/Mieszkania////foo";

            Assert.Equal("Mieszkania", RegexHelper.Map(
                    pirmaryMarketUrl, WebSearchResultPrimaryMarketBinder.CategoryLongRegex, WebSearchResultPrimaryMarketBinder.CategoryShortRegex));

        }
    }
}
