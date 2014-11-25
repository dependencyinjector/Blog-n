using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;
using NUnit.Framework;

namespace Blogn.Tests
{
    [TestFixture]
    public class RouteConfigTests
    {
        // SetUp & Mocks
        [SetUp]
        public void SetUp()
        {

        }

        [TearDown]
        public void TearDown()
        {

        }

        // Tests
        [Test]
        public void RegisterRoutes_WithNullRouteCollection_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => RouteConfig.RegisterRoutes(null));
        }

        [Test]
        public void RegisterRoutes_WithValidRouteCollection_RegistersIgoreRouteForAxds()
        {
            RouteCollection routes = new RouteCollection();

            RouteConfig.RegisterRoutes(routes);

            Assert.IsNotNull(routes.SingleOrDefault(route=>(route as Route).Url=="{resource}.axd/{*pathInfo}" && 
                (route as Route).RouteHandler is StopRoutingHandler));
        }

        [Test]
        public void RegisterRoutes_WithValidRouteCollection_RegistersDefaultRoute()
        {
            RouteCollection routes = new RouteCollection();

            RouteConfig.RegisterRoutes(routes);

            Route defaultRoute = routes.SingleOrDefault(route=>(route as Route).Url=="{controller}/{action}/{id}") as Route;
            Assert.IsNotNull(defaultRoute);
            Assert.AreEqual("Home", defaultRoute.Defaults["controller"]);
            Assert.AreEqual("Index", defaultRoute.Defaults["action"]);
        }


    }
}
