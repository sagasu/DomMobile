namespace Trader.Web.Controllers
{
    using System;
    using System.Web.Mvc;

    using Trader.Model.Glossaries.Providers;
    using Trader.Model.Solr;
    using Trader.Services;

    /// <summary>
    /// View DI is considered a bad practice, so it is encapsulated inside a controller
    /// If you ever want to use a service inside a view, use this class
    /// </summary>
    public partial class ServiceController : Controller
    {
        private readonly IConfigurationService _configurationService;

        private readonly IDateTimeService _dateTimeService;

        private readonly ISolrService _solrService;

        public ServiceController(
            IConfigurationService configurationService,
            IDateTimeService dateTimeService,
            ISolrService solrService)
        {
            this._solrService = solrService;
            this._dateTimeService = dateTimeService;
            this._configurationService = configurationService;
        }

        public string GetWebUrl()
        {
            return this._configurationService.GetConfiguration(x => x.WebUrl);
        }

        public DateTime GetDateTime()
        {
            return this._dateTimeService.GetDateTime();
        }

        /// <summary>
        /// Admins call this action, from time to time, to check if this application is responsive
        /// This action needs to call SOLR, to check if SOLR is responsive.
        /// </summary>
        /// <returns></returns>
        public virtual ActionResult PingCheckSolr()
        {
            _solrService.Search(new SolrAdvertDto { TransactionType = TransactionTypeProvider.SellId });

            return this.View();
        }
    }
}