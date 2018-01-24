using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _4._2Logistica;
using _3._2Logistica;
namespace _1._2Web.Controllers
{
    [Filtros.SesionIntranetAttribute]
    public class ArticuloController : Controller
    {
        public ActionResult Lista(String msj){
            try{
                List<entArticulo> lista = logArticulo.Instancia.ListarArticulos(0);
                ViewBag.mensaje = msj;
                return View(lista);
            }catch (Exception e){
                return RedirectToAction("Index", "Error", new { msgError = e.Message });
            }
        }

        [HttpGet]
        public ActionResult Nuevo()
        {
            List<entTipoArticulo> listaTA = logTipoArticulo.Instancia.ListarTipoArticulos();
            var lsTipoArticulo = new SelectList(listaTA, "idTipoArticulo", "Descripcion");
            ViewBag.ListaTA = lsTipoArticulo;
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(entArticulo a){
            try{
                Int16 pk = logArticulo.Instancia.InsertarArticulo(a);
                if (pk > 0){
                    return RedirectToAction("Lista",
                        new { msj = "Se inserto el Articulo con ID: " + pk.ToString() });
                }else {
                    return RedirectToAction("Nuevo");
                }
            }catch (Exception e){
                return RedirectToAction("Index", "Error", new { msgError = e.Message });
            }
        }
	}
}