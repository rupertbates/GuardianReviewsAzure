using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuardianReviews.Web.Binders
{
    public class EnumBinder<T> : IModelBinder
    {
        private T DefaultValue { get; set; }
        public EnumBinder(T defaultValue)
        {
            DefaultValue = defaultValue;
        }

        #region IModelBinder Members

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            return bindingContext.ValueProvider.GetValue(bindingContext.ModelName) == null
                       ? DefaultValue
                       : GetEnumValue(DefaultValue, bindingContext.ValueProvider.GetValue(bindingContext.ModelName).AttemptedValue);
        }

        #endregion
        public static T GetEnumValue<T>(T defaultValue, string value)
        {
            T enumType = defaultValue;

            if ((!String.IsNullOrEmpty(value)) && (Contains(typeof(T), value)))
                enumType = (T)Enum.Parse(typeof(T), value, true);

            return enumType;
        }
        public static bool Contains(Type enumType, string value)
        {
            return Enum.GetNames(enumType).Contains(value, StringComparer.OrdinalIgnoreCase);
        }
    }
}