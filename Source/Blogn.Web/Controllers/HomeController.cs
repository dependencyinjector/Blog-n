using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blogn.Infrastructure;

namespace Blogn.Controllers
{
    public class HomeController : MvcControllerBase
    {
        // Constructor
        public HomeController(IControllerContext context) : base(context)
        {
        }

        // Action Methods
        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }
    }
}