using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using GuardianReviews.Domain;
using GuardianReviews.Domain.Enumerations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;

namespace GuardianReviews.Tests.Data
{
    [TestClass]
    public class TestDataAccess
    {
        [TestMethod]
        public void TestMethod1()
        {
            var context = new GuardianReviewsContainer();
            context.DeleteDatabase();
            context.CreateDatabase();
            context.AddObject("Reviews", new Review { Id="Id1", Title = "blah", PublicationDate = DateTime.Now, StarRating = (int) StarRatings.Three, ReviewType = (int) ReviewTypes.Film });
            context.AddObject("Reviews", new Review { Id="Id2", Title = "test", PublicationDate = DateTime.Now.AddDays(-7), ReviewType = (int) ReviewTypes.Music });
            context.SaveChanges();

            var queryResults = context.Reviews.ToList();
            queryResults.Count().ShouldEqual(2);
        }
    }
}
