namespace Trader.Web.Global
{
    public static class Consts
    {
        public const string DictionariesRegionName = "DictionariesRegion";
        public const string CategoriesTreeCacheRegionName = "CategoriesTree";
        public const string NotAuthenticatedMessage = "Consts.NotAuthenticatedMessage";
        public const string ModelStateMessage = "Message";
        public const string EntityIdPropName = "Id";
        public const string ShowSendEmailBox = "ShowSendEmailBox";

        public static class Cookie
        {
            public const string NotMobileCookieName = "NotMobile";
            public const string NotMobileCookiePath = "/";
            public const string NotMobileCookieDomain = ".domiporta.pl";
        }

        public static class JavascriptEvents
        {
            public const string Pagecreate = "pagecreate";
        }

        public static class JavascriptIds
        {
            public const string SoldOptionsId = "soldOptionsId";
            public const string AdvertShortDescriptionId = "advertShortDescriptionId";
            public const string AdvertDescriptionId = "advertDescriptionId";
            public const string FloatSearchResult = "floatSearchResult";
            public const string MainContentId = "MainContentId";
            public const string MainBodyId = "MainBodyId";
            public const string DistrictSelectDiv = "DistrictSelectDiv";
            public const string DistrictDiv = "DistrictDiv";
            public const string InvestmentShowedDetailsId = "InvestmentShowedDetailsId";
            public const string InvestmentHiddenDetailsId = "InvestmentHiddenDetailsId";
            public const string Message = "messageId";
            public const string EmailMessageId = "emailMessageId";
            public const string EmailShowedId = "emailShowedId";
            public const string EmailHiddenId = "emailHiddenId";
            public const string SearchTitleTransactionTypeId = "searchTitleTransactionTypeId";
            public const string IsPrivatePersonId = "isPrivatePersonId";
            public const string QuarticFrameId = "quarticFrameId";
            public const string CityInputId = "cityInputId";
            public const string GalleryPictureId = "galleryPictureId";

        }

        public static class Templates
        {
            public const string GlossaryBase = "GlossaryBase";
            public const string Phone = "Phone";
            public const string DefaultFieldContainerCss = "GlobalFloatLeft";
            public const string DefaultLabelContainerCss = "GlobalFloatLeft";
            public const string DefaultFieldCss = "";
            public const string DefaultLabelCss = "";
            public const string DefaultContainerCss = "DodawanieFormularzOdstep";

            public const string BoolDisplay = "BoolDisplay";
            public const string HiddenInput = "HiddenInputTemplate.ascx";
            public const string HiddenInputMvcReservedTemplate = "HiddenInput";
            public const string CheckboxTemplate = "Checkbox";
            public const string Label = "Label";
            public const string HtmlProperties = "HtmlProperties";
            public const string PropertyNameWithChangeEventName = "PropertyNameWithChangeEventName";
        }

        public static class EmailTemplates
        {
            public const string ActivateAdvert = "ActivateAdvert";
            public const string AdvertRetreiveCode = "EmailAdvertRetreiveCode";
            public const string ContactFormEmail = "ContactForm";
            public const string BankTransferKnownUserPaymentSuccess = "BankTransferKnownUserPaymentSuccess";
            public const string BankTransferUnknownUserPaymentSuccess = "BankTransferUnknownUserPaymentSuccess";
            public const string AdvertAdded = "AdvertAdded";
            public const string AdvertStopWords = "AdvertStopWords";
            public const string AdvertCodeAdded = "AdvertCodeAdded";
            public const string AdvertCodeStopWords = "AdvertCodeStopWords";
            public const string UserPanelChangeEmail = "UserPanelChangeEmail";
        }

        public static class SmsTemplates
        {
            public const string SmsKnownUserPaymentSuccess = "SmsKnownUserPaymentSuccess";
            public const string SmsUnknownUserPaymentSuccess = "SmsUnknownUserPaymentSuccess";
            public const string SmsAdvertCode = "SmsAdvertCode";
            public const string AdvertRetreiveCode = "SmsAdvertRetreiveCode";
        }
    }
}