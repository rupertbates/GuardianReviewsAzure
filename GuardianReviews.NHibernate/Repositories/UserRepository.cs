using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GuardianReviews.Domain.Interfaces;
using GuardianReviews.Domain.Model;

namespace GuardianReviews.NHibernate.Repositories
{
    public class UserRepository : QueryRepository<User>,  IUserRepository
    {
        private readonly IQueryRepository<Review> _reviewRepository;
        private readonly IQueryRepository<SavedReview> _savedReviewRepository;

        public UserRepository(IQueryRepository<Review> reviewRepository, IQueryRepository<SavedReview> savedReviewRepository)
        {
            _savedReviewRepository = savedReviewRepository;
            _reviewRepository = reviewRepository;
        }

        public User GetUserByEmail(string email)
        {
            return FindOne(u => u.Email == email);
        }

        public void SaveReviewToList(string userEmail, int reviewId)
        {
            var user = GetUserByEmail(userEmail);
            var review = _reviewRepository.Get(reviewId);
            user.SaveReviewToList(review);
            SaveOrUpdate(user);
        }

        public void RemoveReviewFromList(string userEmail, int savedReviewId)
        {
            var user = GetUserByEmail(userEmail);
            var review = _savedReviewRepository.Get(savedReviewId);
            user.RemoveReviewFromList(review);
            SaveOrUpdate(user);
        }
    }
}
