// -----------------------------------------------------------------------
// <copyright file="Community.cs" company="Agora SA">
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
    public class Community : AbstractGlossary<Community>, IKeptInCodeGlossary<Community>
    {
        public int? Capital { get; set; }

        public string Sanitize { get; set; }

        public Poviat Poviat { get; set; }

        public bool AsLocal { get; set; }

        public override IEnumerable<Community> GetValues()
        {
            return new CommunityProvider().GetValues();
        }
    }
}
