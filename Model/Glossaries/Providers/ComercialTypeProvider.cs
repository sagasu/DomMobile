// -----------------------------------------------------------------------
// <copyright file="LandTypeProvider.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Model.Glossaries.Providers
{
    using System.Collections.Generic;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class ComercialTypeProvider : IGlossaryProvider<ComercialType>
    {
        public static IEnumerable<ComercialType> ComecrialType
        {
            get { return comecrialType; }
        }

        private static readonly IEnumerable<ComercialType> comecrialType = new List<ComercialType>
            {
                // Those Id's are local only, they do not exist in different systems
                // When query is created Sanitize value is used
                new ComercialType { Id = 1, Name = "Biuro", Sanitize = "biuro"},
                new ComercialType { Id = 2, Name = "Magazyn", Sanitize = "magazyn" },
                new ComercialType { Id = 3, Name = "Usługi", Sanitize = "usługi" },
                new ComercialType { Id = 4, Name = "Handel", Sanitize = "handel" },
                new ComercialType { Id = 5, Name = "Gastronomia", Sanitize = "gastronomia" },
                new ComercialType { Id = 6, Name = "Gabinet", Sanitize = "gabinet" },
                new ComercialType { Id = 7, Name = "Warsztat", Sanitize = "warsztat" },
                new ComercialType { Id = 8, Name = "Pawilon", Sanitize = "pawilon" },
                new ComercialType { Id = 9, Name = "Hala", Sanitize = "hala" },
                new ComercialType { Id = 10, Name = "Centrum dystrybucyjne", Sanitize = "centrum dystrybucyjne" },
                new ComercialType { Id = 11, Name = "Centrum handlowe", Sanitize = "centrum handlowe" },
                new ComercialType { Id = 12, Name = "Hotel-pensjonat", Sanitize = "hotel-pensjonat" },
                new ComercialType { Id = 13, Name = "Produkcja", Sanitize = "produkcja" },
                new ComercialType { Id = 14, Name = "Inne", Sanitize = "inne" }
            };

        public IEnumerable<ComercialType> GetValues()
        {
            return comecrialType;
        }
    }
}
