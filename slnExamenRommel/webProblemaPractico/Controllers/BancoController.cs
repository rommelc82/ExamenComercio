using BeExamen;
using DaExamen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webProblemaPractico.Controllers
{
    public class BancoController : Controller
    {
        //
        // GET: /Banco/
        daBanco obj = new daBanco();
        public ActionResult Index()
        {
            return View(obj.list());
        }

        //
        // GET: /Banco/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Banco/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Banco/Create

        [HttpPost]
        public ActionResult Create(banco ebanco)
        {
            try
            {
                int id = obj.bancoGuardar(ebanco);
                return Redirect("~/Banco/Edit/?id=" + id);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Banco/Edit/5

        public ActionResult Edit(int id)
        {

            return View(obj.bancoxId(id));
        }

        //
        // POST: /Banco/Edit/5

        [HttpPost]
        public ActionResult Edit(banco ebanco)
        {
            try
            {
                // TODO: Add update logic here
                obj.bancoGuardar(ebanco);
                return Redirect("~/Banco/Edit/?id=" + ebanco.id);
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
