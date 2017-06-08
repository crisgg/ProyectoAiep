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
    public class TELS_EMPRESAController : Controller
    {
        private DBEntities2 db = new DBEntities2();

        // GET: TELS_EMPRESA
        public ActionResult Index()
        {
            var tELS_EMPRESA = db.TELS_EMPRESA.Include(t => t.EMPRESA);
            return View(tELS_EMPRESA.ToList());
        }

        // GET: TELS_EMPRESA/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TELS_EMPRESA tELS_EMPRESA = db.TELS_EMPRESA.Find(id);
            if (tELS_EMPRESA == null)
            {
                return HttpNotFound();
            }
            return View(tELS_EMPRESA);
        }

        // GET: TELS_EMPRESA/Create
        public ActionResult Create()
        {
            ViewBag.RUT_EMPRESA_PROV = new SelectList(db.EMPRESA, "RUT_EMPRESA_PROV", "NOMBRE_EMPRESA");
            return View();
        }

        // POST: TELS_EMPRESA/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TEL_EMPRESA,ID_TEL_EMRPESA,RUT_EMPRESA_PROV")] TELS_EMPRESA tELS_EMPRESA)
        {
            if (ModelState.IsValid)
            {
                db.TELS_EMPRESA.Add(tELS_EMPRESA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RUT_EMPRESA_PROV = new SelectList(db.EMPRESA, "RUT_EMPRESA_PROV", "NOMBRE_EMPRESA", tELS_EMPRESA.RUT_EMPRESA_PROV);
            return View(tELS_EMPRESA);
        }

        // GET: TELS_EMPRESA/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TELS_EMPRESA tELS_EMPRESA = db.TELS_EMPRESA.Find(id);
            if (tELS_EMPRESA == null)
            {
                return HttpNotFound();
            }
            ViewBag.RUT_EMPRESA_PROV = new SelectList(db.EMPRESA, "RUT_EMPRESA_PROV", "NOMBRE_EMPRESA", tELS_EMPRESA.RUT_EMPRESA_PROV);
            return View(tELS_EMPRESA);
        }

        // POST: TELS_EMPRESA/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TEL_EMPRESA,ID_TEL_EMRPESA,RUT_EMPRESA_PROV")] TELS_EMPRESA tELS_EMPRESA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tELS_EMPRESA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RUT_EMPRESA_PROV = new SelectList(db.EMPRESA, "RUT_EMPRESA_PROV", "NOMBRE_EMPRESA", tELS_EMPRESA.RUT_EMPRESA_PROV);
            return View(tELS_EMPRESA);
        }

        // GET: TELS_EMPRESA/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TELS_EMPRESA tELS_EMPRESA = db.TELS_EMPRESA.Find(id);
            if (tELS_EMPRESA == null)
            {
                return HttpNotFound();
            }
            return View(tELS_EMPRESA);
        }

        // POST: TELS_EMPRESA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            TELS_EMPRESA tELS_EMPRESA = db.TELS_EMPRESA.Find(id);
            db.TELS_EMPRESA.Remove(tELS_EMPRESA);
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
