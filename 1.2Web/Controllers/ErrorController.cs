using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1._2Web.Controllers
{
    public class ErrorController : Controller{
        public ActionResult Index(String msgError){
            ViewBag.mensaje = msgError;
            return View();
        }
	}
}