using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using GuardianReviews.Domain.Model;
using GuardianReviews.NHibernate;
using GuardianReviews.NHibernate.Mappings;
using GuardianReviews.NHibernate.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using NHibernate.Cfg;
using SharpArch.Data.NHibernate;
using SharpArch.Testing.NHibernate;
using Shouldly;

namespace GuardianReviews.Tests.Web
{
    [TestClass]
    public class TestSerialization
    {
        private Configuration _configuration;
        [TestInitialize]
        public void Init()
        {
            string[] mappingAssemblies = RepositoryTestsHelper.GetMappingAssemblies();
            const string pathToConfig = "../../../../../../GuardianReviews.Web/NHibernate.config";
            File.Exists(pathToConfig).ShouldBe(true);
            _configuration = NHibernateSession.Init(new SimpleSessionStorage(), mappingAssemblies,
                                   new AutoPersistenceModelGenerator().Generate(),
                                   pathToConfig);
        }
        [TestCleanup]
        public virtual void TearDown()
        {
            NHibernateSession.CloseAllSessions();
            NHibernateSession.Reset();
        }
        [TestMethod]
        public void TestMethod1()
        {
            var repository = new QueryRepository<Review>();
            //var serializer = new JsonSerializer();
            //serializer.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            var review = repository.GetAll()[0];
            var result = JsonConvert.SerializeObject(review);
        }
    }
}
