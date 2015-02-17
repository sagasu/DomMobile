// -----------------------------------------------------------------------
// <copyright file="Province.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Model.Glossaries
{
    using System.Collections.Generic;

    using Trader.Model.Glossaries.Providers;

    public class Province : AbstractGlossary<Province>, IKeptInCodeGlossaryWSanitize<Province>
    {
        public virtual string RelativeFor { get; set; }

        /// <summary>
        /// Solr keeps polish names for this field, so this Sanitize is more SOLR value - a value that is used to query SOLR.
        /// </summary>
        public virtual string Sanitize { get; set; }

        public Country Country { get; set; }

        public override IEnumerable<Province> GetValues()
        {
            return new ProvinceProvider().GetValues();
        }
    }
}
