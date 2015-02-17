// -----------------------------------------------------------------------
// <copyright file="TimespanHelperTest.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using Trader.Web.Helpers;
using Xunit;

namespace Web.Tests
{
    using System;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class TimespanHelperTest
    {
        [Fact]
        public void TimespanGeneration_Success()
        {
            Console.WriteLine(TimespanHelper.GetCurrentTimespan());
        }

    }
}
