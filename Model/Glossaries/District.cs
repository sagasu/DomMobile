// -----------------------------------------------------------------------
// <copyright file="District.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Model.Glossaries
{
    using System.Collections.Generic;

    using Trader.Model.Glossaries.Providers;

    /// <summary>
    /// Structure of a district and a data of districts taken from Trader db, Table name: Dzielnice
    /// </summary>
    public class District : AbstractGlossary<District>, IKeptInCodeGlossary<District>
    {
        public string City { get; set; }

        public string CorrectedCity { get; set; }

        public string CorrectedDistrict { get; set; }

        public int ToBeDeleted { get; set; }

        public int AllAdsId { get; set; }

        public string Sanitize { get; set; }

        public string SanitizedDistrict { get; set; }

        public override IEnumerable<District> GetValues()
        {
            return new DistrictProvider().GetValues();
        }
    }
}
