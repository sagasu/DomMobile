// -----------------------------------------------------------------------
// <copyright file="DiacriticService.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Services
{
    using System.Text;
    using System.Text.RegularExpressions;

    public interface IDiacriticService
    {
        string RemoveDiacriticsAndCastToLower(string text);
    }

    public class DiacriticService : IDiacriticService
    {
        private readonly static Regex NonSpacingMarkRegex = new Regex(@"\p{Mn}", RegexOptions.Compiled);

        public string RemoveDiacriticsAndCastToLower(string text)
        {
            if (text == null)
                return string.Empty;

            var normalizedText =
                text.ToLower().Normalize(NormalizationForm.FormD);

            // For some reason ł is not replaced to l, so I do it manually
            return NonSpacingMarkRegex.Replace(normalizedText, string.Empty).Replace("ł","l");
        }
    }
}
