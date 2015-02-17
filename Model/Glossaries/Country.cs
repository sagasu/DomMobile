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
    /// TODO: Update summary.
    /// </summary>
    public class Country : AbstractGlossary<Country>, IKeptInCodeGlossary<Country>
    {
        public virtual string RelativeFor { get; set; }

        public virtual string Sanitize { get; set; }

        public override IEnumerable<Country> GetValues()
        {
            return new CountryProvider().GetValues();
        }
    }
}
