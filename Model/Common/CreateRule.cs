namespace Trader.Model.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web.Mvc;

    using Trader.Common;

    public class CreateRule<T>
    {
        private readonly IList<ModelMetadata> modelMetadata;

        private readonly Expression<Func<T, object>> baseProperty;

        private Func<T, bool> predicate;

        private T t;

        public CreateRule(Expression<Func<T, object>> baseProperty, IEnumerable<ModelMetadata> modelMetadata, T t)
        {
            this.baseProperty = baseProperty;
            this.modelMetadata = modelMetadata.ToList();
            this.t = t;
        }

        public CreateRule<T> When(Func<T, bool> func)
        {
            predicate = func;
            return this;
        }

        public ModelMetadata Apply(Func<ModelMetadata, ModelMetadata> func)
        {
            if (predicate(t))
            {
                return func(modelMetadata.SingleOrDefault(x => x.PropertyName.Equals(ReflectionHelper.GetProperty(baseProperty).Name)));
            }
            return null;
        }

        public IEnumerable<ModelMetadata> Hide()
        {
            if (predicate(t))
            {
                var metadata =
                    modelMetadata.SingleOrDefault(
                        x => x.PropertyName.Equals(ReflectionHelper.GetProperty(baseProperty).Name));

                if (metadata != null)
                {
                    metadata.ShowForDisplay = false;
                    metadata.ShowForEdit = false;
                }
            }

            return modelMetadata;
        }

        /// <summary>
        /// Modify an object -> destructive updates can accure here.
        /// </summary>
        /// <param name="func">Destructive update.</param>
        public void Fill(Func<T, object> func)
        {
            if (predicate(t))
            {
                func(t);
            }
        }

        public IEnumerable<ModelMetadata> Show()
        {
            if (predicate(t))
            {
                var metadata =
                    modelMetadata.SingleOrDefault(
                        x => x.PropertyName.Equals(ReflectionHelper.GetProperty(baseProperty).Name));

                if (metadata != null)
                {
                    metadata.ShowForDisplay = true;
                    metadata.ShowForEdit = true;
                }
            }

            return modelMetadata;
        }
    }
}