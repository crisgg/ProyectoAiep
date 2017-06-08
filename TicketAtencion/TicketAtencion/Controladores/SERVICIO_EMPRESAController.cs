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
    public class SERVICIO_EMPRESAController : Controller
    {
        private DBEntities2 db = new DBEntities2();

        // GET: SERVICIO_EMPRESA
        public ActionResult Index()
        {
            var sERVICIO_EMPRESA = db.SERVICIO_EMPRESA.Include(s => s.EMPRESA_CLI).Include(s => s.SERVICIO);
            return View(sERVICIO_EMPRESA.ToList());
        }

        // GET: SERVICIO_EMPRESA/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SERVICIO_EMPRESA sERVICIO_EMPRESA = db.SERVICIO_EMPRESA.Find(id);
            if (sERVICIO_EMPRESA == null)
            {
                return HttpNotFound();
            }
            return View(sERVICIO_EMPRESA);
        }

        // GET: SERVICIO_EMPRESA/Create
        public ActionResult Create()
        {
            ViewBag.ID_EMPRESA = new SelectList(db.EMPRESA_CLI, "ID_EMPRESA", "RUT_EMPRESA_PROV");
            ViewBag.ID_SERV = new SelectList(db.SERVICIO, "ID_SERV", "RUT_EMPRESA_PROV");
            return View();
        }

        // POST: SERVICIO_EMPRESA/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_SERV,ID_EMPRESA,ID_SERVI_EMP")] SERVICIO_EMPRESA sERVICIO_EMPRESA)
        {
            if (ModelState.IsValid)
            {
                db.SERVICIO_EMPRESA.Add(sERVICIO_EMPRESA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_EMPRESA = new SelectList(db.EMPRESA_CLI, "ID_EMPRESA", "RUT_EMPRESA_PROV", sERVICIO_EMPRESA.ID_EMPRESA);
            ViewBag.ID_SERV = new SelectList(db.SERVICIO, "ID_SERV", "RUT_EMPRESA_PROV", sERVICIO_EMPRESA.ID_SERV);
            return View(sERVICIO_EMPRESA);
        }

        // GET: SERVICIO_EMPRESA/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SERVICIO_EMPRESA sERVICIO_EMPRESA = db.SERVICIO_EMPRESA.Find(id);
            if (sERVICIO_EMPRESA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_EMPRESA = new SelectList(db.EMPRESA_CLI, "ID_EMPRESA", "RUT_EMPRESA_PROV", sERVICIO_EMPRESA.ID_EMPRESA);
            ViewBag.ID_SERV = new SelectList(db.SERVICIO, "ID_SERV", "RUT_EMPRESA_PROV", sERVICIO_EMPRESA.ID_SERV);
            return View(sERVICIO_EMPRESA);
        }

        // POST: SERVICIO_EMPRESA/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_SERV,ID_EMPRESA,ID_SERVI_EMP")] SERVICIO_EMPRESA sERVICIO_EMPRESA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sERVICIO_EMPRESA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_EMPRESA = new SelectList(db.EMPRESA_CLI, "ID_EMPRESA", "RUT_EMPRESA_PROV", sERVICIO_EMPRESA.ID_EMPRESA);
            ViewBag.ID_SERV = new SelectList(db.SERVICIO, "ID_SERV", "RUT_EMPRESA_PROV", sERVICIO_EMPRESA.ID_SERV);
            return View(sERVICIO_EMPRESA);
        }

        // GET: SERVICIO_EMPRESA/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SERVICIO_EMPRESA sERVICIO_EMPRESA = db.SERVICIO_EMPRESA.Find(id);
            if (sERVICIO_EMPRESA == null)
            {
                return HttpNotFound();
            }
            return View(sERVICIO_EMPRESA);
        }

        // POST: SERVICIO_EMPRESA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            SERVICIO_EMPRESA sERVICIO_EMPRESA = db.SERVICIO_EMPRESA.Find(id);
            db.SERVICIO_EMPRESA.Remove(sERVICIO_EMPRESA);
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
