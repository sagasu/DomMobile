// -----------------------------------------------------------------------
// <copyright file="CountryProvider.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Model.Glossaries.Providers
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    internal class CountryProvider : IGlossaryProvider<Country>
    {
        public IEnumerable<Country> GetValues()
        {
            return Country;
        }

        private static IEnumerable<Country> GetCountries()
        {
            yield return new Country { Id = 1, Name = "Austria", RelativeFor = "20000,13130,133,31572", Sanitize = "austria" };
            yield return new Country { Id = 2, Name = "Belgia", RelativeFor = "20000,13130,133,31572", Sanitize = "belgia" };
            yield return new Country { Id = 3, Name = "Białoruś", RelativeFor = "20000,13130,133,31572", Sanitize = "bialorus" };
            yield return new Country { Id = 4, Name = "Bułgaria", RelativeFor = "20000,13130,133,31572", Sanitize = "bulgaria" };
            yield return new Country { Id = 5, Name = "Chorwacja", RelativeFor = "20000,13130,133,31572", Sanitize = "chorwacja" };
            yield return new Country { Id = 6, Name = "Czechy", RelativeFor = "20000,13130,133,31572", Sanitize = "czechy" };
            yield return new Country { Id = 7, Name = "Dania", RelativeFor = "20000,13130,133,31572", Sanitize = "dania" };
            yield return new Country { Id = 8, Name = "Estonia", RelativeFor = "20000,13130,133,31572", Sanitize = "estonia" };
            yield return new Country { Id = 9, Name = "Francja", RelativeFor = "20000,13130,133,31572", Sanitize = "francja" };
            yield return new Country { Id = 10, Name = "Grecja", RelativeFor = "20000,13130,133,31572", Sanitize = "grecja" };
            yield return new Country { Id = 11, Name = "Hiszpania", RelativeFor = "20000,13130,133,31572", Sanitize = "hiszpania" };
            yield return new Country { Id = 12, Name = "Holandia", RelativeFor = "20000,13130,133,31572", Sanitize = "holandia" };
            yield return new Country { Id = 13, Name = "Irlandia", RelativeFor = "20000,13130,133,31572", Sanitize = "irlandia" };
            yield return new Country { Id = 14, Name = "Islandia", RelativeFor = "20000,13130,133,31572", Sanitize = "islandia" };
            yield return new Country { Id = 15, Name = "Kanada", RelativeFor = "20000,13130,133,31572", Sanitize = "kanada" };
            yield return new Country { Id = 16, Name = "Litwa", RelativeFor = "20000,13130,133,31572", Sanitize = "litwa" };
            yield return new Country { Id = 17, Name = "Luksemburg", RelativeFor = "20000,13130,133,31572", Sanitize = "luksemburg" };
            yield return new Country { Id = 18, Name = "Niemcy", RelativeFor = "20000,13130,133,31572", Sanitize = "niemcy" };
            yield return new Country { Id = 19, Name = "Norwegia", RelativeFor = "20000,13130,133,31572", Sanitize = "norwegia" };
            yield return new Country { Id = 20, Name = "Polska", RelativeFor = "20000,13130,133,31572", Sanitize = "polska" };
            yield return new Country { Id = 21, Name = "Rosja", RelativeFor = "20000,13130,133,31572", Sanitize = "rosja" };
            yield return new Country { Id = 22, Name = "Stany Zjednoczone", RelativeFor = "20000,13130,133,31572", Sanitize = "stany_zjednoczone" };
            yield return new Country { Id = 23, Name = "Szwajcaria", RelativeFor = "20000,13130,133,31572", Sanitize = "szwajcaria" };
            yield return new Country { Id = 24, Name = "Szwecja", RelativeFor = "20000,13130,133,31572", Sanitize = "szwecja" };
            yield return new Country { Id = 25, Name = "Słowacja", RelativeFor = "20000,13130,133,31572", Sanitize = "slowacja" };
            yield return new Country { Id = 26, Name = "Ukraina", RelativeFor = "20000,13130,133,31572", Sanitize = "ukraina" };
            yield return new Country { Id = 27, Name = "Wielka Brytania", RelativeFor = "20000,13130,133,31572", Sanitize = "wielka_brytania" };
            yield return new Country { Id = 28, Name = "Węgry", RelativeFor = "20000,13130,133,31572", Sanitize = "wegry" };
            yield return new Country { Id = 29, Name = "Włochy", RelativeFor = "20000,13130,133,31572", Sanitize = "wlochy" };
            yield return new Country { Id = 30, Name = "Łotwa", RelativeFor = "20000,13130,133,31572", Sanitize = "lotwa" };
        }

        private static readonly IEnumerable<Country> Country = GetCountries().ToList();

        internal static Country Get(int id)
        {
            return Country.SingleOrDefault(x => x.Id == id);
        }
    }
}
