using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bdd;

namespace TicketAtencion.Controladores
{
    public class PAISESController : Controller
    {
        private DBEntities2 db = new DBEntities2();

        // GET: PAISES
        public ActionResult Index()
        {
            var pAISES = db.PAISES.Include(p => p.MONEDA);
            return View(pAISES.ToList());
        }

        // GET: PAISES/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAISES pAISES = db.PAISES.Find(id);
            if (pAISES == null)
            {
                return HttpNotFound();
            }
            return View(pAISES);
        }

        // GET: PAISES/Create
        public ActionResult Create()
        {
            ViewBag.ID_MONEDA = new SelectList(db.MONEDA, "ID_MONEDA", "MONEDA1");
            return View();
        }

        // POST: PAISES/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PAIS,ID_MONEDA,NOM_PAIS")] PAISES pAISES)
        {
            if (ModelState.IsValid)
            {
                db.PAISES.Add(pAISES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_MONEDA = new SelectList(db.MONEDA, "ID_MONEDA", "MONEDA1", pAISES.ID_MONEDA);
            return View(pAISES);
        }

        // GET: PAISES/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAISES pAISES = db.PAISES.Find(id);
            if (pAISES == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_MONEDA = new SelectList(db.MONEDA, "ID_MONEDA", "MONEDA1", pAISES.ID_MONEDA);
            return View(pAISES);
        }

        // POST: PAISES/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PAIS,ID_MONEDA,NOM_PAIS")] PAISES pAISES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pAISES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_MONEDA = new SelectList(db.MONEDA, "ID_MONEDA", "MONEDA1", pAISES.ID_MONEDA);
            return View(pAISES);
        }

        // GET: PAISES/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAISES pAISES = db.PAISES.Find(id);
            if (pAISES == null)
            {
                return HttpNotFound();
            }
            return View(pAISES);
        }

        // POST: PAISES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            PAISES pAISES = db.PAISES.Find(id);
            db.PAISES.Remove(pAISES);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
