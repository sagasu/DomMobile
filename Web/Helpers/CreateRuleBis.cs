using System;

namespace Trader.Web.Helpers
{
    using System.Linq.Expressions;
    using System.Web.Mvc;

    using Trader.Common;

    public class CreateRuleBis<T>
    {
        private readonly ModelMetadata modelMetadata;

        private readonly Expression<Func<T, object>> baseProperty;

        private Func<T, bool> predicate;

        private T t;

        private readonly string metadataRuleForPropertyName;

        public CreateRuleBis(Expression<Func<T, object>> baseProperty, ModelMetadata modelMetadata, T t, string metadataRuleForPropertyName)
        {
            this.baseProperty = baseProperty;
            this.modelMetadata = modelMetadata;
            this.t = t;
            this.metadataRuleForPropertyName = metadataRuleForPropertyName;
        }

        public CreateRuleBis<T> When(Func<T, bool> func)
        {
            predicate = func;
            return this;
        }

        public ModelMetadata Apply(Func<ModelMetadata, ModelMetadata> func)
        {
            if (predicate(t))
            {
                //return func(modelMetadata.Properties.SingleOrDefault(x => x.PropertyName.Equals(ReflectionHelper.GetProperty(baseProperty).Name)));
            }
            return null;
        }

        public ModelMetadata Hide()
        {
            var basePropertyName = ReflectionHelper.GetProperty(baseProperty).Name;
            if (basePropertyName != this.metadataRuleForPropertyName)
            {
                return modelMetadata;
            }


            if (predicate(t))
            {
                modelMetadata.ShowForDisplay = false;
                modelMetadata.ShowForEdit = false;
            }

            return modelMetadata;
        }
    }
}