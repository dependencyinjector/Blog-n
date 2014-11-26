using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Blogn.Infrastructure;

namespace Blogn.Controllers
{
    public abstract class MvcControllerBase : Controller
    {
        // Constructor
        protected MvcControllerBase(IControllerContext context)
        {
            Contract.IsNotNull(context, "context");
            _context = context;
        }

        // Properties
        private readonly IControllerContext _context;

        protected IStateManager State
        {
            get
            {
                return _context.State;
            }
        }

        protected ISettingManager Settings
        {
            get
            {
                return _context.Settings;
            }
        }

        // Methods
        public RedirectResult RedirectLocal(string path)
        {
            string virtualUrl = string.IsNullOrEmpty(path) ? "/" : path;
            if (!Url.IsLocalUrl(virtualUrl))
            {
                throw new InvalidOperationException("An attempt was made to navigate to a local url that is not local to the application.");
            }
            return Redirect(virtualUrl);
        }

        public RedirectToRouteResult RedirectToAction<T>(Expression<Action<T>> action, object values) where T : MvcControllerBase
        {
            return RedirectToAction<T>(action, new RouteValueDictionary(values));
        }

        public RedirectToRouteResult RedirectToAction<T>(Expression<Action<T>> action) where T : MvcControllerBase
        {
            return RedirectToAction<T>(action, null);
        }

        public RedirectToRouteResult RedirectToAction<T>(Expression<Action<T>> action, RouteValueDictionary values) where T : MvcControllerBase
        {
            MethodCallExpression body = action.Body as MethodCallExpression;
            Contract.Requires(body != null, "Expression must be method call");
            Contract.Requires(body.Object == action.Parameters[0], "Method Call must target lambda argument");
            string actionName = body.Method.Name;
            string controllerName = typeof(T).Name;
            if (controllerName.EndsWith("controller", StringComparison.OrdinalIgnoreCase))
            {
                controllerName = controllerName.Substring(0, controllerName.Length - 10);
            }
            values = values ?? new RouteValueDictionary();
            values.Add("controller", controllerName);
            values.Add("action", actionName);
            ParameterInfo[] parameters = body.Method.GetParameters();
            for (int index = 0; index < parameters.Length; index++)
            {
                string name = parameters[index].Name;
                object value = body.Arguments[index];
                ConstantExpression valueExpression = value as ConstantExpression;
                value = (valueExpression != null) ? valueExpression.Value : value;
                values.Add(name, value);
            }
            return new RedirectToRouteResult(values);
        }

    }
}