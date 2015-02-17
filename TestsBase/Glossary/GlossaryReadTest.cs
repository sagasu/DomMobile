// -----------------------------------------------------------------------
// <copyright file="GlossaryReadTest.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.TestsBase.Glossary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    using Xunit;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class GlossaryReadTest
    {
        private const string SpecificMatchPatternBase = ", Name =\"";
        private const string GeneralMatchPattern = SpecificMatchPatternBase + @"[A-Z|Ś|Ó|Ź|Ż|Ł|Ć|Ę|Ń|Ą|a-z|ą|ń|ę|ć|ł|ż|ź|ó|ś|\-|_|/.| ]+";
        private const string SpecificMatchPattern = @"[A-Z|Ś|Ó|Ź|Ż|Ł|Ć|Ę|Ń|Ą|a-z|ą|ń|ę|ć|ł|ż|ź|ó|ś|\-|_|/.| ]+";


        private readonly static Regex NonSpacingMarkRegex = new Regex(@"\p{Mn}", RegexOptions.Compiled);

        public string RemoveDiacriticsAndCastToLower(string text)
        {
            if (text == null)
                return string.Empty;

            var normalizedText =
                text.ToLower().Normalize(NormalizationForm.FormD);

            // For some reason ł is not replaced to l, so I do it manually
            return NonSpacingMarkRegex.Replace(normalizedText, string.Empty).Replace("ł", "l");
        }

        [Fact]
        public void ReadFromFile()
        {
            var fileWithNewIds = new List<string>();
            string[] lines = System.IO.File.ReadAllLines("Glossary\\Glossary.txt");

            var generalMatch = new Regex(GeneralMatchPattern, RegexOptions.IgnoreCase);
            var specificMatch = new Regex(SpecificMatchPattern, RegexOptions.IgnoreCase);

            var index = 1; // This is for id generation

            foreach (var line in lines.Where(x => x.StartsWith("                    new District")))
            {
                // First extract a more general string from a line of a file, then extract an Id from it.
                var genMatch = generalMatch.Match(line).Value.Replace(SpecificMatchPatternBase, "");
                var specMatch = specificMatch.Match(genMatch);

                if (specMatch.Success)
                {

                    Console.WriteLine(genMatch);
                    //var oldIdValue = int.Parse(oldId.Value);
                    fileWithNewIds.Add(generalMatch.Replace(line, SpecificMatchPatternBase + specMatch.Value + "\", SanitizedDistrict = \"" + RemoveDiacriticsAndCastToLower(specMatch.Value)));
                }

                index++;
            }

            foreach (var newLine in fileWithNewIds)
            {
                Console.WriteLine(newLine);
            }
        }
    }
}
