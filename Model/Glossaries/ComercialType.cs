// -----------------------------------------------------------------------
// <copyright file="LandType.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Model.Glossaries
{
    using System.Collections.Generic;

    using Trader.Model.Glossaries.Providers;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class ComercialType : AbstractGlossary<ComercialType>, IKeptInCodeGlossaryWSanitize<ComercialType>
    {
        /// <summary>
        /// I took this value from old domiporta service
        /// When quering solr this value will be used
        /// </summary>
        public string Sanitize { get; set; }

        public override IEnumerable<ComercialType> GetValues()
        {
            return new ComercialTypeProvider().GetValues();
        }
    }
}
