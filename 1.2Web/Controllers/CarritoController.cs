using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _4._2Logistica;
using _3._2Logistica;
using _4._0Comunes;
using _4._3Ventas;
using _3._3Ventas;
using _3._0Comunes;

namespace _1._2Web.Controllers{
    public class CarritoController : Controller{

        public ActionResult ListaArticulo(Int16 idTipo){
            try {
                List<entArticulo> lista = logArticulo.Instancia.ListarArticulos(idTipo);
                ViewBag.lista = lista;
                return View();
	        }catch (Exception e){		
		        return RedirectToAction("Index", "Error", new { msgError = e.Message });
	        }

        }

        public ActionResult VerificarAcceso(FormCollection frm)
        {
            try
            {
                String Usuario = frm["txtUsuario"].ToString();
                String Password = frm["txtPassword"].ToString();
                entCliente c = logCliente.Instancia.VerificarAcceso(Usuario, Password);
                if (c != null)
                {
                    Session["cliente"] = c;
                    return RedirectToAction("Bienvenida");
                }
                return RedirectToAction("Index","Inicio");
            }
            catch (Exception e)
            {                
                return RedirectToAction("Index", "Error", new { msgError = e.Message });
            }
        }

        [Filtros.SesionExtranet]
        public ActionResult Bienvenida()
        {
            return View();
        }

        [Filtros.SesionExtranet]
        public ActionResult AgregarCarrito(FormCollection frm)
        {
            try
            {
                List<entVentaDet> lista = null;
                if (Session["carrito"] != null)
                {
                    lista = (List<entVentaDet>)Session["carrito"];
                }
                else
                {
                    lista = new List<entVentaDet>();
                }
                entVentaDet d = new entVentaDet();
                d.Cantidad = Convert.ToInt16(frm["txtCant"]);
                d.Precio = Convert.ToDecimal(frm["Precio"]);
                    entArticulo a = new entArticulo();
                    a.idArticulo = Convert.ToInt16(frm["idArticulo"]);
                    a.Nombre = frm["DArticulo"].ToString();
                    a.Imagen = frm["Imagen"].ToString();
                        entTipoArticulo t = new entTipoArticulo();
                        t.Descripcion = frm["Categoria"].ToString();
                    a.TipoArticulo = t;
                d.Articulo = a;
                lista.Add(d);

                Session["carrito"] = lista;
                return RedirectToAction("VerCarrito");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error", new { msgError = e.Message });
            }
        }

        [Filtros.SesionExtranet]
        public ActionResult VerCarrito()
        {
            //List<entVentaDet> lista = (List<entVentaDet>)Session["carrito"];
            //return View(lista);
            return View();
        }

        public ActionResult OpcionPago() {
            List<entUbigeo> listaU = logUbigeo.Instancia.ListarDepartamentos();
            var lsUbigeo = new SelectList(listaU, "idUbigeo", "Nombre");
            ViewBag.ListaDep = lsUbigeo;
            return PartialView();
        }
        public ActionResult LlenarProvinciasJSON(int idDepartamento) {
            var lista = logUbigeo.Instancia.ListarProvincias(idDepartamento);
            //Serializamos las provincias en JSON
            var JSONLista = Json(lista.ToList(), JsonRequestBehavior.AllowGet);
            return JSONLista;
        }
	}
}