using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trader.Web.Helpers
{
    public static class TimespanHelper
    {
        /// <summary>
        /// Returns a current utc time as a Unix Timespan
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentTimespan()
        {
            long ticks = DateTime.UtcNow.Ticks - DateTime.Parse("01/01/1970 00:00:00").Ticks;
            ticks /= 10000000; //Convert windows ticks to seconds
            return ticks.ToString();

            //return (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds.ToString();
        }
    }
}