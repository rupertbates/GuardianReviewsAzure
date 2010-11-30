using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Guardian.OpenPlatform;
using Guardian.OpenPlatform.Tests.Fakes;
using GuardianReviews.Domain.Interfaces;
using GuardianReviews.Domain.Model;
using GuardianReviews.OpenPlatform;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;

namespace GuardianReviews.Tests.OpenPlatform
{
    [TestClass]
    public class TestReviewFetcher
    {
        [TestMethod]
        [DeploymentItem(@"OpenPlatform\ReviewsWithAllFields.json")]
        public void can_get_correct_number_of_reviews()
        {
            var op = new OpenPlatformSearch(new ApiService("ReviewsWithAllFields.json"), "", "");
            var rf = new ReviewFetcher(op);
            var reviews = rf.FetchReviews();
            reviews.Count().ShouldEqual(50);
        }
    }
}
