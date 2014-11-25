using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Routing;
using Moq;
using NUnit.Framework;

namespace Blogn.Tests
{
    [TestFixture]
    public class WebApiConfigTests
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
        public void Register_WithNullHttpConfiguration_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => WebApiConfig.Register(null));
        }

        [Test]
        public void Register_WithValidHttpConfiguration_RegistersDefaultApiRoute()
        {
            HttpRouteCollection routes = new HttpRouteCollection();
            HttpConfiguration configuration = new HttpConfiguration(routes);
            
            WebApiConfig.Register(configuration);

            HttpRoute defaultRoute = routes.SingleOrDefault(route => route.RouteTemplate == "api/{controller}/{id}") as HttpRoute;
            Assert.IsNotNull(defaultRoute);
        }
    }
}
