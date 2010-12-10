using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Security;
using GuardianReviews.Domain.Interfaces;
using GuardianReviews.Domain.Model;

namespace GuardianReviews.ApplicationServices
{
    /// <summary>
    /// An IOpenIdService implementation that doesn't rely on being able to communicate with 
    /// and OpenId provider so it can be used on localhost
    /// </summary>
    public class DebugOpenIdService: Controller, IOpenIdService
    {
        private readonly IQueryRepository<User> _repository;

        public DebugOpenIdService(IQueryRepository<User> repository)
        {
            _repository = repository;
        }

        public ActionResult Authenticate(string openIdIdentifier, string returnUrl)
        {
            CheckUser(openIdIdentifier);
            FormsAuthentication.SetAuthCookie(openIdIdentifier, false);

            if (!string.IsNullOrEmpty(returnUrl))
                return Redirect(returnUrl);

            return RedirectToAction("Index", "Home");
        }
        public void CheckUser(string openIdIdentifier)
        {
            var user = _repository.FindOne(u => u.ClaimedIdentifier == openIdIdentifier);
            if (user != null)
                return;

            user = new User
                       {
                           ClaimedIdentifier = openIdIdentifier,
                           FriendlyIdentifier = openIdIdentifier,
                           Email = openIdIdentifier + "@debug.com",
                           OpenIdProvider = "debug",
                           OpenIdProviderVersion = "1.0"
                       };
            _repository.SaveOrUpdate(user);
        }
    }
}
