using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GuardianReviews.Domain.Model;

namespace GuardianReviews.Domain.Interfaces
{
    public interface IUserRepository : IQueryRepository<User>
    {
        User GetUserByEmail(string email);
        void SaveReviewToList(string userEmail, int reviewId);
    }
}
