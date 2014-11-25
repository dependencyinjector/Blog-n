using System.Web;
using System.Web.Mvc;

namespace Blogn
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            Contract.IsNotNull(filters, "filters");
            filters.Add(new HandleErrorAttribute());
        }
    }
}
