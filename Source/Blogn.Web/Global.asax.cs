using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;

namespace Blogn
{
    [ExcludeFromCodeCoverage]
    public class MvcApplication : HttpApplication
    {
        protected IContainer GlobalContainer { get; private set; }

        protected void Application_Start()
        {
            // Set up Dependency Injection Framework
            GlobalContainer = DependencyConfig.RegisterDependencyResolvers();

            // Default ASP.NET MVC 5.2 start up code
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
