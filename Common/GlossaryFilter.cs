namespace Trader.Common
{
    using System;
    using System.Collections.Generic;

    using Trader.Common.Attributes;

    public class GlossaryFilter<T> where T : struct 
    {
        public IEnumerable<T> FilteredElements { get; set; }

        public IEnumerable<T> OptionalFilteredElements { get; set; }

        [StaticReflection]
        public Nullable<T> SelectedValue { get; set; }
    }
}