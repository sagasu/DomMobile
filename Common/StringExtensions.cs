// -----------------------------------------------------------------------
// <copyright file="StringExtensions.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Common
{
    /// <summary>
    /// Capitalize a string - first element to upper case.
    /// </summary>
    public static class StringExtensions
    {
        public static string Capitalize(this string stringToCapitalize)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(stringToCapitalize))
            {
                return string.Empty;
            }

            // Return char and concat substring.
            return char.ToUpper(stringToCapitalize[0]) + stringToCapitalize.Substring(1);
        }
    }
}
