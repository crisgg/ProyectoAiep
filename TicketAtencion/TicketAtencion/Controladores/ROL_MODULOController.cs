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
    public class ROL_MODULOController : Controller
    {
        private DBEntities2 db = new DBEntities2();

        // GET: ROL_MODULO
        public ActionResult Index()
        {
            var rOL_MODULO = db.ROL_MODULO.Include(r => r.MODULO).Include(r => r.ROL);
            return View(rOL_MODULO.ToList());
        }

        // GET: ROL_MODULO/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROL_MODULO rOL_MODULO = db.ROL_MODULO.Find(id);
            if (rOL_MODULO == null)
            {
                return HttpNotFound();
            }
            return View(rOL_MODULO);
        }

        // GET: ROL_MODULO/Create
        public ActionResult Create()
        {
            ViewBag.ID_MODULO = new SelectList(db.MODULO, "ID_MODULO", "DESCRIPCION_MODULO");
            ViewBag.ID_ROL = new SelectList(db.ROL, "ID_ROL", "RUT_EMPRESA_PROV");
            return View();
        }

        // POST: ROL_MODULO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_ROL,ID_MODULO,FECHA_ROLMODULO,ESTADO,PERMISO")] ROL_MODULO rOL_MODULO)
        {
            if (ModelState.IsValid)
            {
                db.ROL_MODULO.Add(rOL_MODULO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_MODULO = new SelectList(db.MODULO, "ID_MODULO", "DESCRIPCION_MODULO", rOL_MODULO.ID_MODULO);
            ViewBag.ID_ROL = new SelectList(db.ROL, "ID_ROL", "RUT_EMPRESA_PROV", rOL_MODULO.ID_ROL);
            return View(rOL_MODULO);
        }

        // GET: ROL_MODULO/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROL_MODULO rOL_MODULO = db.ROL_MODULO.Find(id);
            if (rOL_MODULO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_MODULO = new SelectList(db.MODULO, "ID_MODULO", "DESCRIPCION_MODULO", rOL_MODULO.ID_MODULO);
            ViewBag.ID_ROL = new SelectList(db.ROL, "ID_ROL", "RUT_EMPRESA_PROV", rOL_MODULO.ID_ROL);
            return View(rOL_MODULO);
        }

        // POST: ROL_MODULO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_ROL,ID_MODULO,FECHA_ROLMODULO,ESTADO,PERMISO")] ROL_MODULO rOL_MODULO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rOL_MODULO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_MODULO = new SelectList(db.MODULO, "ID_MODULO", "DESCRIPCION_MODULO", rOL_MODULO.ID_MODULO);
            ViewBag.ID_ROL = new SelectList(db.ROL, "ID_ROL", "RUT_EMPRESA_PROV", rOL_MODULO.ID_ROL);
            return View(rOL_MODULO);
        }

        // GET: ROL_MODULO/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROL_MODULO rOL_MODULO = db.ROL_MODULO.Find(id);
            if (rOL_MODULO == null)
            {
                return HttpNotFound();
            }
            return View(rOL_MODULO);
        }

        // POST: ROL_MODULO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            ROL_MODULO rOL_MODULO = db.ROL_MODULO.Find(id);
            db.ROL_MODULO.Remove(rOL_MODULO);
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
