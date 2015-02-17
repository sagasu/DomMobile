namespace Trader.Web.Validators
{
    using System.Linq;

    using Trader.Common;

    public static class CommonValidatorHelper
    {
        public static bool IsValidRangeCriteria(RangeCriteria rangeCriteria)
        {
            if ((rangeCriteria == null) || (rangeCriteria.From == null) || (rangeCriteria.To == null))
            {
                return true;
            }

            if (rangeCriteria.From.SelectedValue.HasValue && rangeCriteria.To.SelectedValue.HasValue)
            {
                return rangeCriteria.From.SelectedValue.Value <= rangeCriteria.To.SelectedValue.Value;
            }

            return true;
        }

        public static bool IsNonNegative(RangeCriteria rangeCriteria)
        {
            if (rangeCriteria == null)
            {
                return true;
            }

            return IsNonNegative(rangeCriteria.From) && IsNonNegative(rangeCriteria.To);
        }

        private static bool IsNonNegative(GlossaryFilter<int> glossaryFilter)
        {
            return glossaryFilter == null || IsNonNegative(glossaryFilter.SelectedValue);
        }

        private static bool IsNonNegative(int? i)
        {
            if (i.HasValue)
            {
                return i.Value >= 0;
            }

            return true;
        }

        public static readonly string[] InvalidStrings = new[] { "!", "^", "*", "(", ")", "+", "?", ":", "\"", "[", "]", "{", "}" };

        public static bool IsValidStringInput(string s)
        {
            if(string.IsNullOrEmpty(s)) return true;

            return !InvalidStrings.Any(x => s.Contains(x));
        }

        public static bool IsNotStartWithMinus(string s)
        {
            if (string.IsNullOrEmpty(s)) return true;

            return !s.StartsWith("-");
        }
    }
}