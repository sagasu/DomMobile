// -----------------------------------------------------------------------
// <copyright file="CityProviderTest.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Services.Tests
{
    using System.Linq;

    using Ninject;

    using Trader.TestsBase;

    using Xunit;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class CityProviderTest : TestBase
    {
        [Fact]
        public void SearchCities()
        {
            var cityProvider = Kernel.Get<ICityProvider>();

            cityProvider.RebuildCashedResults();

            Assert.True(cityProvider.GetCityNamesSortedByNumberOfAdverts().Any());
        }
    }
}
