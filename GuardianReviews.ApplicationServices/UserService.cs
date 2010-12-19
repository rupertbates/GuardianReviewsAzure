using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using GuardianReviews.Domain.Interfaces;
using GuardianReviews.Domain.Model;

namespace GuardianReviews.ApplicationServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public User GetCurrentUser()
        {
            if ( HttpContext.Current.User == null || !HttpContext.Current.User.Identity.IsAuthenticated)
                return null;
            return _repository.GetUserByEmail( HttpContext.Current.User.Identity.Name);
        }
    }
}
