namespace Trader.Web.Controllers
{
    using System.Web.Mvc;

    using Ninject.Extensions.Logging;

    public partial class HomeController : Controller
    {
        public HomeController(ILogger logger)
        {
        }

        public virtual ActionResult Index()
        {
            return View();
        }
    }
}
