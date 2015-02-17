// -----------------------------------------------------------------------
// <copyright file="LinqTest.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Web.Tests
{
    using System;
    using System.Linq;
    using Trader.Model.Glossaries.Providers;

    using Xunit;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class LinqTest
    {
        [Fact]
        public void LinqTest_Success()
        {
            var cities = CommunityProvider.Communities;

            var foo = string.Join(" Or ", cities.Select(x => string.Concat("City:",x.Sanitize)));

            Console.WriteLine(foo);
        }
    }
}
