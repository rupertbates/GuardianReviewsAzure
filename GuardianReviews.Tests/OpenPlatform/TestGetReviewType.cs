using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Guardian.OpenPlatform;
using Guardian.OpenPlatform.Results.Entities;
using GuardianReviews.Domain.Model;
using GuardianReviews.OpenPlatform.ContentConverters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Guardian.OpenPlatform.Tests.Fakes;
namespace GuardianReviews.Tests.OpenPlatform
{
    [TestClass]
    public class TestGetReviewType
    {
        [TestMethod]
        public void TestGetReviewTypeFromTag()
        {
            var content = new Content
                              {
                                  Tags = new[]
                                             {
                                                 new Tag {Id = "books/books"}
                                             }
                              };
            content.GetReviewType().ShouldBe(ReviewTypes.Books);
        }

        [TestMethod]
        [DeploymentItem(@"OpenPlatform\Reviews2.json")]
        public void TestGetReviewType_with_real_data()
        {
            //http://content.guardianapis.com/stage/2010/nov/24/the-invisible-man-review
            //http://content.guardianapis.com/stage/2010/nov/24/hunt-for-the-scroobious-pip-review
            //http://content.guardianapis.com/tv-and-radio/2010/nov/24/arise-black-man-peter-tosh-review
            //http://content.guardianapis.com/tv-and-radio/2010/nov/23/how-roald-dahl-shaped-pop-review
            //http://content.guardianapis.com/technology/gamesblog/2010/nov/22/we-sing-robbie-williams-review
            //http://content.guardianapis.com/tv-and-radio/2010/nov/22/tv-review-any-human-heart
            //load some reviews from a text file using a fake
            var op = new OpenPlatformSearch(new ApiService("Reviews2.json"), "", "");
            var results = op.ContentSearch(new ContentSearchParameters());
            results.Results.Count().ShouldBe(50);

            var content = results.Results
                .First();
            content.GetReviewType().ShouldBe(ReviewTypes.Theatre);

            content.AsReview().ReviewType.ShouldBe(ReviewTypes.Theatre);
            
            content = results.Results
                .Where(c => c.ApiUrl == "http://content.guardianapis.com/stage/2010/nov/24/the-invisible-man-review").First();
            content.GetReviewType().ShouldBe(ReviewTypes.Theatre);
            
            content = results.Results
                .Where(c => c.ApiUrl == "http://content.guardianapis.com/technology/gamesblog/2010/nov/22/we-sing-robbie-williams-review").First();
            content.GetReviewType().ShouldBe(ReviewTypes.Game);
            
            content = results.Results
                .Where(c => c.ApiUrl == "http://content.guardianapis.com/tv-and-radio/2010/nov/24/arise-black-man-peter-tosh-review").First();
            content.GetReviewType().ShouldBe(ReviewTypes.TvAndRadio);

            //var multiples = results.Results.Where(c => converter.GetReviewTypesFromTag(c).Count > 1);
            //foreach (var multiple in multiples)
            //{
            //    System.Diagnostics.Debug.WriteLine(multiple.ApiUrl);
            //}
            //var count = multiples.Count();
        }
    }
}
