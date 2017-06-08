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
    public class HIJOSController : Controller
    {
        private DBEntities2 db = new DBEntities2();

        // GET: HIJOS
        public ActionResult Index()
        {
            return View(db.HIJOS.ToList());
        }

        // GET: HIJOS/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HIJOS hIJOS = db.HIJOS.Find(id);
            if (hIJOS == null)
            {
                return HttpNotFound();
            }
            return View(hIJOS);
        }

        // GET: HIJOS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HIJOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_HIJO,NOMBRE_HIJO,EDAD_HIJO,NAC_HIJO")] HIJOS hIJOS)
        {
            if (ModelState.IsValid)
            {
                db.HIJOS.Add(hIJOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hIJOS);
        }

        // GET: HIJOS/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HIJOS hIJOS = db.HIJOS.Find(id);
            if (hIJOS == null)
            {
                return HttpNotFound();
            }
            return View(hIJOS);
        }

        // POST: HIJOS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_HIJO,NOMBRE_HIJO,EDAD_HIJO,NAC_HIJO")] HIJOS hIJOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hIJOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hIJOS);
        }

        // GET: HIJOS/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HIJOS hIJOS = db.HIJOS.Find(id);
            if (hIJOS == null)
            {
                return HttpNotFound();
            }
            return View(hIJOS);
        }

        // POST: HIJOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            HIJOS hIJOS = db.HIJOS.Find(id);
            db.HIJOS.Remove(hIJOS);
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
