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
    public class DATOS_EXTRASController : Controller
    {
        private DBEntities2 db = new DBEntities2();

        // GET: DATOS_EXTRAS
        public ActionResult Index()
        {
            var dATOS_EXTRAS = db.DATOS_EXTRAS.Include(d => d.AGENTES);
            return View(dATOS_EXTRAS.ToList());
        }

        // GET: DATOS_EXTRAS/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DATOS_EXTRAS dATOS_EXTRAS = db.DATOS_EXTRAS.Find(id);
            if (dATOS_EXTRAS == null)
            {
                return HttpNotFound();
            }
            return View(dATOS_EXTRAS);
        }

        // GET: DATOS_EXTRAS/Create
        public ActionResult Create()
        {
            ViewBag.ID_AGENTE = new SelectList(db.AGENTES, "ID_AGENTE", "RUT_EMPRESA_PROV");
            return View();
        }

        // POST: DATOS_EXTRAS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_DATOS_EXTRAS,ID_AGENTE")] DATOS_EXTRAS dATOS_EXTRAS)
        {
            if (ModelState.IsValid)
            {
                db.DATOS_EXTRAS.Add(dATOS_EXTRAS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_AGENTE = new SelectList(db.AGENTES, "ID_AGENTE", "RUT_EMPRESA_PROV", dATOS_EXTRAS.ID_AGENTE);
            return View(dATOS_EXTRAS);
        }

        // GET: DATOS_EXTRAS/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DATOS_EXTRAS dATOS_EXTRAS = db.DATOS_EXTRAS.Find(id);
            if (dATOS_EXTRAS == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_AGENTE = new SelectList(db.AGENTES, "ID_AGENTE", "RUT_EMPRESA_PROV", dATOS_EXTRAS.ID_AGENTE);
            return View(dATOS_EXTRAS);
        }

        // POST: DATOS_EXTRAS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_DATOS_EXTRAS,ID_AGENTE")] DATOS_EXTRAS dATOS_EXTRAS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dATOS_EXTRAS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_AGENTE = new SelectList(db.AGENTES, "ID_AGENTE", "RUT_EMPRESA_PROV", dATOS_EXTRAS.ID_AGENTE);
            return View(dATOS_EXTRAS);
        }

        // GET: DATOS_EXTRAS/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DATOS_EXTRAS dATOS_EXTRAS = db.DATOS_EXTRAS.Find(id);
            if (dATOS_EXTRAS == null)
            {
                return HttpNotFound();
            }
            return View(dATOS_EXTRAS);
        }

        // POST: DATOS_EXTRAS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            DATOS_EXTRAS dATOS_EXTRAS = db.DATOS_EXTRAS.Find(id);
            db.DATOS_EXTRAS.Remove(dATOS_EXTRAS);
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
