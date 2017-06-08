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
    public class CALENDARIOsController : Controller
    {
        private DBEntities2 db = new DBEntities2();

        // GET: CALENDARIOs
        public ActionResult Index()
        {
            var cALENDARIO = db.CALENDARIO.Include(c => c.PAISES);
            return View(cALENDARIO.ToList());
        }

        // GET: CALENDARIOs/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CALENDARIO cALENDARIO = db.CALENDARIO.Find(id);
            if (cALENDARIO == null)
            {
                return HttpNotFound();
            }
            return View(cALENDARIO);
        }

        // GET: CALENDARIOs/Create
        public ActionResult Create()
        {
            ViewBag.ID_PAIS = new SelectList(db.PAISES, "ID_PAIS", "NOM_PAIS");
            return View();
        }

        // POST: CALENDARIOs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_FERIADO,ID_PAIS,FECHA_NO_LABORAL,DESCRIPCION_NO_LABORAL")] CALENDARIO cALENDARIO)
        {
            if (ModelState.IsValid)
            {
                db.CALENDARIO.Add(cALENDARIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PAIS = new SelectList(db.PAISES, "ID_PAIS", "NOM_PAIS", cALENDARIO.ID_PAIS);
            return View(cALENDARIO);
        }

        // GET: CALENDARIOs/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CALENDARIO cALENDARIO = db.CALENDARIO.Find(id);
            if (cALENDARIO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PAIS = new SelectList(db.PAISES, "ID_PAIS", "NOM_PAIS", cALENDARIO.ID_PAIS);
            return View(cALENDARIO);
        }

        // POST: CALENDARIOs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_FERIADO,ID_PAIS,FECHA_NO_LABORAL,DESCRIPCION_NO_LABORAL")] CALENDARIO cALENDARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cALENDARIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PAIS = new SelectList(db.PAISES, "ID_PAIS", "NOM_PAIS", cALENDARIO.ID_PAIS);
            return View(cALENDARIO);
        }

        // GET: CALENDARIOs/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CALENDARIO cALENDARIO = db.CALENDARIO.Find(id);
            if (cALENDARIO == null)
            {
                return HttpNotFound();
            }
            return View(cALENDARIO);
        }

        // POST: CALENDARIOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            CALENDARIO cALENDARIO = db.CALENDARIO.Find(id);
            db.CALENDARIO.Remove(cALENDARIO);
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
