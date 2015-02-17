namespace Trader.Web.Controllers
{
    using System;
    using System.Web.Mvc;

    using Ninject.Extensions.Logging;

    using Trader.AdvertUrlService;
    using Trader.Model.Common;
    using Trader.Services;
    using Trader.Web.Attributes;
    using Trader.Web.Helpers;

    public partial class EmailController : BaseContoller
    {
        private const string ErrorSendingEmail = "Nastąpił błąd przetwarzania danych. Spróbuj ponownie później.";

        private const string CantSendEmail = "Nie udało się wysłąć maila. Spróbuj ponownie później.";

        private const string EmailSend = "Wysłano wiadomość.";

        private readonly IEmailService _emailService;

        private readonly ISolrService _solrService;

        private readonly IConfigurationService _configurationService;

        private readonly IDbService _dbService;

        public EmailController(
            ILogger logger,
            IEmailService emailService,
            ISolrService solrService,
            IConfigurationService configurationService,
            IDbService dbService)
            : base(logger)
        {
            this._dbService = dbService;
            this._configurationService = configurationService;
            this._solrService = solrService;
            this._emailService = emailService;
        }

        [SimpleValidation]
        public virtual ActionResult SendEmail(EmailViewModel emailViewModel)
        {
            try
            {
                return TrySendEmail(emailViewModel);
            }
            catch (Exception e)
            {
                this.Logger.Error(e.Message);
                return JsonMessage(JsonMessageEnum.Error, ErrorSendingEmail);
            }
        }

        private ActionResult TrySendEmail(EmailViewModel emailViewModel)
        {
            // Get email from SOLR by Id
            var advertViewModel = AdvertHelper.GetViewModelByAdvertId(emailViewModel.AdvertId, _solrService, _dbService);
            emailViewModel.DestinationEmail = advertViewModel.UserViewModel.Email.DestinationEmail;
            emailViewModel.UrlToSimpleDetails = 
                string.Concat(_configurationService.GetConfiguration(x => x.WebUrl), 
                              string.Format(_configurationService.GetConfiguration(x => x.FullPortalDetailsPage),
                                            advertViewModel.CategoryId, advertViewModel.Id));

            var responseMessage = _emailService.SendEmail(emailViewModel);

            if (!string.IsNullOrEmpty(responseMessage))
            {
                return this.JsonMessage(JsonMessageEnum.Error, CantSendEmail);
            }

            return this.JsonMessage(JsonMessageEnum.Success, EmailSend);
        }
    }
}