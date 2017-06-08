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
    public class TIPOS_METADTAController : Controller
    {
        private DBEntities2 db = new DBEntities2();

        // GET: TIPOS_METADTA
        public ActionResult Index()
        {
            return View(db.TIPOS_METADTA.ToList());
        }

        // GET: TIPOS_METADTA/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPOS_METADTA tIPOS_METADTA = db.TIPOS_METADTA.Find(id);
            if (tIPOS_METADTA == null)
            {
                return HttpNotFound();
            }
            return View(tIPOS_METADTA);
        }

        // GET: TIPOS_METADTA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TIPOS_METADTA/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TIPO_META,DESC_TIPO_META")] TIPOS_METADTA tIPOS_METADTA)
        {
            if (ModelState.IsValid)
            {
                db.TIPOS_METADTA.Add(tIPOS_METADTA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tIPOS_METADTA);
        }

        // GET: TIPOS_METADTA/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPOS_METADTA tIPOS_METADTA = db.TIPOS_METADTA.Find(id);
            if (tIPOS_METADTA == null)
            {
                return HttpNotFound();
            }
            return View(tIPOS_METADTA);
        }

        // POST: TIPOS_METADTA/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TIPO_META,DESC_TIPO_META")] TIPOS_METADTA tIPOS_METADTA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIPOS_METADTA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tIPOS_METADTA);
        }

        // GET: TIPOS_METADTA/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPOS_METADTA tIPOS_METADTA = db.TIPOS_METADTA.Find(id);
            if (tIPOS_METADTA == null)
            {
                return HttpNotFound();
            }
            return View(tIPOS_METADTA);
        }

        // POST: TIPOS_METADTA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            TIPOS_METADTA tIPOS_METADTA = db.TIPOS_METADTA.Find(id);
            db.TIPOS_METADTA.Remove(tIPOS_METADTA);
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
