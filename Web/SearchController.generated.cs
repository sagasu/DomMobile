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
    public partial class SearchController {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected SearchController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result) {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult Search() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.Search);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult SearchResult() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.SearchResult);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public SearchController Actions { get { return MVC.Search; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Search";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Search";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass {
            public readonly string Search = "Search";
            public readonly string SearchResult = "SearchResult";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants {
            public const string Search = "Search";
            public const string SearchResult = "SearchResult";
        }


        static readonly ViewNames s_views = new ViewNames();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewNames Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewNames {
            public readonly string CityDistrictAutocomplete = "~/Views/Search/CityDistrictAutocomplete.cshtml";
            public readonly string Search_AndroidLess22 = "~/Views/Search/Search.AndroidLess22.cshtml";
            public readonly string Search = "~/Views/Search/Search.cshtml";
            public readonly string Search_Mobile = "~/Views/Search/Search.Mobile.cshtml";
            public readonly string Search_WeakMobile = "~/Views/Search/Search.WeakMobile.cshtml";
            public readonly string SearchResult_AndroidLess22 = "~/Views/Search/SearchResult.AndroidLess22.cshtml";
            public readonly string SearchResult = "~/Views/Search/SearchResult.cshtml";
            public readonly string SearchResult_Mobile = "~/Views/Search/SearchResult.Mobile.cshtml";
            public readonly string SearchResult_WeakMobile = "~/Views/Search/SearchResult.WeakMobile.cshtml";
            public readonly string SearchResultHeader_Mobile = "~/Views/Search/SearchResultHeader.Mobile.cshtml";
            public readonly string SearchResultPaginationFloatingFooter_Mobile = "~/Views/Search/SearchResultPaginationFloatingFooter.Mobile.cshtml";
            public readonly string SearchResultSortHeader_Mobile = "~/Views/Search/SearchResultSortHeader.Mobile.cshtml";
            public readonly string SetSearchTitle = "~/Views/Search/SetSearchTitle.cshtml";
            public readonly string TransactionTypeSearchCriteria = "~/Views/Search/TransactionTypeSearchCriteria.cshtml";
            static readonly _DisplayTemplates s_DisplayTemplates = new _DisplayTemplates();
            public _DisplayTemplates DisplayTemplates { get { return s_DisplayTemplates; } }
            public partial class _DisplayTemplates{
            }
            static readonly _EditorTemplates s_EditorTemplates = new _EditorTemplates();
            public _EditorTemplates EditorTemplates { get { return s_EditorTemplates; } }
            public partial class _EditorTemplates{
                public readonly string SearchCriteria = "SearchCriteria";
            }
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class T4MVC_SearchController: Trader.Web.Controllers.SearchController {
        public T4MVC_SearchController() : base(Dummy.Instance) { }

        public override System.Web.Mvc.ActionResult Search(Trader.Web.Models.Search.SearchViewModel searchViewModel) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Search);
            callInfo.RouteValueDictionary.Add("searchViewModel", searchViewModel);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult SearchResult(Trader.Web.Models.Search.SearchViewModel searchViewModel) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.SearchResult);
            callInfo.RouteValueDictionary.Add("searchViewModel", searchViewModel);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591
