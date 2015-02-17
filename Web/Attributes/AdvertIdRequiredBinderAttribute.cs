namespace Trader.Web.Attributes
{
    using System;
    using System.Web.Mvc;

    using Trader.Web.Helpers;
    using Trader.Web.Models.Advert;
    using Trader.Web.Models.Domiporta;

    public class AdvertIdRequiredBinderAttribute : CustomModelBinderAttribute
    {
        public override IModelBinder GetBinder()
        {
            return new AdvertIdRequiredBinder();
        }
    }

    public class AdvertIdRequiredBinder : DefaultModelBinder
    {
        private const string IncorrectId = "Nieprawidłowe Id.";

        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            try
            {
                return TryBindModel(controllerContext);
            }
            catch (Exception)
            {
                bindingContext.ModelState.AddModelError("Global", IncorrectId);
                return new WebSearchResultViewModel();
            }
        }

        private object TryBindModel(ControllerContext controllerContext)
        {
            var viewModel = new AdvertViewModel
                {
                    Id = controllerContext.HttpContext.Request.Params.Get(StaticReflectionPoco.AdvertViewModel.Id)
                };

            return viewModel;
        }
    }
}