namespace Trader.Model.Common
{
    using System;

    using Trader.Common.Attributes;

    public class EmailViewModel
    {
        private const string DefaultBody = "Jestem zainteresowany ofertą, znalezioną w serwisie Domiporta.pl.";

        public EmailViewModel()
        {
            BodyAsHtml = DefaultBody;
        }

        /// <summary>
        /// To check if Email template is going to be displayed
        /// </summary>
        public bool IsDestinationEmailValid { get; set; }

        /// <summary>
        /// It is not showed, it is set from SOLR after send email action is triggered
        /// </summary>
        public string DestinationEmail { get; set; }

        /// <summary>
        /// Displayed as hidden in form, base on it SOLR query to a database is held and destination email is choosen.
        /// </summary>
        [StaticReflection]
        public string AdvertId { get; set; }

        [StaticReflection]
        public string SenderEmail { get; set; }

        [StaticReflection]
        public string BodyAsHtml { get; set; }

        [StaticReflection]
        public string UrlToSimpleDetails { get; set; }
    }
}