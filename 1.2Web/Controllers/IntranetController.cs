using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _4._0Comunes;
using _4._1Seguridad;
using _3._1Seguridad;

namespace _1._2Web.Controllers{
    public class IntranetController : Controller{

        public ActionResult Login(String msg){
            ViewBag.mensaje = msg;
            return View();
        }

        public ActionResult VerificarAcceso(FormCollection frm){
            try{
                String Usuario = frm["txtUsuario"].ToString();
                String Password = frm["txtPassword"].ToString();
                entUsuario u = logUsuario.Instancia.VerificarAcceso(Usuario, Password);
                if (u != null){
                    if (!u.Activo)
                    {
                        return RedirectToAction("Login",
                            new { msg = "Su usuario ha sido dado de baja" });
                    }
                    //crear atributo en session
                    Session["usuario"] = u;
                    return RedirectToAction("MenuPrincipal");
                }else{
                    return RedirectToAction("Login",
                        new { msg = "Usuario o Password no valido" });
                }
            }catch (Exception e){
                return RedirectToAction("Index", "Error", new { msgError = e.Message });
            }
        }

        [Filtros.SesionIntranetAttribute]
        public ActionResult MenuPrincipal() {
            return View();
        }
    }
}