// -----------------------------------------------------------------------
// <copyright file="EmailValidator.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Common
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Validator for email, if empty returns true
    /// </summary>
    public static class EmailValidator
    {
        /// <summary>
        /// Validator for en email.
        /// </summary>
        /// <param name="email">email for a validation.</param>
        /// <returns>true if valid email, or null, or empty.</returns>
        public static bool IsValid(string email)
        {
            if (string.IsNullOrEmpty(email)) return true;

            var MatchEmailPattern =
            @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
     + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
                [0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
     + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
                [0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
     + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";

            var reStrict = new Regex(MatchEmailPattern);
            return reStrict.IsMatch(email);
        }
    }
}
