namespace Trader.Web.Extensions
{
    using System.Linq;
    using System.Web.Mvc;

    public static class ModelStateExtensions
    {
        /// <summary>
        /// Tries to extract first error message from modelState
        /// </summary>
        /// <param name="modelState"></param>
        /// <param name="defaultErrorMessage"></param>
        /// <returns></returns>
        public static string ExtractErrorMessage(this ModelStateDictionary modelState, string defaultErrorMessage = "Formularz zawiera nieprawidłowe dane.")
        {
            if (!modelState.IsValid)
            {
                return modelState.Values.Where(x => x.Errors.Count > 0).First().Errors.First().ErrorMessage;
            }

            return defaultErrorMessage;
        }
    }
}