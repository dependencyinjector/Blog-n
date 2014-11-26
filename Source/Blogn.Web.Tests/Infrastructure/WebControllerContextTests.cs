using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blogn.Infrastructure;
using Moq;
using NUnit.Framework;

namespace Blogn.Tests.Infrastructure
{
    [TestFixture]
    public class WebControllerContextTests
    {
        // SetUp & Mocks
        private Mock<IStateManager> _mockState;
        private Mock<ISettingManager> _mockSettings;

        [SetUp]
        public void SetUp()
        {
            _mockState=new Mock<IStateManager>();
            _mockSettings = new Mock<ISettingManager>();
        }

        [TearDown]
        public void TearDown()
        {
            _mockState = null;
            _mockSettings = null;
        }

        // Tests
        [Test]
        public void Instantiation_WithNullState_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => CreateSut(null, _mockSettings.Object));
        }

        [Test]
        public void Instantiation_WithNullSettings_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => CreateSut(_mockState.Object, null));
        }

        [Test]
        public void Instantiation_WithValidState_InitializesStateProperty()
        {
            IControllerContext sut = CreateSut(_mockState.Object, _mockSettings.Object);

            Assert.AreSame(_mockState.Object, sut.State);
        }

        [Test]
        public void Instantiation_WithValidSettings_InitializesSettingsProperty()
        {
            IControllerContext sut = CreateSut(_mockState.Object, _mockSettings.Object);

            Assert.AreSame(_mockSettings.Object, sut.Settings);
        }

        // FactoryMethods
        private WebControllerContext CreateSut()
        {
            return CreateSut(_mockState.Object, _mockSettings.Object);
        }

        private WebControllerContext CreateSut(IStateManager state, ISettingManager settings)
        {
            return new WebControllerContext(state, settings);
        }

    }
}
