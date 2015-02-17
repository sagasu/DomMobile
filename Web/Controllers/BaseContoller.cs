namespace Trader.Web.Controllers
{
    using System.Web.Mvc;

    using Ninject.Extensions.Logging;

    public class BaseContoller : Controller
    {
        protected readonly ILogger Logger;

        /// <summary>
        /// This is to make MVCT4 work, don't use this constructor
        /// </summary>
        public BaseContoller() { }

        public BaseContoller(ILogger logger)
        {
            this.Logger = logger;
        }

        public virtual ActionResult JsonMessage(JsonMessageEnum jsonMessageEnum, string message)
        {
            return Json(data: new JsonMessage{Message = message, Status = jsonMessageEnum}, behavior: JsonRequestBehavior.AllowGet);
        }
    }

    public class JsonMessage
    {
        public string Message { get; set; }

        public JsonMessageEnum Status { get; set; }
    }

    public enum JsonMessageEnum
    {
        Success,
        Warning,
        Error
    };
}