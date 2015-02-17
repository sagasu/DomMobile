// -----------------------------------------------------------------------
// <copyright file="GetAdvertUrlTest.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using Xunit;

namespace Trader.Services.Tests
{
    using System;

    using Trader.AdvertUrlService;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class GetAdvertUrlTest
    {
        [Fact]
        public void TestForGetAdvertUrl()
        {
            var dbSevice = new DbService();
            var advertId = dbSevice.GetAlladsAdvertId();

            if (advertId.HasValue)
            {
                var advertUrl = dbSevice.GetAdvertUrl(101037972);
                var newAdvertId = dbSevice.GetAlladsAdvertIdFromDomiportaRPId(101037972);
                Console.WriteLine(newAdvertId);
                Console.WriteLine(advertUrl);
                Assert.NotEqual(advertUrl, string.Empty);
            }   
        }
    }
}
