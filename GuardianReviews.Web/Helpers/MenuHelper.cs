using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GuardianReviews.Domain.BaseClasses;
using GuardianReviews.Domain.Model;
using GuardianReviews.Web.Controllers;

namespace GuardianReviews.Web.Helpers
{
    public enum MenuTabs
    {
        
    }
    public static class MenuHelper
    {
        public static string GetMenuTabCss(this HtmlHelper html, string tabName)
        {
            if (html.TabIsActive(tabName))
                return "ui-tabs-selected ui-state-active";
            return "";
        }
        public static bool TabIsActive(this HtmlHelper html, string tabName)
        {
            switch (tabName)
            {
                case "Home":
                    return html.ControllerAndActionEquals<HomeController>("Index");
                case "Settings":
                    return html.ControllerAndActionEquals<UserController>("Settings");
                default:
                    return html.ControllerAndActionEquals<ReviewController>("Index") &&
                           html.ViewContext.RouteData.Values["reviewType"].ToString() == tabName;
            }
        }
        public static bool ControllerAndActionEquals<TController>(this HtmlHelper html, string actionName)
        {
            return html.ViewContext.Controller.GetType() == typeof (TController) &&
                   html.ViewContext.RouteData.Values["action"].ToString() == actionName;
        }
        
    }
}