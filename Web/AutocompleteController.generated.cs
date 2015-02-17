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
    public partial class AutocompleteController {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected AutocompleteController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result) {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.JsonResult City() {
            return new T4MVC_JsonResult(Area, Name, ActionNames.City);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.JsonResult District() {
            return new T4MVC_JsonResult(Area, Name, ActionNames.District);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public AutocompleteController Actions { get { return MVC.Autocomplete; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Autocomplete";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Autocomplete";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass {
            public readonly string City = "City";
            public readonly string District = "District";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants {
            public const string City = "City";
            public const string District = "District";
        }


        static readonly ViewNames s_views = new ViewNames();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewNames Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewNames {
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class T4MVC_AutocompleteController: Trader.Web.Controllers.AutocompleteController {
        public T4MVC_AutocompleteController() : base(Dummy.Instance) { }

        public override System.Web.Mvc.JsonResult City(string city) {
            var callInfo = new T4MVC_JsonResult(Area, Name, ActionNames.City);
            callInfo.RouteValueDictionary.Add("city", city);
            return callInfo;
        }

        public override System.Web.Mvc.JsonResult District(string city) {
            var callInfo = new T4MVC_JsonResult(Area, Name, ActionNames.District);
            callInfo.RouteValueDictionary.Add("city", city);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591