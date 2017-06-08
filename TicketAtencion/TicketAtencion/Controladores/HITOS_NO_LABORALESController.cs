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
    public class HITOS_NO_LABORALESController : Controller
    {
        private DBEntities2 db = new DBEntities2();

        // GET: HITOS_NO_LABORALES
        public ActionResult Index()
        {
            var hITOS_NO_LABORALES = db.HITOS_NO_LABORALES.Include(h => h.EMPRESA);
            return View(hITOS_NO_LABORALES.ToList());
        }

        // GET: HITOS_NO_LABORALES/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HITOS_NO_LABORALES hITOS_NO_LABORALES = db.HITOS_NO_LABORALES.Find(id);
            if (hITOS_NO_LABORALES == null)
            {
                return HttpNotFound();
            }
            return View(hITOS_NO_LABORALES);
        }

        // GET: HITOS_NO_LABORALES/Create
        public ActionResult Create()
        {
            ViewBag.RUT_EMPRESA_PROV = new SelectList(db.EMPRESA, "RUT_EMPRESA_PROV", "NOMBRE_EMPRESA");
            return View();
        }

        // POST: HITOS_NO_LABORALES/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_HITOS,RUT_EMPRESA_PROV,DESCRIPCION_HITONL,FECHA_INICO_HITONL,FECHA_TERMINO_HITONL,HORA_INICIO_HITONL,HORA_TERMNO_HITONL")] HITOS_NO_LABORALES hITOS_NO_LABORALES)
        {
            if (ModelState.IsValid)
            {
                db.HITOS_NO_LABORALES.Add(hITOS_NO_LABORALES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RUT_EMPRESA_PROV = new SelectList(db.EMPRESA, "RUT_EMPRESA_PROV", "NOMBRE_EMPRESA", hITOS_NO_LABORALES.RUT_EMPRESA_PROV);
            return View(hITOS_NO_LABORALES);
        }

        // GET: HITOS_NO_LABORALES/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HITOS_NO_LABORALES hITOS_NO_LABORALES = db.HITOS_NO_LABORALES.Find(id);
            if (hITOS_NO_LABORALES == null)
            {
                return HttpNotFound();
            }
            ViewBag.RUT_EMPRESA_PROV = new SelectList(db.EMPRESA, "RUT_EMPRESA_PROV", "NOMBRE_EMPRESA", hITOS_NO_LABORALES.RUT_EMPRESA_PROV);
            return View(hITOS_NO_LABORALES);
        }

        // POST: HITOS_NO_LABORALES/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_HITOS,RUT_EMPRESA_PROV,DESCRIPCION_HITONL,FECHA_INICO_HITONL,FECHA_TERMINO_HITONL,HORA_INICIO_HITONL,HORA_TERMNO_HITONL")] HITOS_NO_LABORALES hITOS_NO_LABORALES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hITOS_NO_LABORALES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RUT_EMPRESA_PROV = new SelectList(db.EMPRESA, "RUT_EMPRESA_PROV", "NOMBRE_EMPRESA", hITOS_NO_LABORALES.RUT_EMPRESA_PROV);
            return View(hITOS_NO_LABORALES);
        }

        // GET: HITOS_NO_LABORALES/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HITOS_NO_LABORALES hITOS_NO_LABORALES = db.HITOS_NO_LABORALES.Find(id);
            if (hITOS_NO_LABORALES == null)
            {
                return HttpNotFound();
            }
            return View(hITOS_NO_LABORALES);
        }

        // POST: HITOS_NO_LABORALES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            HITOS_NO_LABORALES hITOS_NO_LABORALES = db.HITOS_NO_LABORALES.Find(id);
            db.HITOS_NO_LABORALES.Remove(hITOS_NO_LABORALES);
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
