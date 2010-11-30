using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Facilities.FactorySupport;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using GuardianReviews.Web.Castle;
using GuardianReviews.Web.Controllers;
using GuardianReviews.Domain.Interfaces;
using GuardianReviews.NHibernate;
using NHibernate;

namespace GuardianReviews.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            var container = new WindsorContainer();

            container.Register(AllTypes
                .FromAssemblyContaining(typeof(ReviewController))
                .BasedOn<Controller>()
                .Configure(reg => reg.LifeStyle.Transient));

            //container.Register(Component.For(typeof(ReviewController))
            //    .ImplementedBy(typeof(ReviewController)));
            
            container.AddFacility<FactorySupportFacility>();
            container.Register(Component.For<ISession>()
                                    .UsingFactoryMethod(SessionManager.GetSession));
            
            container.Register(Component.For(typeof(IRepository<>))
                                    .ImplementedBy(typeof(Repository<>)));

            DependencyResolver.SetResolver(new WindsorDependencyResolver(container));


        }
    }
}