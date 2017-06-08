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
    public class SLAsController : Controller
    {
        private DBEntities2 db = new DBEntities2();

        // GET: SLAs
        public ActionResult Index()
        {
            var sLA = db.SLA.Include(s => s.ALERTAS).Include(s => s.SERVICIO_EMPRESA);
            return View(sLA.ToList());
        }

        // GET: SLAs/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SLA sLA = db.SLA.Find(id);
            if (sLA == null)
            {
                return HttpNotFound();
            }
            return View(sLA);
        }

        // GET: SLAs/Create
        public ActionResult Create()
        {
            ViewBag.ID_ALERTA = new SelectList(db.ALERTAS, "ID_ALERTA", "ID_ALERTA");
            ViewBag.ID_SERVI_EMP = new SelectList(db.SERVICIO_EMPRESA, "ID_SERVI_EMP", "ID_SERVI_EMP");
            return View();
        }

        // POST: SLAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_SLA,ID_ALERTA,ID_SERVI_EMP,NOMBRE_SLA,IMPORTANCIA_SLA,URGENCIA_SLA,IMPACTO_SLA")] SLA sLA)
        {
            if (ModelState.IsValid)
            {
                db.SLA.Add(sLA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ALERTA = new SelectList(db.ALERTAS, "ID_ALERTA", "ID_ALERTA", sLA.ID_ALERTA);
            ViewBag.ID_SERVI_EMP = new SelectList(db.SERVICIO_EMPRESA, "ID_SERVI_EMP", "ID_SERVI_EMP", sLA.ID_SERVI_EMP);
            return View(sLA);
        }

        // GET: SLAs/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SLA sLA = db.SLA.Find(id);
            if (sLA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ALERTA = new SelectList(db.ALERTAS, "ID_ALERTA", "ID_ALERTA", sLA.ID_ALERTA);
            ViewBag.ID_SERVI_EMP = new SelectList(db.SERVICIO_EMPRESA, "ID_SERVI_EMP", "ID_SERVI_EMP", sLA.ID_SERVI_EMP);
            return View(sLA);
        }

        // POST: SLAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_SLA,ID_ALERTA,ID_SERVI_EMP,NOMBRE_SLA,IMPORTANCIA_SLA,URGENCIA_SLA,IMPACTO_SLA")] SLA sLA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sLA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ALERTA = new SelectList(db.ALERTAS, "ID_ALERTA", "ID_ALERTA", sLA.ID_ALERTA);
            ViewBag.ID_SERVI_EMP = new SelectList(db.SERVICIO_EMPRESA, "ID_SERVI_EMP", "ID_SERVI_EMP", sLA.ID_SERVI_EMP);
            return View(sLA);
        }

        // GET: SLAs/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SLA sLA = db.SLA.Find(id);
            if (sLA == null)
            {
                return HttpNotFound();
            }
            return View(sLA);
        }

        // POST: SLAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            SLA sLA = db.SLA.Find(id);
            db.SLA.Remove(sLA);
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
