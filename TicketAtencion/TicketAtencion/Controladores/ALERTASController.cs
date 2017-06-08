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
    public class ALERTASController : Controller
    {
        private DBEntities2 db = new DBEntities2();

        // GET: ALERTAS
        public ActionResult Index()
        {
            return View(db.ALERTAS.ToList());
        }

        // GET: ALERTAS/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALERTAS aLERTAS = db.ALERTAS.Find(id);
            if (aLERTAS == null)
            {
                return HttpNotFound();
            }
            return View(aLERTAS);
        }

        // GET: ALERTAS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ALERTAS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_ALERTA,SONIDO_ALERTA,COLOR_ALERTA,MAIL_ALERTA")] ALERTAS aLERTAS)
        {
            if (ModelState.IsValid)
            {
                db.ALERTAS.Add(aLERTAS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aLERTAS);
        }

        // GET: ALERTAS/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALERTAS aLERTAS = db.ALERTAS.Find(id);
            if (aLERTAS == null)
            {
                return HttpNotFound();
            }
            return View(aLERTAS);
        }

        // POST: ALERTAS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_ALERTA,SONIDO_ALERTA,COLOR_ALERTA,MAIL_ALERTA")] ALERTAS aLERTAS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aLERTAS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aLERTAS);
        }

        // GET: ALERTAS/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALERTAS aLERTAS = db.ALERTAS.Find(id);
            if (aLERTAS == null)
            {
                return HttpNotFound();
            }
            return View(aLERTAS);
        }

        // POST: ALERTAS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            ALERTAS aLERTAS = db.ALERTAS.Find(id);
            db.ALERTAS.Remove(aLERTAS);
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
