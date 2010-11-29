using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Guardian.OpenPlatform;
using Guardian.OpenPlatform.Tests.Fakes;
using GuardianReviews.Domain;
using GuardianReviews.Domain.Model;
using GuardianReviews.NHibernate;
using GuardianReviews.OpenPlatform.ContentConverters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;

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
        [DeploymentItem(@"OpenPlatform\Reviews2.json")]
        public void CanInsertContent()
        {
            var op = new OpenPlatformSearch(new ApiService("Reviews2.json"), "", "");
            var results = op.ContentSearch(new ContentSearchParameters());
            results.Results.Count().ShouldEqual(50);
            var reviews = results.AsReviews();

        }
    }
}
