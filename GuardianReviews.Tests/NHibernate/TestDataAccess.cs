using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using GuardianReviews.Domain;
using GuardianReviews.Domain.Model;
using GuardianReviews.NHibernate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;

namespace GuardianReviews.Tests.NHibernate
{
    [TestClass]
    public class TestDataAccess
    {
        [TestMethod]
        public void CanCreateSchema()
        {
            SessionManager.CreateSchema();
        }
    }
}
