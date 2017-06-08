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
    public class COMUNASController : Controller
    {
        private DBEntities2 db = new DBEntities2();

        // GET: COMUNAS
        public ActionResult Index()
        {
            var cOMUNAS = db.COMUNAS.Include(c => c.DISTRITOS);
            return View(cOMUNAS.ToList());
        }

        // GET: COMUNAS/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMUNAS cOMUNAS = db.COMUNAS.Find(id);
            if (cOMUNAS == null)
            {
                return HttpNotFound();
            }
            return View(cOMUNAS);
        }

        // GET: COMUNAS/Create
        public ActionResult Create()
        {
            ViewBag.ID_DISTRIRO = new SelectList(db.DISTRITOS, "ID_DISTRIRO", "NOM_DISTRITO");
            return View();
        }

        // POST: COMUNAS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_COMUNA,ID_DISTRIRO,NOM_COMUNA")] COMUNAS cOMUNAS)
        {
            if (ModelState.IsValid)
            {
                db.COMUNAS.Add(cOMUNAS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_DISTRIRO = new SelectList(db.DISTRITOS, "ID_DISTRIRO", "NOM_DISTRITO", cOMUNAS.ID_DISTRIRO);
            return View(cOMUNAS);
        }

        // GET: COMUNAS/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMUNAS cOMUNAS = db.COMUNAS.Find(id);
            if (cOMUNAS == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_DISTRIRO = new SelectList(db.DISTRITOS, "ID_DISTRIRO", "NOM_DISTRITO", cOMUNAS.ID_DISTRIRO);
            return View(cOMUNAS);
        }

        // POST: COMUNAS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_COMUNA,ID_DISTRIRO,NOM_COMUNA")] COMUNAS cOMUNAS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOMUNAS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_DISTRIRO = new SelectList(db.DISTRITOS, "ID_DISTRIRO", "NOM_DISTRITO", cOMUNAS.ID_DISTRIRO);
            return View(cOMUNAS);
        }

        // GET: COMUNAS/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMUNAS cOMUNAS = db.COMUNAS.Find(id);
            if (cOMUNAS == null)
            {
                return HttpNotFound();
            }
            return View(cOMUNAS);
        }

        // POST: COMUNAS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            COMUNAS cOMUNAS = db.COMUNAS.Find(id);
            db.COMUNAS.Remove(cOMUNAS);
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
