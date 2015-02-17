using System.Web.Mvc;
using Microsoft.Web.Mvc;
 
[assembly: WebActivator.PreApplicationStartMethod(typeof(Trader.Web.App_Start.MobileViewEngines), "Start")]
namespace Trader.Web.App_Start {
    using System;

    public static class MobileViewEngines{
        public static void Start() 
        {
            // For SymbianOS
            ViewEngines.Engines.Insert(0, new MobileCapableRazorViewEngine(
                        "WeakMobile",
                         ctx => ctx.Request.UserAgent.IndexOf(
                                 "SymbianOS", StringComparison.OrdinalIgnoreCase) >= 0)
                         );

            // For adroid in smaller version then 2.2
            ViewEngines.Engines.Insert(1, new MobileCapableRazorViewEngine(
                        "AndroidLess22",
                         ctx => (ctx.Request.UserAgent.IndexOf(
                                 "Android 2.1", StringComparison.OrdinalIgnoreCase) >= 0) ||
                                 (ctx.Request.UserAgent.IndexOf(
                                 "Android 2.0", StringComparison.OrdinalIgnoreCase) >= 0) ||
                                 (ctx.Request.UserAgent.IndexOf(
                                 "Android 1.", StringComparison.OrdinalIgnoreCase) >= 0)
                         ));

            // Route everything else to Mobile view !!!
            ViewEngines.Engines.Insert(2, new MobileCapableRazorViewEngine("Mobile", x => true));
        }
    }
}