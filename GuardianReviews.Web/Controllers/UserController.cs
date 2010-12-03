using GuardianReviews.ApplicationServices;

namespace OpenIdRelyingPartyMvc.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Security;
    using DotNetOpenAuth.Messaging;
    using DotNetOpenAuth.OpenId;
    using DotNetOpenAuth.OpenId.RelyingParty;

    public class UserController : Controller
    {
        private readonly IOpenIdService _openIdService;

        public UserController(IOpenIdService openIdService)
        {
            _openIdService = openIdService;
        }

        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/User/Login?ReturnUrl=Index");
            }

            return View("Index");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("~/Home");
        }

        public ActionResult LogIn()
        {
            // Stage 1: display login form to user
            return View("Login");
        }

        [ValidateInput(false)]
        public ActionResult Authenticate(string returnUrl)
        {
            return _openIdService.Authenticate(Request.Form["openid_identifier"], returnUrl);
        }
    }
}
