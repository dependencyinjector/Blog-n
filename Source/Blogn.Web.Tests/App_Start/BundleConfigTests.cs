using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Optimization;
using Blogn.Constants;
using NUnit.Framework;

namespace Blogn.Tests
{
    [TestFixture]
    public class BundleConfigTests
    {
        // SetUp & Mocks
        [SetUp]
        public void Setup()
        {

        }

        [TearDown]
        public void TearDown()
        {
            
        }

        // Tests
        [Test]
        public void RegisterBundles_WithNullBundleCollectionThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => BundleConfig.RegisterBundles(null));
        }

        [Test]
        public void RegisterBundles_WithValidBundlesCollection_RegistersJQuery()
        {
            BundleCollection bundles = new BundleCollection();
            
            BundleConfig.RegisterBundles(bundles);

            ScriptBundle item = (bundles.SingleOrDefault(bundle => bundle.Path == Bundles.Scripts.JQuery) as ScriptBundle);
            Assert.IsNotNull(item);
        }

        [Test]
        public void RegisterBundles_WithValidBundlesCollection_RegistersJQueryValidate()
        {
            BundleCollection bundles = new BundleCollection();

            BundleConfig.RegisterBundles(bundles);

            ScriptBundle item = (bundles.SingleOrDefault(bundle => bundle.Path == Bundles.Scripts.Validation) as ScriptBundle);
            Assert.IsNotNull(item);
        }

        [Test]
        public void RegisterBundles_WithValidBundlesCollection_RegistersModernizr()
        {
            BundleCollection bundles = new BundleCollection();

            BundleConfig.RegisterBundles(bundles);

            ScriptBundle item = (bundles.SingleOrDefault(bundle => bundle.Path == Bundles.Scripts.Modernizr) as ScriptBundle);
            Assert.IsNotNull(item);
        }

        [Test]
        public void RegisterBundles_WithValidBundlesCollection_RegistersBootstrapScripts()
        {
            BundleCollection bundles = new BundleCollection();

            BundleConfig.RegisterBundles(bundles);

            ScriptBundle item = (bundles.SingleOrDefault(bundle => bundle.Path == Bundles.Scripts.Bootstrap) as ScriptBundle);
            Assert.IsNotNull(item);
        }

        [Test]
        public void RegisterBundles_WithValidBundlesCollection_RegistersThemeBundle()
        {
            BundleCollection bundles = new BundleCollection();

            BundleConfig.RegisterBundles(bundles);

            StyleBundle item = (bundles.SingleOrDefault(bundle => bundle.Path == Bundles.Styles.Theme) as StyleBundle);
            Assert.IsNotNull(item);
        }

        [Test]
        public void RegisterBundles_SetsEnableOptimizationsOnlyInReleaseBuild()
        {
            BundleCollection bundles = new BundleCollection();

            BundleConfig.RegisterBundles(bundles);

            Assert.AreEqual(!BuildInfo.IsDebug, BundleTable.EnableOptimizations);
        }
    }
}
