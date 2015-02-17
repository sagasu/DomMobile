// -----------------------------------------------------------------------
// <copyright file="RangeCriteria.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Common
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using Trader.Common.Attributes;

    public class RangeCriteria : ISolrMap
    {
        private const string DefaultFromValue = "*";
        private const string DefaultToValue = "*";

        private const string Format = "{0}:[{1} TO {2}]";

        public RangeCriteria(){}

        public RangeCriteria(int? from, int? to)
        {
            if (from.HasValue)
            {
                From = new GlossaryFilter<int> { SelectedValue = from };
            }

            if (to.HasValue)
            {
                To = new GlossaryFilter<int> { SelectedValue = to };
            }
        }

        [DisplayName("Od")]
        [UIHint("GlossaryFilter")]
        [StaticReflection]
        public GlossaryFilter<int> From { get; set; }

        [DisplayName("Do")]
        [UIHint("GlossaryFilter")]
        [StaticReflection]
        public GlossaryFilter<int> To { get; set; }

        public string Map(string key)
        {
            if (From != null && From.SelectedValue.HasValue)
            {
                if (To != null && To.SelectedValue.HasValue)
                {
                    // Unfortunately QueryRange from solrNet requires to send both from, to. And if From is set to 0, it will not find null values in db
                    // That's why I use QuerySimple - this way I can use * wildecard
                    return string.Format(
                        Format, key, From.SelectedValue.Value, To.SelectedValue.Value);
                }

                return string.Format(Format, key, From.SelectedValue.Value, DefaultToValue);
            }

            if (To != null && To.SelectedValue.HasValue)
            {
                return string.Format(Format, key, DefaultFromValue, To.SelectedValue.Value);
            }

            return null;
        }
    }
}
