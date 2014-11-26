using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogn.Infrastructure
{
    public interface IControllerContext
    {
        IStateManager State { get; }
        ISettingManager Settings { get; }
    }
}
