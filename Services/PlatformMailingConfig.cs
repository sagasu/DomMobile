// -----------------------------------------------------------------------
// <copyright file="PlatformMailingConfig.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Services
{
    using System;

    using Trader.Platform.Mailing;

    ///// <summary>
    ///// So other project do not need to implement Trader.Mailing and it's dependencies
    ///// </summary>
    public interface IPlatformMailingConfigFacade : IPlatformMailingConfig
    {
        string DefaultEmailSubject { get; }
    }

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class PlatformMailingConfig : IPlatformMailingConfigFacade
    {
        private readonly IConfigurationService _configurationService;

        public PlatformMailingConfig(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        public string GetIncludePath(string filePath)
        {
            throw new NotImplementedException();
        }

        public string DefaultSmtpServer
        {
            get
            {
                return null;
            }
        }

        public string MailingQueueConnectionString
        {
            get
            {
                return _configurationService.GetConfiguration(x => x.MailingQueue);
            }
        }

        public bool IsDevServer
        {
            get
            {
                // I use double negation, because it is safer to check against 'false' string value then against 'true'
                return !_configurationService.GetConfiguration(x => x.IsDevServer).ToLower().Equals("false");
            }
        }

        public string ServiceName
        {
            get
            {
                return "MobileDomiporta";
            }
        }

        public string DefaultSenderName
        {
            get
            {
                return _configurationService.GetConfiguration(x => x.DefaultSenderName);
            }
        }

        public string DefaultSenderEmail
        {
            get
            {
                return _configurationService.GetConfiguration(x => x.DefaultSenderEmail);
            }
        }

        public string DefaultProcedureName
        {
            get
            {
                return "SendEmail";
            }
        }

        public string DefaultEmailSubject
        {
            get
            {
                return _configurationService.GetConfiguration(x => x.DefaultEmailSubject);
            }
        }
    }
}
