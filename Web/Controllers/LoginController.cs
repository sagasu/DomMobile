namespace Trader.Web.Controllers
{
    using System.Web.Mvc;
    using System.Web.Security;

    /// <summary>
    /// This is a bad code example, it is just to create an authentication quickly
    /// It is sometimes usefull to run this application only for authorized users. But it is not used this way in a production.
    /// </summary>
    public partial class LoginController : Controller
    {
        private const string DefaultUser = "admin";

        private const string DefaultPassword = "12345678";

        public virtual ActionResult Login(string userName, string password, string ReturnUrl)
        {
            if (IsValidLoginArgument(userName, password))
            {
                if (true)
                {
                    this.RedirectFromLoginPage(userName, ReturnUrl);
                }
            }
            else
            {
                ViewData["LoginFaild"] = "Login faild! Make sure you have entered the right user name and password!";
            }

            return View("Login");
        }

        private void RedirectFromLoginPage(string userName, string ReturnUrl)
        {
            FormsAuthentication.SetAuthCookie(userName, false);

            if (!string.IsNullOrEmpty(ReturnUrl))
            {
                Response.Redirect(ReturnUrl);
            }
            else
            {
                Response.Redirect("~/Home/Index");
            }
        }

        private static bool IsValidLoginArgument(string userName, string password)
        {
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                if (userName == DefaultUser && password == DefaultPassword)
                {
                    return true;
                }
            }

            return false;
        }
    }
}