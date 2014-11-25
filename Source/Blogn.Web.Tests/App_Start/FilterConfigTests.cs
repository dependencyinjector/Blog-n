using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using NUnit.Framework;

namespace Blogn.Tests
{
    [TestFixture]
    public class FilterConfigTests
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
        public void RegisterGlobalFilters_WithNullGlobalFiltersCollection_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => FilterConfig.RegisterGlobalFilters(null));
        }

        [Test]
        public void RegisterGlobalFilters_WithNullGlobalFiltersCollection_RegistersHandleErrorAttribute()
        {
            GlobalFilterCollection filters=new GlobalFilterCollection();

            FilterConfig.RegisterGlobalFilters(filters);

            Assert.IsNotNull(filters.SingleOrDefault(filter => filter.Instance.GetType() == typeof (HandleErrorAttribute)));
        }

    }
}
