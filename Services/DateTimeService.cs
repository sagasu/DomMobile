// -----------------------------------------------------------------------
// <copyright file="DateTimeService.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Services
{
    using System;

    public interface IDateTimeService
    {
        DateTime GetDateTime();
    }

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class DateTimeService : IDateTimeService
    {
        /// <summary>
        /// Date in AllAds is kept in a local time not in UTC, and we don't solve utc problem here
        /// </summary>
        /// <returns></returns>
        public DateTime GetDateTime()
        {
            return DateTime.Now;
        }
    }
}
