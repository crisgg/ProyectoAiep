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
    public class REGIONESController : Controller
    {
        private DBEntities2 db = new DBEntities2();

        // GET: REGIONES
        public ActionResult Index()
        {
            var rEGIONES = db.REGIONES.Include(r => r.PAISES);
            return View(rEGIONES.ToList());
        }

        // GET: REGIONES/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REGIONES rEGIONES = db.REGIONES.Find(id);
            if (rEGIONES == null)
            {
                return HttpNotFound();
            }
            return View(rEGIONES);
        }

        // GET: REGIONES/Create
        public ActionResult Create()
        {
            ViewBag.ID_PAIS = new SelectList(db.PAISES, "ID_PAIS", "NOM_PAIS");
            return View();
        }

        // POST: REGIONES/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_REGION,ID_PAIS,NOMBRE_REGION")] REGIONES rEGIONES)
        {
            if (ModelState.IsValid)
            {
                db.REGIONES.Add(rEGIONES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PAIS = new SelectList(db.PAISES, "ID_PAIS", "NOM_PAIS", rEGIONES.ID_PAIS);
            return View(rEGIONES);
        }

        // GET: REGIONES/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REGIONES rEGIONES = db.REGIONES.Find(id);
            if (rEGIONES == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PAIS = new SelectList(db.PAISES, "ID_PAIS", "NOM_PAIS", rEGIONES.ID_PAIS);
            return View(rEGIONES);
        }

        // POST: REGIONES/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_REGION,ID_PAIS,NOMBRE_REGION")] REGIONES rEGIONES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rEGIONES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PAIS = new SelectList(db.PAISES, "ID_PAIS", "NOM_PAIS", rEGIONES.ID_PAIS);
            return View(rEGIONES);
        }

        // GET: REGIONES/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REGIONES rEGIONES = db.REGIONES.Find(id);
            if (rEGIONES == null)
            {
                return HttpNotFound();
            }
            return View(rEGIONES);
        }

        // POST: REGIONES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            REGIONES rEGIONES = db.REGIONES.Find(id);
            db.REGIONES.Remove(rEGIONES);
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
