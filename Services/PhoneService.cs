// -----------------------------------------------------------------------
// <copyright file="PhoneService.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Services
{
    using ImportProcedures;

    public interface IPhoneService
    {
        /// <summary>
        /// In AllAds db number is kept in different formats, this method tryies to extract an usefull number.
        /// </summary>
        /// <param name="number">Dirty data number.</param>
        /// <returns>A phone number extracted.</returns>
        string GetNumber(string number);
    }

    /// <summary>
    /// Common phone tasks.
    /// </summary>
    public class PhoneService : IPhoneService
    {
        public string GetNumber(string number)
        {
            if (string.IsNullOrEmpty(number))
            {
                return number;
            }

            // This method is taken from a code that was written by Import people (Marcin Krawczyk). He modifies it from time to time.
            // Let's try to keep one version of a libriary to clean phone from AllAds.
            var phone = Phone.GetPhoneData(number);
            return string.Concat("+",phone.CountryCallingCode, phone.AreaCode, phone.Number);
        }
    }
}
