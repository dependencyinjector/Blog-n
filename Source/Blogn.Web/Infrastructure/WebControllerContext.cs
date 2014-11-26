using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogn.Infrastructure
{
    public class WebControllerContext : IControllerContext
    {
        // Constructor
        public WebControllerContext(IStateManager state, ISettingManager settings)
        {
            Contract.IsNotNull(state, "state");
            Contract.IsNotNull(settings, "settings");

            State = state;
            Settings = settings;
        }

        // Properties
        public IStateManager State { get; private set; }

        public ISettingManager Settings { get; private set; }
    }
}