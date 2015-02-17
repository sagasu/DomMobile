using System.Collections.Generic;
using System.Linq;

namespace Trader.Web.Helpers
{
    using System.Globalization;
    using System.Web.Mvc;

    public class ClientNumberValidatorProvider : ClientDataTypeModelValidatorProvider
    {
        public override IEnumerable<ModelValidator> GetValidators(ModelMetadata metadata,
                                                               ControllerContext context)
        {
            bool isNumericField = base.GetValidators(metadata, context).Any();
            if (isNumericField)
                yield return new ClientSideNumberValidator(metadata, context);
        }
    }

    public class ClientSideNumberValidator : ModelValidator
    {
        public ClientSideNumberValidator(ModelMetadata metadata,
            ControllerContext controllerContext)
            : base(metadata, controllerContext) { }

        public override IEnumerable<ModelValidationResult> Validate(object container)
        {
            yield break; // Do nothing for server-side validation 
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            yield return new ModelClientValidationRule
            {
                ValidationType = "number",
                ErrorMessage = string.Format(CultureInfo.CurrentCulture,
                                             "Wartość musi być cyfrą.")
            };
        }
    } 
}