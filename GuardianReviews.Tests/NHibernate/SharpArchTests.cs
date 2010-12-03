using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using GuardianReviews.Domain.BaseClasses;
using GuardianReviews.Domain.Model;
using GuardianReviews.NHibernate;
using GuardianReviews.NHibernate.Mappings;
using GuardianReviews.OpenPlatform;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using SharpArch.Data.NHibernate;
using SharpArch.Testing.NHibernate;
using Guardian.OpenPlatform;
using Shouldly;
namespace GuardianReviews.Tests.NHibernate
{
    [TestClass]
    public class SharpArchTests
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
        /// <summary>
        /// Generates and outputs the database schema SQL to the console
        /// </summary>
        [TestMethod]
        [TestCategory("Live DB")]
        public void CanGenerateDatabaseSchema()
        {
            var session = NHibernateSession.GetDefaultSessionFactory().OpenSession();
            new SchemaExport(_configuration).Create(false, true);
            foreach (MusicTypes i in Enumeration.GetAll<MusicTypes>())
            {
                session.Save(i);
            }
            foreach (ReviewTypes i in Enumeration.GetAll<ReviewTypes>())
            {
                session.Save(i);
            }
        }
        [TestMethod]
        [TestCategory("Live DB")]
        [TestCategory("Live API")]
        public void Can_get_and_insert_live_Content()
        {
            var session = NHibernateSession.GetDefaultSessionFactory().OpenSession();
            new SchemaExport(_configuration).Create(false, true);
            foreach (MusicTypes i in Enumeration.GetAll<MusicTypes>())
            {
                session.Save(i);
            }
            foreach (ReviewTypes i in Enumeration.GetAll<ReviewTypes>())
            {
                session.Save(i);
            }
            //session.Flush();
            var op = new OpenPlatformSearch();

            var fetcher = new ReviewFetcher(op);
            var reviews = fetcher.FetchReviews();
            var repository = new QueryRepository<Review>();
            var nulls = reviews.Where(r => r.ReviewType == null).ToList();
            nulls.Count.ShouldBe(0);

            repository.SaveMany(reviews);
            repository.DbContext.CommitChanges();

        }
        [TestMethod]
        [TestCategory("Live DB")]
        public void Can_query_by_ReviewType()
        {
            var repository = new QueryRepository<Review>();
            var results = repository.FindAll(r => r.ReviewType == ReviewTypes.Music);
            results.Count.ShouldBeGreaterThan(0);

            var results2 = repository.FindAll(r => r.ReviewType.Id == ReviewTypes.Music.Id);
            results2.Count.ShouldBe(results.Count);

        }
        
       
    }
}
