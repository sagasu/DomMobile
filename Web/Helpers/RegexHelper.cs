namespace Trader.Web.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public static class RegexHelper
    {
        /// <exception cref="ShortMatchException">Can't match using ShortMatchException</exception>
        /// <exception cref="LongMatchException">Can't match using LongMatchException</exception>
        /// <exception cref="NullReferenceException">RegexMatch returned null</exception>
        /// <summary>
        /// Match regexp first by using longRegex and then by extracting a value that is returned
        /// by using shortRegex on a longRegex matchvalue.
        /// </summary>
        /// <param name="rawUrl"></param>
        /// <param name="longRegex"></param>
        /// <param name="shortRegex"></param>
        /// <returns></returns>
        public static string Map(string rawUrl, string longRegex, string shortRegex)
        {
            var longMatch = new Regex(longRegex, RegexOptions.IgnoreCase).Match(rawUrl);

            if (!longMatch.Success) throw new LongMatchException();

            var shortMatch = new Regex(shortRegex, RegexOptions.IgnoreCase).Match(longMatch.Value);

            if (!shortMatch.Success) throw new ShortMatchException();

            return shortMatch.Value;
        }

        public static IEnumerable<string> MapList(string rawUrl, string longRegex, string shortRegex)
        {
            var mappedList = new List<string>();

            var longMatch = new Regex(longRegex, RegexOptions.IgnoreCase).Matches(rawUrl);

            if (longMatch == null || longMatch.Count < 1) throw new LongMatchException();

            foreach (string match in longMatch)
            {
                var shortMatch = new Regex(shortRegex, RegexOptions.IgnoreCase).Match(match);

                if (!shortMatch.Success) throw new ShortMatchException();

                mappedList.Add(shortMatch.Value);
            }

            return mappedList;
        }
    }

    public class ShortMatchException : Exception
    {
    }

    public class LongMatchException : Exception
    {
    }
}