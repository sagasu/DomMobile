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
    public class LandType : AbstractGlossary<LandType>, IKeptInCodeGlossaryWSanitize<LandType>
    {
        public string Sanitize { get; set; }

        public override IEnumerable<LandType> GetValues()
        {
            return new LandTypeProvider().GetValues();
        }
    }
}
