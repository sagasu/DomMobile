// -----------------------------------------------------------------------
// <copyright file="CorrectionHelper.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Model.Solr
{
    using System.Collections.Generic;

    public static class CorrectionHelper
    {
        public static readonly IDictionary<string, string> CorrectionStrings = new Dictionary<string, string>
            {
                { "bialystok", "białystok" },
                { "czestochowa", "częstochowa" },
                { "gdansk", "gdańsk" },
                { "krakow", "kraków" },
                { "łódz", "łódź" },
                { "łodź", "łódź" },
                { "łodz", "łódź" },
                { "lódź", "łódź" },
                { "lódz", "łódź" },
                { "lodź", "łódź" },
                { "lodz", "łódź" },
                { "poznan", "poznań" },
                { "rzeszow", "rzeszów" },
                { "torun", "toruń" },
                { "wroclaw", "wrocław" },
                { "zielona gora", "zielona góra" },
            };

        /// <summary>
        /// Old Domiporta corrects typical spelling misteakes
        /// By default SOLR is strict in search, it won't find łódź if someone find lodz
        /// Business has chosen this ugly approche to take place
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Correct(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return s;
            }

            var sPrepered = s.Trim().ToLower();

            if (CorrectionStrings.ContainsKey(sPrepered))
            {
                return CorrectionStrings[sPrepered];
            }

            return s;
        }
    }
}
