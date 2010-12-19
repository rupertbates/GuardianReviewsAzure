using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using GuardianReviews.Domain.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace GuardianReviews.Tests.Domain
{
    [TestClass]
    public class TestEnumeration
    {
        [TestMethod]
        public void Equals_operator_override_works_correctly()
        {
            (ReviewTypes.Music == ReviewTypes.Unknown).ShouldBe(false);
            (ReviewTypes.Music == ReviewTypes.Music).ShouldBe(true);
            (null == ReviewTypes.Film).ShouldBe(false);
            (ReviewTypes.Film == null).ShouldBe(false);
            (null == null).ShouldBe(true);
            
        }
        [TestMethod]
        public void Contains_works_correctly()
        {
            var reviews = new HashSet<ReviewTypes> {ReviewTypes.Books, ReviewTypes.Film};
            reviews.Contains(ReviewTypes.Books).ShouldBe(true);
            reviews.Contains(ReviewTypes.Music).ShouldBe(false);
            var user = new User();
            user.UnsubscribeFrom(ReviewTypes.Books);
            user.IsSubscribedTo(ReviewTypes.Books).ShouldBe(false);

        }
    }
}
