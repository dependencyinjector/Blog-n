using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Blogn.Constants;
using NUnit.Framework;

namespace Blogn.Tests.Constants
{
    [TestFixture]
    public class BuildInfoTests
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
        public void Version_ReturnsAssemblyVersionOfCoreAssembly()
        {
            string expected = Assembly.GetAssembly(typeof (Contract)).GetName().Version.ToString();

            string result = BuildInfo.Version;

            Assert.AreEqual(expected, result);
        }

#if DEBUG
        [Test]
        public void IsDebug_ReturnsTrue()
        {
            Assert.IsTrue(BuildInfo.IsDebug);
        }
#else
        [Test]
        public void IsDebug_ReturnsFalse()
        {
            Assert.IsFalse(BuildInfo.IsDebug);
        }
#endif

    }
}
