// -----------------------------------------------------------------------
// <copyright file="SearchViewModelTest.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Web.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Trader.Web.Models.Search;

    using Xunit;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class SearchViewModelTest
    {
        [Fact]
        public void BuildFullFilteredList()
        {
            Console.WriteLine(string.Join(",", SearchViewModel.BuildFullFilteredList(new[] { 1000, 1500, 10000 })));

            Console.WriteLine(string.Join(",", SearchViewModel.BuildFullFilteredList(new[] { 25, 250, 280 }, 3, 9)));

            Console.WriteLine(string.Join(",", new List<int> { 100, 120, 150 }.Concat<int>(SearchViewModel.BuildFullFilteredList(new[] { 25, 250, 280 }, 2, 9))));
        }
    }
}
