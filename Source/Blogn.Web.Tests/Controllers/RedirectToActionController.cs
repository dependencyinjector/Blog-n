using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Blogn.Controllers;
using Blogn.Infrastructure;

namespace Blogn.Tests.Controllers
{
    public class RedirectToActionController : MvcControllerBase
    {
        // Constructor
        public RedirectToActionController(IControllerContext context) : base(context)
        {
        }

        // Action Methods
        public ActionResult Index()
        {
            return Content("Index");
        }

        public ActionResult ById(int id)
        {
            return Content(string.Format("Id: {0}", id));
        }

        public ActionResult MultipleParameters(int id, string other)
        {
            return Content(string.Format("Id: {0}, Other: {1}", id, other));
        }
    }
}
