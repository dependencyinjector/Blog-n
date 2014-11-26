using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blogn.Infrastructure;
using Moq;

namespace Blogn.Tests.Controllers
{
    public class BaseControllerMocks
    {
        // Constructor
        public BaseControllerMocks()
        {
            Settings = new Mock<ISettingManager>();
            State = new Mock<IStateManager>();
            ControllerContext = new Mock<IControllerContext>();
            ControllerContext.SetupGet(mock => mock.Settings).Returns(Settings.Object);
            ControllerContext.SetupGet(mock => mock.State).Returns(State.Object);
            InitializeDefaultSettings();
            InitializeDefaultState();
        }

        // Properties
        public Mock<ISettingManager> Settings { get; set; }

        public Mock<IStateManager> State { get; set; }

        public Mock<IControllerContext> ControllerContext { get; set; }

        // Methods
        public void InitializeDefaultState()
        {
            
        }

        public void InitializeDefaultSettings()
        {
            
        }
    }
}
