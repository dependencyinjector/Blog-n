using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Blogn.Controllers;
using Blogn.Infrastructure;
using Moq;
using NUnit.Framework;

namespace Blogn.Tests.Controllers
{
    [TestFixture]
    public class MvcControllerBaseTests
    {
        // SetUp & Mocks
        private BaseControllerMocks _mocks;

        [SetUp]
        public void SetUp()
        {
            _mocks=new BaseControllerMocks();
        }

        [TearDown]
        public void TearDown()
        {
            _mocks = null;
        }

        // Tests
        [Test]
        public void Instantiation_WithNullContext_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => CreateSut(null));
        }

        [Test]
        public void State_ReturnsContextState()
        {
            MvcControllerBaseWrapper sut = CreateSut();

            Assert.AreSame(_mocks.ControllerContext.Object.State, sut.ProtectedState);
        }

        [Test]
        public void Settings_ReturnsContextSettings()
        {
            MvcControllerBaseWrapper sut = CreateSut();

            Assert.AreSame(_mocks.ControllerContext.Object.Settings, sut.ProtectedSettings);
        }

        [Test]
        public void RedirectToActionOfT_NoParameters_ReturnsExpectedRedirectToRouteResult()
        {
            const string expectedControllerName = "RedirectToAction";
            const string expectedActionName = "Index";
            const int expectedRouteValueCount = 2;
            MvcControllerBase sut = CreateSut();
            RedirectToRouteResult result = sut.RedirectToAction<RedirectToActionController>(controller => controller.Index());
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedRouteValueCount, result.RouteValues.Count);
            Assert.AreEqual(expectedControllerName, result.RouteValues["controller"]);
            Assert.AreEqual(expectedActionName, result.RouteValues["action"]);
        }

        [Test]
        public void RedirectToActionOfT_WithIdParameter_ReturnsExpectedRedirectToRouteResult()
        {
            const string expectedControllerName = "RedirectToAction";
            const string expectedActionName = "ById";
            const int expectedId = 3;
            const int expectedRouteValueCount = 3;
            MvcControllerBase sut = CreateSut();
            RedirectToRouteResult result = sut.RedirectToAction<RedirectToActionController>(controller => controller.ById(expectedId));
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedRouteValueCount, result.RouteValues.Count);
            Assert.AreEqual(expectedControllerName, result.RouteValues["controller"]);
            Assert.AreEqual(expectedActionName, result.RouteValues["action"]);
            Assert.AreEqual(expectedId, result.RouteValues["id"]);
        }

        [Test]
        public void RedirectToActionOfT_WithMultipleParameters_ReturnsExpectedRedirectToRouteResult()
        {
            const string expectedControllerName = "RedirectToAction";
            const string expectedActionName = "MultipleParameters";
            const int expectedId = 3;
            const string expectedOther = "OtherValue";
            const int expectedRouteValueCount = 4;
            MvcControllerBase sut = CreateSut();
            RedirectToRouteResult result = sut.RedirectToAction<RedirectToActionController>(controller => controller.MultipleParameters(expectedId, expectedOther));
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedRouteValueCount, result.RouteValues.Count);
            Assert.AreEqual(expectedControllerName, result.RouteValues["controller"]);
            Assert.AreEqual(expectedActionName, result.RouteValues["action"]);
            Assert.AreEqual(expectedId, result.RouteValues["id"]);
            Assert.AreEqual(expectedOther, result.RouteValues["other"]);
        }

        [Test]
        public void RedirectToActionOfT_WithMultipleParametersUsingObjectParameter_ReturnsExpectedRedirectToRouteResult()
        {
            const string expectedControllerName = "RedirectToAction";
            const string expectedActionName = "MultipleParameters";
            const int expectedId = 3;
            const string expectedOther = "OtherValue";
            const string expectedObjValue = "object";
            const int expectedRouteValueCount = 5;
            MvcControllerBase sut = CreateSut();
            RedirectToRouteResult result = sut.RedirectToAction<RedirectToActionController>(controller => controller.MultipleParameters(expectedId, expectedOther), new { obj = expectedObjValue });
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedRouteValueCount, result.RouteValues.Count);
            Assert.AreEqual(expectedControllerName, result.RouteValues["controller"]);
            Assert.AreEqual(expectedActionName, result.RouteValues["action"]);
            Assert.AreEqual(expectedId, result.RouteValues["id"]);
            Assert.AreEqual(expectedOther, result.RouteValues["other"]);
            Assert.AreEqual(expectedObjValue, result.RouteValues["obj"]);
        }

        [Test]
        public void RedirectToActionOfT_WithMultipleParametersUsingRouteDictionarytParameter_ReturnsExpectedRedirectToRouteResult()
        {
            const string expectedControllerName = "RedirectToAction";
            const string expectedActionName = "MultipleParameters";
            const int expectedId = 3;
            const string expectedOther = "OtherValue";
            const string expectedObjValue = "object";
            const int expectedRouteValueCount = 5;
            RouteValueDictionary routes = new RouteValueDictionary { { "obj", expectedObjValue } };
            MvcControllerBase sut = CreateSut();
            RedirectToRouteResult result = sut.RedirectToAction<RedirectToActionController>(controller => controller.MultipleParameters(expectedId, expectedOther), routes);
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedRouteValueCount, result.RouteValues.Count);
            Assert.AreEqual(expectedControllerName, result.RouteValues["controller"]);
            Assert.AreEqual(expectedActionName, result.RouteValues["action"]);
            Assert.AreEqual(expectedId, result.RouteValues["id"]);
            Assert.AreEqual(expectedOther, result.RouteValues["other"]);
            Assert.AreEqual(expectedObjValue, result.RouteValues["obj"]);
        }

        [Test]
        public void RedirectLocal_WithValidLocalUrl_ReturnsExpectedRedirectResult()
        {
            const string url = "/foo/bar";
            MvcControllerBaseWrapper sut = CreateSut();
            sut.Url = GetUrlHelperForIsLocalUrl();

            RedirectResult result = sut.RedirectLocal(url);

            Assert.IsNotNull(result);
            Assert.AreEqual(url, result.Url);
        }

        [Test]
        public void RedirectLocal_WithInvalidLocalUrl_ThrowsInvalidOperationException()
        {
            const string url = "www.foobar.com/foo/bar";
            MvcControllerBaseWrapper sut = CreateSut();
            sut.Url = GetUrlHelperForIsLocalUrl();

            Assert.Throws<InvalidOperationException>(() => sut.RedirectLocal(url));
        }

        [Test]
        public void RedirectLocal_WithEmptyLocalUrl_ReturnsRedirectToRoot()
        {
            string url = string.Empty;
            const string expectedRedirectUrl = "/";
            MvcControllerBaseWrapper sut = CreateSut();
            sut.Url = GetUrlHelperForIsLocalUrl();

            RedirectResult result = sut.RedirectLocal(url);

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedRedirectUrl, result.Url);
        }

        [Test]
        public void RedirectLocal_WithNullLocalUrl_ReturnsRedirectToRoot()
        {
            const string url = null;
            const string expectedRedirectUrl = "/";
            MvcControllerBaseWrapper sut = CreateSut();
            sut.Url = GetUrlHelperForIsLocalUrl();

            RedirectResult result = sut.RedirectLocal(url);

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedRedirectUrl, result.Url);
        }

        // FactoryMethods
        private MvcControllerBaseWrapper CreateSut()
        {
            return CreateSut(_mocks.ControllerContext.Object);
        }

        private MvcControllerBaseWrapper CreateSut(IControllerContext context)
        {
            return new MvcControllerBaseWrapper(context);
        }

        private ActionExecutedContext CreateFilterContext(MvcControllerBase controller)
        {
            RequestContext request = new RequestContext();
            ControllerContext context = new ControllerContext(request, controller);
            return new ActionExecutedContext(context, new Mock<ActionDescriptor>().Object, false, null);
        }

        // Adapted from ASP.NET MVC 3 Source
        private UrlHelper GetUrlHelperForIsLocalUrl(string baseUrl)
        {
            Mock<HttpContextBase> contextMock = new Mock<HttpContextBase>();
            contextMock.SetupGet(context => context.Request.Url).Returns(new Uri(baseUrl));
            RequestContext requestContext = new RequestContext(contextMock.Object, new RouteData());
            UrlHelper helper = new UrlHelper(requestContext);
            return helper;
        }

        private UrlHelper GetUrlHelperForIsLocalUrl()
        {
            return GetUrlHelperForIsLocalUrl("http://www.myblog.com/");
        }

    }
}
