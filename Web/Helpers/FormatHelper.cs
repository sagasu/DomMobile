namespace Trader.Web.Helpers
{
    public static class FormatHelper
    {
        public const string DefaultFormat = "### ### ### ### ### ###";

        /// <summary>
        /// This is done to force IPhone not to treat it as a telephone number (there need to be some character between numbers)
        /// </summary>
        public const string DefaultDecimalFormat = "<span class=\"decimalNumber\">###</span> <span class=\"decimalNumber\">###</span> <span class=\"decimalNumber\">###</span> <span class=\"decimalNumber\">###</span> <span class=\"decimalNumber\">###</span> <span class=\"decimalNumber\">###</span>";

        private const string NoNumberBetweenFormating = "<span class=\"decimalNumber\"></span>";

        public static string FormatInt(int i)
        {
            return i.ToString(DefaultFormat);
        }

        public static string FormatDecimal(decimal d)
        {
            // Unfortunately RazorEngine is not thread safe, so I don't use it to get rid of html from const: RazorEngine.Razor.Parse(Configuration.SendWelcomeMailTemplateName, model);
            return decimal.Round(d, 0).ToString(DefaultDecimalFormat).Replace(NoNumberBetweenFormating, string.Empty);
        }
    }
}