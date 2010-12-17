using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GuardianReviews.ApplicationServices;
using GuardianReviews.Domain.BaseClasses;
using GuardianReviews.Domain.Interfaces;
using GuardianReviews.Domain.Model;
using GuardianReviews.Web.Models;

namespace GuardianReviews.Web.Controllers
{
    public class MenuController : Controller
    {
        private readonly IUserRepository _userRepository;

        public MenuController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        [ChildActionOnly]
        public ActionResult Index()
        {
            var user = _userRepository.GetUserByEmail(User.Identity.Name);
            
            var home = new MenuItemViewModel { DisplayName = "Home", Css = GetCss("Home"), Link = "/" };
            
            var items = new[] { home }.Concat(GetReviewMenuItems(user));

            if (user != null)
                items = items.Concat(new[]{new MenuItemViewModel { DisplayName = "Settings", Css = GetCss("Settings"), Link = "/user/settings" }});
            
            return View("_MenuPartial", items);
        }
        private IEnumerable<MenuItemViewModel> GetReviewMenuItems(User user)
        {
            var items = Enumeration.GetAll<ReviewTypes>().Where(r => r.ShowInUI);
            
            if (user != null)
                items = items.Where(user.IsSubscribedTo);
            
            return items.Select(MenuItemFromReviewType).ToList();
        }
        private MenuItemViewModel MenuItemFromReviewType(ReviewTypes reviewType)
        {
            return new MenuItemViewModel
                       {
                           DisplayName = reviewType.DisplayName,
                           Link = Url.Action("Index", "Review", new {reviewType = reviewType.Name}),
                           Css = GetCss(reviewType.Name)
                       };
        }
        private string GetCss(string displayName)
        {
            if (TabIsActive(displayName))
                return "ui-tabs-selected ui-state-active";
            return "";
        }
        private bool TabIsActive(string tabName)
        {
            switch (tabName)
            {
                case "Home":
                    return ControllerAndActionEquals<HomeController>("Index");
                case "Settings":
                    return ControllerAndActionEquals<UserController>("Settings");
                default:
                    return ControllerAndActionEquals<ReviewController>("Index") &&
                           RouteData.Values["reviewType"].ToString() == tabName;
            }
        }
        private bool ControllerAndActionEquals<TController>(string actionName)
        {
            return ControllerContext.ParentActionViewContext.Controller.GetType() == typeof(TController) &&
                   ControllerContext.ParentActionViewContext.RouteData.Values["action"].ToString() == actionName;
        }

    }
}
