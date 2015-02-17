// -----------------------------------------------------------------------
// <copyright file="Country.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Model.Glossaries
{
    using System.Collections.Generic;

    using Trader.Model.Glossaries.Providers;

    /// <summary>
    /// Osiedle
    /// </summary>
    public class Estate : AbstractGlossary<Estate>, IKeptInCodeGlossary<Estate>
    {
        public virtual string Sanitize { get; set; }

        public District District { get; set; }

        public override IEnumerable<Estate> GetValues()
        {
            return new EstateProvider().GetValues();
        }
    }
}
