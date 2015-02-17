// -----------------------------------------------------------------------
// <copyright file="CountryProvider.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Model.Glossaries.Providers
{
    using System.Collections.Generic;

    /// <summary>
    /// Osiedla - smaller parts of town than District
    /// </summary>
    public class EstateProvider : IGlossaryProvider<Estate>
    {
        public IEnumerable<Estate> GetValues()
        {
            return estate;
        }

        public static IEnumerable<Estate> Estates
        {
            get { return estate; }
        }

        private static readonly IEnumerable<Estate> estate = new List<Estate>
                {
             new Estate { Id = 1, Name = "Jelonki", Sanitize = "jelonki", District = DistrictProvider.Get(5) }, // Bemowo
             new Estate { Id = 2, Name = "Górce", Sanitize = "gorce", District = DistrictProvider.Get(5) }, // Bemowo
             new Estate { Id = 3, Name = "Boernerowo", Sanitize = "boernerowo", District = DistrictProvider.Get(5) }, // Bemowo
             new Estate { Id = 4, Name = "Groty", Sanitize = "groty", District = DistrictProvider.Get(5) }, // Bemowo

             new Estate { Id = 5, Name = "Nowodwory", Sanitize = "nowodwory", District = DistrictProvider.Get(1) }, // Białołęka
             new Estate { Id = 6, Name = "Tarchomin", Sanitize = "tarchomin", District = DistrictProvider.Get(1) }, // Białołęka

             new Estate { Id = 7, Name = "Młociny", Sanitize = "mlociny", District = DistrictProvider.Get(2) }, // Bielany
             new Estate { Id = 8, Name = "Arkuszowa", Sanitize = "arkuszowa", District = DistrictProvider.Get(2) }, // Bielany
             new Estate { Id = 9, Name = "Placówka", Sanitize = "placowka", District = DistrictProvider.Get(2) }, // Bielany

             new Estate { Id = 10, Name = "Służew", Sanitize = "sluzew", District = DistrictProvider.Get(8) }, // Mokotów
             new Estate { Id = 11, Name = "Służewiec", Sanitize = "sluzewiec", District = DistrictProvider.Get(8) }, // Mokotów
             new Estate { Id = 12, Name = "Sadyba", Sanitize = "sadyba", District = DistrictProvider.Get(8) }, // Mokotów
             new Estate { Id = 13, Name = "Stegny", Sanitize = "stegny", District = DistrictProvider.Get(8) }, // Mokotów

             new Estate { Id = 14, Name = "Okęcie", Sanitize = "okecie", District = DistrictProvider.Get(7) }, // Ochota
             new Estate { Id = 15, Name = "Szczęśliwice", Sanitize = "szczesliwice", District = DistrictProvider.Get(7) }, // Ochota
             new Estate { Id = 16, Name = "Rakowiec", Sanitize = "rakowiec", District = DistrictProvider.Get(7) }, // Ochota

             new Estate { Id = 17, Name = "Grochów", Sanitize = "grochow", District = DistrictProvider.Get(15) }, // Praga Południe
             new Estate { Id = 18, Name = "Gocław", Sanitize = "goclaw", District = DistrictProvider.Get(15) }, // Praga Południe
             new Estate { Id = 19, Name = "Gocławek", Sanitize = "goclawek", District = DistrictProvider.Get(15) }, // Praga Południe
             new Estate { Id = 20, Name = "Saska Kępa", Sanitize = "saska kepa", District = DistrictProvider.Get(15) }, // Praga Południe

             new Estate { Id = 21, Name = "Żerań", Sanitize = "zeran", District = DistrictProvider.Get(14) }, // Praga Północ
             new Estate { Id = 22, Name = "Szmulki", Sanitize = "szmulki", District = DistrictProvider.Get(14) }, // Praga Północ

             new Estate { Id = 23, Name = "Stary Rembertów", Sanitize = "stary rembertow", District = DistrictProvider.Get(13) }, // Rembertów

             new Estate { Id = 24, Name = "Centrum", Sanitize = "centrum", District = DistrictProvider.Get(12) }, // Śródmieście
             new Estate { Id = 25, Name = "Starówka", Sanitize = "starowka", District = DistrictProvider.Get(12) }, // Śródmieście
             new Estate { Id = 26, Name = "Powiśle", Sanitize = "powisle", District = DistrictProvider.Get(12) }, // Śródmieście
             new Estate { Id = 27, Name = "Stare miasto", Sanitize = "stare miasto", District = DistrictProvider.Get(12) }, // Śródmieście
             new Estate { Id = 28, Name = "Nowe miasto", Sanitize = "nowe miasto", District = DistrictProvider.Get(12) }, // Śródmieście
             new Estate { Id = 29, Name = "Muranów", Sanitize = "muranów", District = DistrictProvider.Get(12) }, // Śródmieście
             new Estate { Id = 30, Name = "Czerniaków", Sanitize = "czerniakow", District = DistrictProvider.Get(12) }, // Śródmieście
             new Estate { Id = 31, Name = "Nowolipki", Sanitize = "nowolipki", District = DistrictProvider.Get(12) }, // Śródmieście
             new Estate { Id = 32, Name = "Pańska", Sanitize = "panska", District = DistrictProvider.Get(12) }, // Śródmieście

             new Estate { Id = 33, Name = "Bródno", Sanitize = "brodno", District = DistrictProvider.Get(59) }, // Targówek
             new Estate { Id = 34, Name = "Zacisze", Sanitize = "zacisze", District = DistrictProvider.Get(59) }, // Targówek

             new Estate { Id = 35, Name = "Niedźwiadek", Sanitize = "niedzwiadek", District = DistrictProvider.Get(11) }, // Ursus
             new Estate { Id = 36, Name = "Gołąbki", Sanitize = "golabki", District = DistrictProvider.Get(11) }, // Ursus
             new Estate { Id = 37, Name = "Michałowicza", Sanitize = "michalowicza", District = DistrictProvider.Get(11) }, // Ursus

             new Estate { Id = 38, Name = "Kabaty", Sanitize = "kabaty", District = DistrictProvider.Get(10) }, // Ursynów
             new Estate { Id = 39, Name = "Imielin", Sanitize = "imielin", District = DistrictProvider.Get(10) }, // Ursynów
             new Estate { Id = 40, Name = "Natolin", Sanitize = "natolin", District = DistrictProvider.Get(10) }, // Ursynów
             new Estate { Id = 41, Name = "Stokłosy", Sanitize = "stoklosy", District = DistrictProvider.Get(10) }, // Ursynów
             new Estate { Id = 42, Name = "Wierzbno", Sanitize = "wierzbno", District = DistrictProvider.Get(10) }, // Ursynów
             new Estate { Id = 43, Name = "Dąbrówka", Sanitize = "dabrowka", District = DistrictProvider.Get(10) }, // Ursynów
             new Estate { Id = 44, Name = "Grabów", Sanitize = "grabow", District = DistrictProvider.Get(10) }, // Ursynów
             new Estate { Id = 45, Name = "Pyry", Sanitize = "pyry", District = DistrictProvider.Get(10) }, // Ursynów

             new Estate { Id = 46, Name = "Anin", Sanitize = "anin", District = DistrictProvider.Get(16) }, // Wawer
             new Estate { Id = 47, Name = "Międzylesie", Sanitize = "miedzylesie", District = DistrictProvider.Get(16) }, // Wawer
             new Estate { Id = 48, Name = "Falenica", Sanitize = "falenica", District = DistrictProvider.Get(16) }, // Wawer
             new Estate { Id = 49, Name = "Marysin", Sanitize = "marysin", District = DistrictProvider.Get(16) }, // Wawer
             new Estate { Id = 50, Name = "Radość", Sanitize = "radosc", District = DistrictProvider.Get(16) }, // Wawer

             new Estate { Id = 51, Name = "Powsin", Sanitize = "powsin", District = DistrictProvider.Get(9) }, // Wilanów

             new Estate { Id = 52, Name = "Koło", Sanitize = "kolo", District = DistrictProvider.Get(6) }, // Wola
             new Estate { Id = 53, Name = "Moczydło", Sanitize = "moczydlo", District = DistrictProvider.Get(6) }, // Wola
             new Estate { Id = 54, Name = "Młynów", Sanitize = "mlynow", District = DistrictProvider.Get(6) }, // Wola

             new Estate { Id = 55, Name = "Chomiczówka", Sanitize = "chomiczowka", District = DistrictProvider.Get(3) }, // Żoliborz
             new Estate { Id = 56, Name = "Piaski", Sanitize = "piaski", District = DistrictProvider.Get(3) }, // Żoliborz
             new Estate { Id = 57, Name = "Sady Żoliborskie", Sanitize = "sady zoliborskie", District = DistrictProvider.Get(3) }, // Żoliborz
             new Estate { Id = 58, Name = "Wrzeciono", Sanitize = "wrzeciono", District = DistrictProvider.Get(3) }, // Żoliborz
             new Estate { Id = 59, Name = "Marymont", Sanitize = "marymont", District = DistrictProvider.Get(3) }, // Żoliborz
        };


    }
}
