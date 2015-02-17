// -----------------------------------------------------------------------
// <copyright file="City.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Model
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class City
    {
        public City(string name, string sanitize)
        {
            Name = name;
            Sanitize = sanitize;
        }

        public string Name { get; set; }

        /// <summary>
        /// Name in lower case without diacritics
        /// </summary>
        public string Sanitize { get; set; }
    }
}
