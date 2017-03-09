using BeExamen;
using DaExamen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webProblemaPractico.Controllers
{
    public class OrdenpagoController : Controller
    {
        //
        // GET: /ordenpago/
        daOrdenPago obj = new daOrdenPago();
        daSucursal objSucursal = new daSucursal();
        daBanco objBanco = new daBanco();
        public ActionResult Index()
        {
            return View(obj.list());
        }

        //
        // GET: /ordenpago/Details/5
    
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /ordenpago/Create

        public ActionResult Create(string idbanco)
        {
            ViewBag.bancos = new SelectList(objBanco.list(), "id", "nombre");

            if (!string.IsNullOrEmpty(idbanco))
            {
                ViewBag.sucursales = objSucursal.list(Convert.ToInt32(idbanco));
            }
            else
            {
                ViewBag.sucursales = objSucursal.list(0);
            }

            ViewBag.estados = obj.listEstadoOp();

            return View();
        }

        //
        // POST: /ordenpago/Create

        [HttpPost]
        public ActionResult Create(ordenpago eordenpago)
        {
            try
            {                
                int id = obj.ordenpagoGuardar(eordenpago);
                return Redirect("~/ordenpago/Edit/?id=" + id);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /ordenpago/Edit/5

        public ActionResult Edit(int id)
        {
            ViewBag.id = id;
            ordenpago eordenpago = obj.ordenpagoxId(id);
            ViewBag.estado = new SelectList(obj.listEstadoOp(), "id", "descripcion", eordenpago.estado);
            return View(eordenpago);
        }

        //
        // POST: /ordenpago/Edit/5

        [HttpPost]
        public ActionResult Edit(ordenpago eordenpago)
        {
            try
            {
                ViewBag.id = eordenpago.id;
                ViewBag.estado = new SelectList(obj.listEstadoOp(), "id", "descripcion");  
                obj.ordenpagoGuardar(eordenpago);
                return Redirect("~/ordenpago/Edit/?id=" + eordenpago.id);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                obj.eliminar(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
