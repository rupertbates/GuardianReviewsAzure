using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GuardianReviews.Domain.BaseClasses;

namespace GuardianReviews.Web.Binders
{
    public class EnumerationBinder<T> : DefaultModelBinder where T : Enumeration, new()
    {
        private T DefaultValue { get; set; }
	    public EnumerationBinder(T defaultValue)
	    {
	        DefaultValue = defaultValue;
	    }
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var val = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            return val == null ? DefaultValue : Enumeration.FromName<T>(val.AttemptedValue);
        }
    }
}