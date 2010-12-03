using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Guardian.OpenPlatform;
using Guardian.OpenPlatform.Tests.Fakes;
using GuardianReviews.Domain;
using GuardianReviews.Domain.Model;
using GuardianReviews.NHibernate;
using GuardianReviews.OpenPlatform;
using GuardianReviews.OpenPlatform.ContentConverters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GuardianReviews.Tests.NHibernate
{
    [TestClass]
    public class TestDataAccess
    {
        [TestMethod]
        [TestCategory("Live DB")]
        public void CanCreateSchema()
        {
            SessionManager.CreateSchema();
        }
        [TestMethod]
        [TestCategory("Live DB")]
        [DeploymentItem(@"OpenPlatform\ReviewsWithAllFields.json")]
        public void Can_insert_Content()
        {
            SessionManager.CreateSchema();
            var op = new OpenPlatformSearch(new ApiService("ReviewsWithAllFields.json"), "", "");
            
            var fetcher = new ReviewFetcher(op);
            var reviews = fetcher.FetchReviews();
            var repository = new QueryRepository<Review>();
            var nulls = reviews.Where(r => r.ReviewType == null).ToList();
            repository.SaveMany(reviews);

        }
        [TestMethod]
        [TestCategory("Live DB")]
        [TestCategory("Live API")]
        public void Can_get_and_insert_live_Content()
        {
            SessionManager.CreateSchema();
            var op = new OpenPlatformSearch();

            var fetcher = new ReviewFetcher(op);
            var reviews = fetcher.FetchReviews();
            var repository = new QueryRepository<Review>();
            var nulls = reviews.Where(r => r.ReviewType == null).ToList();
            repository.SaveMany(reviews);

        }
    }
}
