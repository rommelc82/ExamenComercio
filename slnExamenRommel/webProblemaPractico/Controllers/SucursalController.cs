using BeExamen;
using DaExamen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webProblemaPractico.Controllers
{
    public class SucursalController : Controller
    {
        //
        // GET: /Sucursal/
        daSucursal obj = new daSucursal();
        daBanco objBanco = new daBanco();
        public ActionResult Index(int? idbanco = 0)
        {
            return View(obj.list(idbanco));
        }

        //
        // GET: /Sucursal/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Sucursal/Create

        public ActionResult Create()
        {
            ViewBag.bancos = new SelectList(objBanco.list(), "id", "nombre");
            return View();
        }

        //
        // POST: /Sucursal/Create

        [HttpPost]
        public ActionResult Create(sucursal eSucursal)
        {
            try
            {                
                int id = obj.SucursalGuardar(eSucursal);
                return Redirect("~/sucursal/Edit/?id=" + id);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Sucursal/Edit/5

        public ActionResult Edit(int id)
        {

            return View(obj.SucursalxId(id));
        }

        //
        // POST: /Sucursal/Edit/5

        [HttpPost]
        public ActionResult Edit(sucursal eSucursal)
        {
            try
            {
                // TODO: Add update logic here
                obj.SucursalGuardar(eSucursal);
                return Redirect("~/sucursal/Edit/?id=" + eSucursal.id);
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
