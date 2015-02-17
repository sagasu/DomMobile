// -----------------------------------------------------------------------
// <copyright file="EmailService.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Services
{
    using System.Collections.Generic;
    using System.Net.Mail;

    using Trader.Model.Common;
    using Trader.Platform.Mailing;

    public interface IEmailService
    {
        string SendEmail(EmailViewModel email);
    }

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class EmailService : IEmailService
    {
        private readonly IPlatformMailingConfigFacade _platformMailingConfig;

        public EmailService(IPlatformMailingConfigFacade platformMailingConfig)
        {
            _platformMailingConfig = platformMailingConfig;
        }

        public string SendEmail(EmailViewModel email)
        {
            var message = new EmailUtils(_platformMailingConfig).SendEmail(
                new EmailMessage
                    {
                        BodyAsHtml = string.Format(EmailBase, email.UrlToSimpleDetails, email.BodyAsHtml),
                        Subject = _platformMailingConfig.DefaultEmailSubject,
                        Recipients = new List<string> { email.DestinationEmail },
                        SenderEmail = email.SenderEmail, // Unfortunately EmailUtils is so bad that it doesn't map it :)
                        SenderName = email.SenderEmail, // Unfortunately EmailUtils is so bad that it doesn't map it :)
                        Priority = MailPriority.Normal
                    });
            return message;
        }

        private const string EmailBase = @"Wiadomość dotyczy ogłoszenia: {0}<br/>Treść wiadomości:<br/>{1}<br/>";
    }
}
