using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GuardianReviews.Domain;
using GuardianReviews.Domain.Interfaces;

namespace GuardianReviews.Data
{
    public class ReviewsRepository : IRepository<Review>
    {
        private readonly GuardianReviewsContainer _container;

        public ReviewsRepository(GuardianReviewsContainer container)
        {
            _container = container;
        }

        public List<Review> Select(Func<Review, bool> predicate)
        {
            return _container.Reviews.Where(predicate).ToList();
        }

        public void Insert(Review entity)
        {
            _container.Reviews.AddObject(entity);
        }

        public void Update(Review entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Review entity)
        {
            _container.DeleteObject(entity);
        }
    }
}
