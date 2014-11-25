using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Blogn.Controllers;
using NUnit.Framework;

namespace Blogn.Tests.Controllers
{
    [TestFixture]
    public class UnitTest
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
        public void Index_Get_ReturnsDefaultView()
        {
            HomeController sut = CreateSut();

            ViewResult result = sut.Index();

            Assert.IsNotNull(result);
            Assert.IsTrue(string.IsNullOrWhiteSpace(result.ViewName) || result.ViewName.Equals("index", StringComparison.CurrentCultureIgnoreCase));
        }

        // FactoryMethods
        private HomeController CreateSut()
        {
            return new HomeController();
        }
    }
}
