﻿using System;
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
using Should;
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
            File.Exists(pathToConfig).ShouldBeTrue();
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

            var op = new OpenPlatformSearch();

            var fetcher = new ReviewFetcher(op);
            var reviews = fetcher.FetchReviews();
            var repository = new QueryRepository<Review>();
            var nulls = reviews.Where(r => r.ReviewType == null).ToList();
            repository.SaveMany(reviews);
            repository.DbContext.CommitChanges();

        }
    }
}