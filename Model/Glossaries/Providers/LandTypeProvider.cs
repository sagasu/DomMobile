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
    public class LandTypeProvider : IGlossaryProvider<LandType>
    {
        public static IEnumerable<LandType> LandTypes { 
            get { return landTypes; }
        }

        private static readonly IEnumerable<LandType> landTypes = new List<LandType>
            {
                new LandType { Id = 1, Name = "budowlana", Sanitize = "budowlana"},
                new LandType { Id = 2, Name = "gospodarstwo rolne", Sanitize = "gospodarstwo rolne"},
                new LandType { Id = 3, Name = "inwestycyjna", Sanitize = "inwestycyjna" },
                new LandType { Id = 4, Name = "komercyjna", Sanitize = "komercyjna" },
                new LandType { Id = 5, Name = "leśna", Sanitize = "leśna" },
                new LandType { Id = 6, Name = "leśna z prawem budowy", Sanitize = "leśna z prawem budowy" },
                new LandType { Id = 7, Name = "przemysłowo-handlowa", Sanitize = "przemysłowo-handlowa" },
                new LandType { Id = 8, Name = "rekreacyjna", Sanitize = "rekreacyjna" },
                new LandType { Id = 9, Name = "rolna", Sanitize = "rolna" },
                new LandType { Id = 10, Name = "siedliskowa", Sanitize = "siedliskowa" },
                
            };

        public IEnumerable<LandType> GetValues()
        {
            return landTypes;
        }
    }
}
