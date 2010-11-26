using System;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using GuardianReviews.Domain.BaseClasses;
using GuardianReviews.Domain.Model;
using GuardianReviews.NHibernate.Mappings;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace GuardianReviews.NHibernate
{
    public class SessionManager
    {
        private readonly static ISessionFactory _factory;
        private static Configuration _configuration;
        static SessionManager()
        {
            var cfg = new ReviewsConfiguration();
            var mappings = AutoMap.AssemblyOf<Review>(cfg)
                .Conventions.Add(ForeignKey.Format((m, t) => t.Name + "Id"))
                .UseOverridesFromAssemblyOf<MusicReviewOverride>();

            _factory = Fluently.Configure()
              .Database(MsSqlConfiguration.MsSql2008.ShowSql()
                    .ConnectionString(c => c
                    .FromConnectionStringWithKey("GuardianReviews.ConnectionString")))
              .Mappings(m => m.AutoMappings.Add(mappings))
              .ExposeConfiguration(c => _configuration = c)
              .BuildSessionFactory();

        }
        public static ISession GetSession()
        {
            return _factory.OpenSession();
        }
        public static void CreateSchema()
        {
            var export = new SchemaExport(_configuration);
            export.Create(false, true);
            var session = GetSession();
            foreach (MusicTypes m in Enumeration.GetAll<MusicTypes>())
            {
                session.Save(m);
            }

        }
    }
}
