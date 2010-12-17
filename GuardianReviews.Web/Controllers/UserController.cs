using GuardianReviews.ApplicationServices;
using System.Web.Mvc;
using System.Web.Security;
using GuardianReviews.Domain.Interfaces;
using GuardianReviews.Domain.Model;
using Newtonsoft.Json;
using SharpArch.Web.NHibernate;
using SharpArch.Web.JsonNet;
using System.Linq;
namespace GuardianReviews.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IOpenIdService _openIdService;
        private readonly IUserRepository _userRepository;

        public UserController(IOpenIdService openIdService, IUserRepository userRepository)
        {
            _userRepository = userRepository;
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
        public ActionResult Settings()
        {
            var user = _userRepository.GetUserByEmail(User.Identity.Name);
            
            return View(user);
        }
        [Transaction]
        public ActionResult SaveReview(int id)
        {
            _userRepository.SaveReviewToList(User.Identity.Name, id);
            return new RedirectResult(Request.UrlReferrer != null ? Request.UrlReferrer.ToString() : "/");
        }
        public ActionResult MyList(HttpResponseTypes format = HttpResponseTypes.Html)
        {
            if (!User.Identity.IsAuthenticated)
                return new EmptyResult();

            var list = _userRepository.GetUserByEmail(User.Identity.Name).SavedReviews;
            
            if(format == HttpResponseTypes.Html)
                return View(list.ToArray());
            
            return new JsonNetResult(list);
        }
        
    }
}
