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
    public class SERVICIOsController : Controller
    {
        private DBEntities2 db = new DBEntities2();

        // GET: SERVICIOs
        public ActionResult Index()
        {
            var sERVICIO = db.SERVICIO.Include(s => s.EMPRESA);
            return View(sERVICIO.ToList());
        }

        // GET: SERVICIOs/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SERVICIO sERVICIO = db.SERVICIO.Find(id);
            if (sERVICIO == null)
            {
                return HttpNotFound();
            }
            return View(sERVICIO);
        }

        // GET: SERVICIOs/Create
        public ActionResult Create()
        {
            ViewBag.RUT_EMPRESA_PROV = new SelectList(db.EMPRESA, "RUT_EMPRESA_PROV", "NOMBRE_EMPRESA");
            return View();
        }

        // POST: SERVICIOs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_SERV,RUT_EMPRESA_PROV,NOMBRE_SERVICIO")] SERVICIO sERVICIO)
        {
            if (ModelState.IsValid)
            {
                db.SERVICIO.Add(sERVICIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RUT_EMPRESA_PROV = new SelectList(db.EMPRESA, "RUT_EMPRESA_PROV", "NOMBRE_EMPRESA", sERVICIO.RUT_EMPRESA_PROV);
            return View(sERVICIO);
        }

        // GET: SERVICIOs/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SERVICIO sERVICIO = db.SERVICIO.Find(id);
            if (sERVICIO == null)
            {
                return HttpNotFound();
            }
            ViewBag.RUT_EMPRESA_PROV = new SelectList(db.EMPRESA, "RUT_EMPRESA_PROV", "NOMBRE_EMPRESA", sERVICIO.RUT_EMPRESA_PROV);
            return View(sERVICIO);
        }

        // POST: SERVICIOs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_SERV,RUT_EMPRESA_PROV,NOMBRE_SERVICIO")] SERVICIO sERVICIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sERVICIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RUT_EMPRESA_PROV = new SelectList(db.EMPRESA, "RUT_EMPRESA_PROV", "NOMBRE_EMPRESA", sERVICIO.RUT_EMPRESA_PROV);
            return View(sERVICIO);
        }

        // GET: SERVICIOs/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SERVICIO sERVICIO = db.SERVICIO.Find(id);
            if (sERVICIO == null)
            {
                return HttpNotFound();
            }
            return View(sERVICIO);
        }

        // POST: SERVICIOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            SERVICIO sERVICIO = db.SERVICIO.Find(id);
            db.SERVICIO.Remove(sERVICIO);
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
