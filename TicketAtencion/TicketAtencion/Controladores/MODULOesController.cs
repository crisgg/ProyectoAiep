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
    public class MODULOesController : Controller
    {
        private DBEntities2 db = new DBEntities2();

        // GET: MODULOes
        public ActionResult Index()
        {
            return View(db.MODULO.ToList());
        }

        // GET: MODULOes/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MODULO mODULO = db.MODULO.Find(id);
            if (mODULO == null)
            {
                return HttpNotFound();
            }
            return View(mODULO);
        }

        // GET: MODULOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MODULOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_MODULO,DESCRIPCION_MODULO")] MODULO mODULO)
        {
            if (ModelState.IsValid)
            {
                db.MODULO.Add(mODULO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mODULO);
        }

        // GET: MODULOes/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MODULO mODULO = db.MODULO.Find(id);
            if (mODULO == null)
            {
                return HttpNotFound();
            }
            return View(mODULO);
        }

        // POST: MODULOes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_MODULO,DESCRIPCION_MODULO")] MODULO mODULO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mODULO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mODULO);
        }

        // GET: MODULOes/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MODULO mODULO = db.MODULO.Find(id);
            if (mODULO == null)
            {
                return HttpNotFound();
            }
            return View(mODULO);
        }

        // POST: MODULOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            MODULO mODULO = db.MODULO.Find(id);
            db.MODULO.Remove(mODULO);
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
