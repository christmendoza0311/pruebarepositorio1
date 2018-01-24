using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1._2Web.Controllers
{
    public class InicioController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection frm)
        {
            String mensaje = "";
            if (frm["btnHola"] != null) {
                mensaje = "Hola " + frm["txtnombre"].ToString();
            }else if (frm["btnAdios"] != null){
                mensaje = "Adios " + frm["txtnombre"].ToString();
            }
            ViewBag.mensajito = mensaje;
            return View();
        }
	}
}