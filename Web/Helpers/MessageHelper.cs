namespace Trader.Web.Helpers
{
    using System.Web.Mvc;

    public class MessageHelper
    {
        public const string InfoMessage = "InfoMessage";

        public const string ErrorMessage = "ErrorMessage";

        public static void SendErrorMessage(dynamic viewBag, string errorMessage)
        {
            viewBag.ErrorMessage = errorMessage;
        }

        public static void SendInfoMessage(dynamic viewBag, string infoMessage)
        {
            viewBag.InfoMessage = infoMessage;
        }

        public static void SendInfoMessage(ViewDataDictionary viewData, string infoMessage)
        {
            viewData.Add(InfoMessage, infoMessage);
        }
        
        public static void SendErrorMessage(ViewDataDictionary viewData, string errorMessage)
        {
            viewData.Add(ErrorMessage, errorMessage);
        }
    }
}