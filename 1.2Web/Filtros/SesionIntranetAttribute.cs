using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1._2Web.Filtros
{
    public class SesionIntranetAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.HttpContext.Session["usuario"] == null)
            {
                filterContext.Result = new RedirectResult("~/Intranet/Login?msg=DebeIniciarSesion");
            }
            base.OnActionExecuted(filterContext);
        }
    }
}