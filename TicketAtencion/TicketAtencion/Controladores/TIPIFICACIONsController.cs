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
    public class TIPIFICACIONsController : Controller
    {
        private DBEntities2 db = new DBEntities2();

        // GET: TIPIFICACIONs
        public ActionResult Index()
        {
            var tIPIFICACION = db.TIPIFICACION.Include(t => t.TIPIFICACION2);
            return View(tIPIFICACION.ToList());
        }

        // GET: TIPIFICACIONs/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPIFICACION tIPIFICACION = db.TIPIFICACION.Find(id);
            if (tIPIFICACION == null)
            {
                return HttpNotFound();
            }
            return View(tIPIFICACION);
        }

        // GET: TIPIFICACIONs/Create
        public ActionResult Create()
        {
            ViewBag.ID_TIPO_PADRE = new SelectList(db.TIPIFICACION, "ID_TIPO", "NOMBRE_TIPO");
            return View();
        }

        // POST: TIPIFICACIONs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TIPO,ID_TIPO_PADRE,NOMBRE_TIPO,NIVEL_TIPO,RUT_EMPRESA_PROV")] TIPIFICACION tIPIFICACION)
        {
            if (ModelState.IsValid)
            {
                db.TIPIFICACION.Add(tIPIFICACION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_TIPO_PADRE = new SelectList(db.TIPIFICACION, "ID_TIPO", "NOMBRE_TIPO", tIPIFICACION.ID_TIPO_PADRE);
            return View(tIPIFICACION);
        }

        // GET: TIPIFICACIONs/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPIFICACION tIPIFICACION = db.TIPIFICACION.Find(id);
            if (tIPIFICACION == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_TIPO_PADRE = new SelectList(db.TIPIFICACION, "ID_TIPO", "NOMBRE_TIPO", tIPIFICACION.ID_TIPO_PADRE);
            return View(tIPIFICACION);
        }

        // POST: TIPIFICACIONs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TIPO,ID_TIPO_PADRE,NOMBRE_TIPO,NIVEL_TIPO,RUT_EMPRESA_PROV")] TIPIFICACION tIPIFICACION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIPIFICACION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_TIPO_PADRE = new SelectList(db.TIPIFICACION, "ID_TIPO", "NOMBRE_TIPO", tIPIFICACION.ID_TIPO_PADRE);
            return View(tIPIFICACION);
        }

        // GET: TIPIFICACIONs/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPIFICACION tIPIFICACION = db.TIPIFICACION.Find(id);
            if (tIPIFICACION == null)
            {
                return HttpNotFound();
            }
            return View(tIPIFICACION);
        }

        // POST: TIPIFICACIONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            TIPIFICACION tIPIFICACION = db.TIPIFICACION.Find(id);
            db.TIPIFICACION.Remove(tIPIFICACION);
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
