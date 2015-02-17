using System;

namespace Trader.Web.Attributes
{
    using System.Web.Mvc;

    using Ninject;

    using Trader.Services;

    public class SolrModelBinderAttribute : CustomModelBinderAttribute
    {
        private readonly ISolrService _solrService;

        public Type ModelType { get; set; }

        [Inject]
        public ISolrService SolrService { get; set; }

        public SolrModelBinderAttribute(ISolrService solrService)
        {
            _solrService = solrService;
        }

        public override IModelBinder GetBinder()
        {
            return new SolrModelBinder(_solrService, ModelType);
        }
    }

    public class SolrModelBinder : DefaultModelBinder
    {
        private readonly ISolrService _solrService;

        private readonly Type _modelType;

        public SolrModelBinder(ISolrService solrService, Type modelType)
        {
            _solrService = solrService;
            _modelType = modelType;
        }

        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            try
            {
                return TryBindModel(controllerContext, bindingContext);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private object TryBindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var model =  base.BindModel(controllerContext, bindingContext);

            var type = model.GetType();

            //var advert = _solrService.Search(new SolrAdvertDto { Id = viewModel.Id });

            //if (advert == null)
            //{
            //    return View(viewModel);
            //}

            //var advertElement = advert.SearchResults.SingleOrDefault();

            //if (advertElement == null)
            //{
            //    // TODO: Handle error
            //    return View(viewModel);
            //}

            //var advertViewModel = Mapper.Map<ISimpleSolrAdvert, AdvertViewModel>(advertElement);
            return model;
        }
    }
}