using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.Messaging;
using DotNetOpenAuth.OpenId;
using DotNetOpenAuth.OpenId.Extensions.SimpleRegistration;
using DotNetOpenAuth.OpenId.RelyingParty;
using GuardianReviews.Domain.Interfaces;
using GuardianReviews.Domain.Model;
using GuardianReviews.Logging;

namespace GuardianReviews.ApplicationServices
{
    public class OpenIdService : Controller, IOpenIdService
    {
        private static OpenIdRelyingParty _openId = new OpenIdRelyingParty();
        private readonly IQueryRepository<User> _repository;

        public OpenIdService(IQueryRepository<User> repository)
        {
            _repository = repository;
        }

        public ActionResult Authenticate(string openIdIdentifier, string returnUrl)
        {
            Logs.OpenIdLog.DebugFormat("Attempting login with identifier {0} and returnUrl {1}", openIdIdentifier, returnUrl);
            var response = _openId.GetResponse();
            
            if (response == null) //We have just come here from the login page
                return DoOpenIdLogin(openIdIdentifier);
            
            return ProcessLoginResult(response, returnUrl); //we are returning from the OpenId provider
        }
        protected ActionResult DoOpenIdLogin(string openIdIdentifier)
        {
            Identifier id;
            if (!Identifier.TryParse(openIdIdentifier, out id))
                return LoginView("Invalid identifier");
            
            try
            {
                var request = _openId.CreateRequest(openIdIdentifier);
                request.AddExtension(new ClaimsRequest
                                         {
                                             Email = DemandLevel.Require, 
                                             FullName = DemandLevel.Require, 
                                             PostalCode = DemandLevel.Request
                                         });//TODO: set a policy url
                return request.RedirectingResponse.AsActionResult();
            }
            catch (ProtocolException ex)
            {
                Logs.OpenIdLog.Error("Protocol exception in DoOpenIdLogin", ex);
                return LoginView(ex.Message);
            }
        }
        protected ActionResult ProcessLoginResult(IAuthenticationResponse response, string returnUrl)
        {
            switch (response.Status)
            {
                case AuthenticationStatus.Authenticated:
                    var user = ProcessAuthenticatedUser(response);
                    FormsAuthentication.SetAuthCookie(user.Email, false);
                    if (!string.IsNullOrEmpty(returnUrl))
                        return Redirect(returnUrl);
                    return RedirectToAction("Index", "Home");
                
                case AuthenticationStatus.Canceled:
                    return LoginView("Canceled at provider");
                case AuthenticationStatus.Failed:
                    return LoginView(response.Exception.Message);
            }
            return new EmptyResult();
        }
        protected User ProcessAuthenticatedUser(IAuthenticationResponse response)
        {
            var user = _repository.FindOne(u => u.ClaimedIdentifier == response.ClaimedIdentifier);
            if(user != null)
                return user;

            user = new User
                       {
                           ClaimedIdentifier = response.ClaimedIdentifier,
                           FriendlyIdentifier = response.FriendlyIdentifierForDisplay,
                           OpenIdProvider = response.Provider.Uri.ToString(),
                           OpenIdProviderVersion = response.Provider.Version.ToString()
                       };
            var extensions = response.GetExtension<ClaimsResponse>();
            if (extensions != null)
            {
                user.FullName = extensions.FullName;
                user.Email = extensions.Email;
                user.PostalCode = extensions.PostalCode;
            }
            _repository.SaveOrUpdate(user);
            return user;
        }
        protected ActionResult LoginView(string message)
        {
            ViewData["Message"] = message;
            return View("Login");
        }
    }
}
