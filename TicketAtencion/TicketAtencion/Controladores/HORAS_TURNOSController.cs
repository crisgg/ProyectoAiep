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
    public class HORAS_TURNOSController : Controller
    {
        private DBEntities2 db = new DBEntities2();

        // GET: HORAS_TURNOS
        public ActionResult Index()
        {
            var hORAS_TURNOS = db.HORAS_TURNOS.Include(h => h.EMPRESA);
            return View(hORAS_TURNOS.ToList());
        }

        // GET: HORAS_TURNOS/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HORAS_TURNOS hORAS_TURNOS = db.HORAS_TURNOS.Find(id);
            if (hORAS_TURNOS == null)
            {
                return HttpNotFound();
            }
            return View(hORAS_TURNOS);
        }

        // GET: HORAS_TURNOS/Create
        public ActionResult Create()
        {
            ViewBag.RUT_EMPRESA_PROV = new SelectList(db.EMPRESA, "RUT_EMPRESA_PROV", "NOMBRE_EMPRESA");
            return View();
        }

        // POST: HORAS_TURNOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HRS_TRABAJO_SEM,ID_TURNO,RUT_EMPRESA_PROV,HORA_INICIO_LABORAL,HORA_TERMINO_LABORAL,HORAS_TRABAJADAS")] HORAS_TURNOS hORAS_TURNOS)
        {
            if (ModelState.IsValid)
            {
                db.HORAS_TURNOS.Add(hORAS_TURNOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RUT_EMPRESA_PROV = new SelectList(db.EMPRESA, "RUT_EMPRESA_PROV", "NOMBRE_EMPRESA", hORAS_TURNOS.RUT_EMPRESA_PROV);
            return View(hORAS_TURNOS);
        }

        // GET: HORAS_TURNOS/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HORAS_TURNOS hORAS_TURNOS = db.HORAS_TURNOS.Find(id);
            if (hORAS_TURNOS == null)
            {
                return HttpNotFound();
            }
            ViewBag.RUT_EMPRESA_PROV = new SelectList(db.EMPRESA, "RUT_EMPRESA_PROV", "NOMBRE_EMPRESA", hORAS_TURNOS.RUT_EMPRESA_PROV);
            return View(hORAS_TURNOS);
        }

        // POST: HORAS_TURNOS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HRS_TRABAJO_SEM,ID_TURNO,RUT_EMPRESA_PROV,HORA_INICIO_LABORAL,HORA_TERMINO_LABORAL,HORAS_TRABAJADAS")] HORAS_TURNOS hORAS_TURNOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hORAS_TURNOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RUT_EMPRESA_PROV = new SelectList(db.EMPRESA, "RUT_EMPRESA_PROV", "NOMBRE_EMPRESA", hORAS_TURNOS.RUT_EMPRESA_PROV);
            return View(hORAS_TURNOS);
        }

        // GET: HORAS_TURNOS/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HORAS_TURNOS hORAS_TURNOS = db.HORAS_TURNOS.Find(id);
            if (hORAS_TURNOS == null)
            {
                return HttpNotFound();
            }
            return View(hORAS_TURNOS);
        }

        // POST: HORAS_TURNOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            HORAS_TURNOS hORAS_TURNOS = db.HORAS_TURNOS.Find(id);
            db.HORAS_TURNOS.Remove(hORAS_TURNOS);
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
