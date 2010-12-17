using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace GuardianReviews.ApplicationServices
{
    public interface IOpenIdService
    {
        ActionResult Authenticate(string openIdIdentifier, string returnUrl);
    }
}
