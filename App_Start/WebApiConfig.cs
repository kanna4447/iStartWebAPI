using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity.Lifetime;
using Unity;
using iStartWebAPI.Repository;
using iStartWebAPI.Interface;
using Unity.WebApi;

namespace iStartWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();


            container.RegisterType<ILogin, LoginRepository>(new HierarchicalLifetimeManager());


            container.RegisterType<IRegister, RegisterRepository>(new HierarchicalLifetimeManager());

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
