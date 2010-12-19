using System.Web.Mvc;
using Castle.Windsor;
using GuardianReviews.ApplicationServices;
using GuardianReviews.Domain.Interfaces;
using GuardianReviews.NHibernate;
using GuardianReviews.Web.Controllers;
using SharpArch.Core.PersistenceSupport.NHibernate;
using SharpArch.Data.NHibernate;
using SharpArch.Core.PersistenceSupport;
using SharpArch.Web.Castle;
using Castle.MicroKernel.Registration;
using SharpArch.Core.CommonValidator;
using SharpArch.Core.NHibernateValidator.CommonValidatorAdapter;

namespace GuardianReviews.Web.Startup
{
    public class ComponentRegistrar
    {
        public static void AddComponentsTo(IWindsorContainer container)
        {
            AddControllersTo(container);
            AddGenericRepositoriesTo(container);
            AddCustomRepositoriesTo(container);
            AddApplicationServicesTo(container);
            
            
            container.AddComponent("validator",
                typeof(IValidator), typeof(Validator));
        }
        private static void AddControllersTo(IWindsorContainer container)
        {
            container.Register(AllTypes
                .FromAssemblyContaining(typeof(ReviewController))
                .BasedOn<Controller>()
                .Configure(reg => reg.LifeStyle.Transient));
        }
        private static void AddApplicationServicesTo(IWindsorContainer container)
        {
            container.AddComponent("OpenId", typeof(IOpenIdService), typeof(DebugOpenIdService));
            container.AddComponent("Users", typeof(IUserService), typeof(UserService));
            //container.Register(
            //    AllTypes.Pick()
            //    .FromAssembly(typeof(OpenIdService).Assembly)
            //    );
        }

        private static void AddCustomRepositoriesTo(IWindsorContainer container)
        {
            container.Register(
                AllTypes.Pick()
                .FromAssemblyNamed("GuardianReviews.NHibernate")
                .WithService.FirstNonGenericCoreInterface("GuardianReviews.Domain"));
        }

        private static void AddGenericRepositoriesTo(IWindsorContainer container)
        {
            container.AddComponent("entityDuplicateChecker",
                typeof(IEntityDuplicateChecker), typeof(EntityDuplicateChecker));
            container.AddComponent("repositoryType",
                typeof(IRepository<>), typeof(Repository<>));
            container.AddComponent("nhibernateRepositoryType",
                typeof(INHibernateRepository<>), typeof(NHibernateRepository<>));
            container.AddComponent("repositoryWithTypedId",
                typeof(IRepositoryWithTypedId<,>), typeof(RepositoryWithTypedId<,>));
            container.AddComponent("nhibernateRepositoryWithTypedId",
                typeof(INHibernateRepositoryWithTypedId<,>), typeof(NHibernateRepositoryWithTypedId<,>));
            container.AddComponent("queryRepositoryType", typeof(IQueryRepository<>),
                                    typeof(QueryRepository<>));
        }
    }
}
