namespace Trader.Web.Controllers
{
    using System.Web.Mvc;

    public partial class ViewSwitcherController : Controller
    {
        public virtual RedirectResult SwitchView(bool mobile, string returnUrl)
        {
            //if (Request.Browser.IsMobileDevice == mobile)
            //    HttpContext.ClearOverriddenBrowser();
            //else
            //    HttpContext.SetOverriddenBrowser(mobile ? BrowserOverride.Mobile : BrowserOverride.Desktop);

            return Redirect(returnUrl);
        }
    }
}