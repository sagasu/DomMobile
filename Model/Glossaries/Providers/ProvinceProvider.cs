// -----------------------------------------------------------------------
// <copyright file="ProvinceProvider.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Model.Glossaries.Providers
{
    using System.Collections.Generic;
    using System.Linq;

    public  class ProvinceProvider : IGlossaryProvider<Province>
    {
        public IEnumerable<Province> GetValues()
        {
            return provinces;
        }

        // Solr keeps polish names for this field
        private static readonly IEnumerable<Province> provinces = new List<Province>{
            new Province { Id = 1, Name = "Dolnośląskie", RelativeFor = "20000,13130,133,31572,13130,0", Country = CountryProvider.Get(20), Sanitize = "Dolnośląskie" },
            // KujawskoPoomorskie Sanitize property is concatenated so SOLR can see a difference between Kujawsko-Pomorskie and Pomorskie.
            new Province { Id = 2, Name = "Kujawsko-pomorskie", RelativeFor = "20000,13130,133,31572,0", Country = CountryProvider.Get(20), Sanitize = "Kujawskopomorskie" },
            new Province { Id = 3, Name = "Lubelskie", RelativeFor = "20000,13130,133,31572,0", Country = CountryProvider.Get(20), Sanitize = "Lubelskie" },
            new Province { Id = 4, Name = "Lubuskie", RelativeFor = "20000,13130,133,31572,0", Country = CountryProvider.Get(20), Sanitize = "Lubuskie" },
            new Province { Id = 5, Name = "Łódzkie", RelativeFor = "20000,13130,133,31572,0", Country = CountryProvider.Get(20), Sanitize = "Łódzkie" },
            new Province { Id = 6, Name = "Małopolskie", RelativeFor = "20000,13130,133,31572,0", Country = CountryProvider.Get(20), Sanitize = "Małopolskie" },
            new Province { Id = 7, Name = "Mazowieckie", RelativeFor = "20000,13130,133,31572,0", Country = CountryProvider.Get(20), Sanitize = "Mazowieckie" },
            new Province { Id = 8, Name = "Opolskie", RelativeFor = "20000,13130,133,31572,0", Country = CountryProvider.Get(20), Sanitize = "Opolskie" },
            new Province { Id = 9, Name = "Podkarpackie", RelativeFor = "20000,13130,133,31572,0", Country = CountryProvider.Get(20), Sanitize = "Podkarpackie" },
            new Province { Id = 10, Name = "Podlaskie", RelativeFor = "20000,13130,133,31572,0", Country = CountryProvider.Get(20), Sanitize = "Podlaskie" },
            new Province { Id = 11, Name = "Pomorskie", RelativeFor = "20000,13130,133,31572,0", Country = CountryProvider.Get(20), Sanitize = "Pomorskie" },
            new Province { Id = 12, Name = "Śląskie", RelativeFor = "20000,13130,133,31572,0", Country = CountryProvider.Get(20), Sanitize = "Śląskie" },
            new Province { Id = 13, Name = "Świętokrzyskie", RelativeFor = "20000,13130,133,31572,0", Country = CountryProvider.Get(20), Sanitize = "Świętokrzyskie" },
            new Province { Id = 14, Name = "Warmińsko-mazurskie", RelativeFor = "20000,13130,133,31572,0", Country = CountryProvider.Get(20), Sanitize = "Warmińsko-mazurskie" },
            new Province { Id = 15, Name = "Wielkopolskie", RelativeFor = "20000,13130,133,31572,0", Country = CountryProvider.Get(20), Sanitize = "Wielkopolskie" },
            new Province { Id = 16, Name = "Zachodniopomorskie", RelativeFor = "20000,13130,133,31572,0", Country = CountryProvider.Get(20), Sanitize = "Zachodniopomorskie" }
        };

        public static IEnumerable<Province> Provinces
        {
            get { return provinces; }
        }

        internal static Province Get(int id)
        {
            return provinces.SingleOrDefault(x => x.Id == id);
        }
    }
}
