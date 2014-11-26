using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blogn.Controllers;
using Blogn.Infrastructure;

namespace Blogn.Tests.Controllers
{
    public class MvcControllerBaseWrapper : MvcControllerBase
    {
        // Constructor
        public MvcControllerBaseWrapper(IControllerContext context) : base(context)
        {
        }

        // Properties
        public IStateManager ProtectedState
        {
            get
            {
                return State;
            }
        }

        public ISettingManager ProtectedSettings
        {
            get
            {
                return Settings;
            }
        }
    }
}
