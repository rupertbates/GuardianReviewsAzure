using System;
using System.Linq;
using System.Web.Routing;

namespace GuardianReviews.ApplicationServices
{
    public class UrlEnumMatchConstraint : IRouteConstraint
    {
        public Type EnumType { get; private set; }
        public UrlEnumMatchConstraint(Type enumType)
        {
            EnumType = enumType;
        }

        #region IRouteConstraint Members

        bool IRouteConstraint.Match(System.Web.HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (!values.ContainsKey(parameterName))
                return false;
            var parameterValue = values[parameterName];
            return parameterValue != null && Enum.GetNames(EnumType).Contains(parameterValue.ToString(), StringComparer.OrdinalIgnoreCase);
        }

        #endregion
    }
}
