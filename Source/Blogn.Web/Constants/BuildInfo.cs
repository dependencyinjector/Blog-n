using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Blogn.Constants
{
    public static class BuildInfo
    {
#if DEBUG
        public const bool IsDebug = true;
#else
        public const bool IsDebug = false;
#endif

        public static readonly string Version = Assembly.GetAssembly(typeof (Contract)).GetName().Version.ToString();

    }
}