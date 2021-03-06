// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.
 
// Make sure the compiler doesn't complain about missing Xml comments
#pragma warning disable 1591
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace Trader.Web.Controllers {
    public partial class AdvertController {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected AdvertController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result) {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult Details() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.Details);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult InvestmentDetails() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.InvestmentDetails);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult SimpleDetails() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.SimpleDetails);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult Gallery() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.Gallery);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult InvestmentGallery() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.InvestmentGallery);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public AdvertController Actions { get { return MVC.Advert; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Advert";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Advert";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass {
            public readonly string Details = "Details";
            public readonly string InvestmentDetails = "InvestmentDetails";
            public readonly string SimpleDetails = "SimpleDetails";
            public readonly string Gallery = "Gallery";
            public readonly string InvestmentGallery = "InvestmentGallery";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants {
            public const string Details = "Details";
            public const string InvestmentDetails = "InvestmentDetails";
            public const string SimpleDetails = "SimpleDetails";
            public const string Gallery = "Gallery";
            public const string InvestmentGallery = "InvestmentGallery";
        }


        static readonly ViewNames s_views = new ViewNames();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewNames Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewNames {
            public readonly string Details_AndroidLess22 = "~/Views/Advert/Details.AndroidLess22.cshtml";
            public readonly string Details = "~/Views/Advert/Details.cshtml";
            public readonly string Details_Mobile = "~/Views/Advert/Details.Mobile.cshtml";
            public readonly string Details_WeakMobile = "~/Views/Advert/Details.WeakMobile.cshtml";
            public readonly string Gallery_AndroidLess22 = "~/Views/Advert/Gallery.AndroidLess22.cshtml";
            public readonly string Gallery = "~/Views/Advert/Gallery.cshtml";
            public readonly string Gallery_Mobile = "~/Views/Advert/Gallery.Mobile.cshtml";
            public readonly string Gallery_WeakMobile = "~/Views/Advert/Gallery.WeakMobile.cshtml";
            public readonly string InvestmentDetails_AndroidLess22 = "~/Views/Advert/InvestmentDetails.AndroidLess22.cshtml";
            public readonly string InvestmentDetails = "~/Views/Advert/InvestmentDetails.cshtml";
            public readonly string InvestmentDetails_Mobile = "~/Views/Advert/InvestmentDetails.Mobile.cshtml";
            public readonly string InvestmentDetails_WeakMobile = "~/Views/Advert/InvestmentDetails.WeakMobile.cshtml";
            public readonly string InvestmentGallery_AndroidLess22 = "~/Views/Advert/InvestmentGallery.AndroidLess22.cshtml";
            public readonly string InvestmentGallery = "~/Views/Advert/InvestmentGallery.cshtml";
            public readonly string InvestmentGallery_Mobile = "~/Views/Advert/InvestmentGallery.Mobile.cshtml";
            public readonly string InvestmentGallery_WeakMobile = "~/Views/Advert/InvestmentGallery.WeakMobile.cshtml";
            public readonly string InvestmentList_Mobile = "~/Views/Advert/InvestmentList.Mobile.cshtml";
            public readonly string InvestmentPagination = "~/Views/Advert/InvestmentPagination.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class T4MVC_AdvertController: Trader.Web.Controllers.AdvertController {
        public T4MVC_AdvertController() : base(Dummy.Instance) { }

        public override System.Web.Mvc.ActionResult Details(Trader.Web.Models.Advert.AdvertViewModel viewModel) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Details);
            callInfo.RouteValueDictionary.Add("viewModel", viewModel);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult InvestmentDetails(Trader.Web.Models.Advert.InvestmentViewModel viewModel) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.InvestmentDetails);
            callInfo.RouteValueDictionary.Add("viewModel", viewModel);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult SimpleDetails(Trader.Web.Models.Advert.IAdvertIdRequired viewModel) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.SimpleDetails);
            callInfo.RouteValueDictionary.Add("viewModel", viewModel);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Gallery(Trader.Web.Models.Advert.AdvertViewModel viewModel) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Gallery);
            callInfo.RouteValueDictionary.Add("viewModel", viewModel);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult InvestmentGallery(Trader.Web.Models.Advert.AdvertViewModel viewModel) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.InvestmentGallery);
            callInfo.RouteValueDictionary.Add("viewModel", viewModel);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591
