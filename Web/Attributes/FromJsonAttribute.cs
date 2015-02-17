namespace Trader.Web.Attributes
{
    using System;
    using System.Web.Mvc;
    using System.Web.Script.Serialization;

    using Newtonsoft.Json;

    public class FromJsonAttribute : CustomModelBinderAttribute
    {
        private readonly static JavaScriptSerializer Serializer = new JavaScriptSerializer();

        public override IModelBinder GetBinder()
        {
            return new JsonModelBinder();
        }

        private class JsonModelBinder : IModelBinder
        {
            public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
            {
                //var desObj = JsonConvert.DeserializeObject(controllerContext.HttpContext.Request[bindingContext.ModelName], Type.GetType(bindingContext.ModelName));

                var stringified = controllerContext.HttpContext.Request[bindingContext.ModelName];
                if (string.IsNullOrEmpty(stringified))
                    return null;
                return Serializer.Deserialize(stringified, bindingContext.ModelType);
            }
        }
    }
}