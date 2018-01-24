using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1._2Web.Filtros
{
    public class SesionExtranetAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.HttpContext.Session["cliente"] == null)
            {
                filterContext.Result = new RedirectResult("~/Inicio/index");
            }
            base.OnActionExecuted(filterContext);
        }
    }
}