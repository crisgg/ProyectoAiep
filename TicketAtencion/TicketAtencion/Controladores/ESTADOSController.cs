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
    public class ESTADOSController : Controller
    {
        private DBEntities2 db = new DBEntities2();

        // GET: ESTADOS
        public ActionResult Index()
        {
            return View(db.ESTADOS.ToList());
        }

        // GET: ESTADOS/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTADOS eSTADOS = db.ESTADOS.Find(id);
            if (eSTADOS == null)
            {
                return HttpNotFound();
            }
            return View(eSTADOS);
        }

        // GET: ESTADOS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ESTADOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RUT_EMPRESA_PROV,ID_ESTADO,DESCRIPCION_ESTADO")] ESTADOS eSTADOS)
        {
            if (ModelState.IsValid)
            {
                db.ESTADOS.Add(eSTADOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eSTADOS);
        }

        // GET: ESTADOS/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTADOS eSTADOS = db.ESTADOS.Find(id);
            if (eSTADOS == null)
            {
                return HttpNotFound();
            }
            return View(eSTADOS);
        }

        // POST: ESTADOS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RUT_EMPRESA_PROV,ID_ESTADO,DESCRIPCION_ESTADO")] ESTADOS eSTADOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eSTADOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eSTADOS);
        }

        // GET: ESTADOS/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTADOS eSTADOS = db.ESTADOS.Find(id);
            if (eSTADOS == null)
            {
                return HttpNotFound();
            }
            return View(eSTADOS);
        }

        // POST: ESTADOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            ESTADOS eSTADOS = db.ESTADOS.Find(id);
            db.ESTADOS.Remove(eSTADOS);
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
