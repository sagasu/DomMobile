using System;

namespace Trader.Web.Controllers
{
    using System.Web.Mvc;

    using Trader.Services;

    public partial class CityController : Controller
    {
        private readonly ICityProvider _cityProvider;

        public CityController(ICityProvider cityProvider)
        {
            this._cityProvider = cityProvider;
        }

        /// <summary>
        /// This action is triggered by automa
        /// Do not modify it if you dont change automa
        /// Exception handling is done in a way to fit well in an automa system.
        /// </summary>
        /// <returns></returns>
        public string RebuildCashedResults()
        {
            try
            {
                _cityProvider.RebuildCashedResults();
            }
            catch (Exception e)
            {
                return string.Format("<font color='Red'>Error when rebuilding city list: {0}</font>", e.Message);
            }

            return "Ok";
        }
    }
}