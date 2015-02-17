// -----------------------------------------------------------------------
// <copyright file="Poviat.cs" company="Agora SA">
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
    public class Poviat : AbstractGlossary<Poviat>, IKeptInCodeGlossary<Poviat>
    {
        public virtual Province Province { get; set; }

        public virtual string Capital { get; set; }

        public string Sanitize { get; set; }

        public override IEnumerable<Poviat> GetValues()
        {
            return new PoviatProvider().GetValues();
        }
    }
}
