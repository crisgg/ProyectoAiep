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
    public class DISTRITOSController : Controller
    {
        private DBEntities2 db = new DBEntities2();

        // GET: DISTRITOS
        public ActionResult Index()
        {
            var dISTRITOS = db.DISTRITOS.Include(d => d.REGIONES);
            return View(dISTRITOS.ToList());
        }

        // GET: DISTRITOS/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DISTRITOS dISTRITOS = db.DISTRITOS.Find(id);
            if (dISTRITOS == null)
            {
                return HttpNotFound();
            }
            return View(dISTRITOS);
        }

        // GET: DISTRITOS/Create
        public ActionResult Create()
        {
            ViewBag.ID_REGION = new SelectList(db.REGIONES, "ID_REGION", "NOMBRE_REGION");
            return View();
        }

        // POST: DISTRITOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_DISTRIRO,ID_REGION,NOM_DISTRITO")] DISTRITOS dISTRITOS)
        {
            if (ModelState.IsValid)
            {
                db.DISTRITOS.Add(dISTRITOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_REGION = new SelectList(db.REGIONES, "ID_REGION", "NOMBRE_REGION", dISTRITOS.ID_REGION);
            return View(dISTRITOS);
        }

        // GET: DISTRITOS/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DISTRITOS dISTRITOS = db.DISTRITOS.Find(id);
            if (dISTRITOS == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_REGION = new SelectList(db.REGIONES, "ID_REGION", "NOMBRE_REGION", dISTRITOS.ID_REGION);
            return View(dISTRITOS);
        }

        // POST: DISTRITOS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_DISTRIRO,ID_REGION,NOM_DISTRITO")] DISTRITOS dISTRITOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dISTRITOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_REGION = new SelectList(db.REGIONES, "ID_REGION", "NOMBRE_REGION", dISTRITOS.ID_REGION);
            return View(dISTRITOS);
        }

        // GET: DISTRITOS/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DISTRITOS dISTRITOS = db.DISTRITOS.Find(id);
            if (dISTRITOS == null)
            {
                return HttpNotFound();
            }
            return View(dISTRITOS);
        }

        // POST: DISTRITOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            DISTRITOS dISTRITOS = db.DISTRITOS.Find(id);
            db.DISTRITOS.Remove(dISTRITOS);
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
