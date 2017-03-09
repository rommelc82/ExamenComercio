using BeExamen;
using DaExamen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeApiJson.Areas.Api.Controllers
{
    public class OrdenPagoController : Controller
    {
        daOrdenPago obj = new daOrdenPago();
        public IEnumerable<BeExamen.ordenpago> GetAllOrdenPago(string sSucursal, string sMoneda)
        {
            List<ordenpago> lista = new List<ordenpago>();
            lista = obj.ordenpagoxSucursaMoneda(sSucursal, sMoneda);
            return lista.AsEnumerable();
        }
        //
        // GET: /Api/OrdenPago/
        [HttpGet]
        public JsonResult GetOrdenes(string sSucursal, string sMoneda)
        {
            sSucursal = sSucursal == null ? "" : sSucursal;
            sMoneda = sMoneda == null ? "" : sMoneda;
            List<ordenpago> lista = new List<ordenpago>();
            lista = obj.ordenpagoxSucursaMoneda(sSucursal, sMoneda);
            return Json(lista,JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Api/OrdenPago/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Api/OrdenPago/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Api/OrdenPago/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Api/OrdenPago/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Api/OrdenPago/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Api/OrdenPago/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Api/OrdenPago/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
