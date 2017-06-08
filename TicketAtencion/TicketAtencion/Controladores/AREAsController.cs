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
    public class AREAsController : Controller
    {
        private DBEntities2 db = new DBEntities2();

        // GET: AREAs
        public ActionResult Index()
        {
            return View(db.AREA.ToList());
        }

        // GET: AREAs/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AREA aREA = db.AREA.Find(id);
            if (aREA == null)
            {
                return HttpNotFound();
            }
            return View(aREA);
        }

        // GET: AREAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AREAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RUT_EMPRESA_PROV,ID_AREA,EMAIL_AREA,DESCRIPCION_AREA")] AREA aREA)
        {
            if (ModelState.IsValid)
            {
                db.AREA.Add(aREA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aREA);
        }

        // GET: AREAs/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AREA aREA = db.AREA.Find(id);
            if (aREA == null)
            {
                return HttpNotFound();
            }
            return View(aREA);
        }

        // POST: AREAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RUT_EMPRESA_PROV,ID_AREA,EMAIL_AREA,DESCRIPCION_AREA")] AREA aREA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aREA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aREA);
        }

        // GET: AREAs/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AREA aREA = db.AREA.Find(id);
            if (aREA == null)
            {
                return HttpNotFound();
            }
            return View(aREA);
        }

        // POST: AREAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            AREA aREA = db.AREA.Find(id);
            db.AREA.Remove(aREA);
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
