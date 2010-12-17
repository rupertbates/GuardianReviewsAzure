using GuardianReviews.Domain.Model;

namespace GuardianReviews.ApplicationServices
{
    public interface IUserService
    {
        User GetCurrentUser();
    }
}