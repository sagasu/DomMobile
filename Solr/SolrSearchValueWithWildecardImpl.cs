// -----------------------------------------------------------------------
// <copyright file="ValueWithWildecard.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Linq;
using Trader.Model.Glossaries.Providers;
using Trader.Common;
using Trader.Model.Solr;
using Trader.Services;

namespace Trader.Solr
{
    public class SolrSearchCity : SolrSearchValueWithWildecard
    {
        public SolrSearchCity(string value) : base(value)
        {
        }

        public override string AdditionalCorrection(string key)
        {
            // Correct typical spelling errors - usually dealing with polish characters
            var trimmedLowerCity = CorrectionHelper.Correct(Value.Trim().ToLower());

            var dFormCity = new DiacriticService().RemoveDiacriticsAndCastToLower(trimmedLowerCity);

            // This correction may be good, or bad, we are not sure if a user is looking for Biała or he spelled it correctly entering Biala
            // This is why in this case we search for both cities in addition with wildecard
            var correctKnownCities = CommunityProvider.Communities.FirstOrDefault(x => x.Sanitize.Equals(dFormCity, StringComparison.OrdinalIgnoreCase));

            if (correctKnownCities != null && !correctKnownCities.Name.Equals(trimmedLowerCity, StringComparison.OrdinalIgnoreCase))
            {
                return string.Format(FormatWithCorrection, key,
                    trimmedLowerCity, string.Concat(trimmedLowerCity, Wildecard),
                    correctKnownCities.Name, string.Concat(correctKnownCities.Name, Wildecard));
            }

            return string.Format(Format, key, trimmedLowerCity, string.Concat(trimmedLowerCity, Wildecard));
        }
    }

    public class SolrSearchDistrict : SolrSearchValueWithWildecard
    {
        public SolrSearchDistrict(string value)
            : base(value)
        {
        }

        public override string AdditionalCorrection(string key)
        {
            var trimedToLowerDistrict = Value.Trim().ToLower();

            var dFormDistrict = new DiacriticService().RemoveDiacriticsAndCastToLower(trimedToLowerDistrict);

            // Sometimes people place estate instead of a district, correct it to a proper district then, but also search for a placed value, just in case
            var correctedEstate = EstateProvider.Estates.FirstOrDefault(
                x => x.Sanitize.Equals(dFormDistrict, StringComparison.OrdinalIgnoreCase));

            if(correctedEstate != null)
            {
                return string.Format(FormatWithCorrection, key,
                    trimedToLowerDistrict, string.Concat(trimedToLowerDistrict, Wildecard),
                    correctedEstate.District.Name, string.Concat(correctedEstate.District.Name, Wildecard));
            }

            // This correction may be good, or bad, we are not sure if a user is looking for Śródmieście or he spelled it correctly entering Srodmiescie
            // This is why in this case we search for both districts in addition with wildecard
            var correctedDistrict = DistrictProvider.Districts.FirstOrDefault(x => x.SanitizedDistrict.Equals(dFormDistrict, StringComparison.OrdinalIgnoreCase));

            if (correctedDistrict != null && !correctedDistrict.Name.Equals(trimedToLowerDistrict, StringComparison.OrdinalIgnoreCase))
            {
                return string.Format(FormatWithCorrection, key,
                    trimedToLowerDistrict, string.Concat(trimedToLowerDistrict, Wildecard),
                    correctedDistrict.Name, string.Concat(correctedDistrict.Name, Wildecard));
            }

            return string.Format(Format, key, trimedToLowerDistrict, string.Concat(trimedToLowerDistrict, Wildecard));
        }
    }
}
