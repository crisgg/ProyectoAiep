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
    public class TELS_RESOL_TERController : Controller
    {
        private DBEntities2 db = new DBEntities2();

        // GET: TELS_RESOL_TER
        public ActionResult Index()
        {
            var tELS_RESOL_TER = db.TELS_RESOL_TER.Include(t => t.RESOLUTORES_TERCEROS);
            return View(tELS_RESOL_TER.ToList());
        }

        // GET: TELS_RESOL_TER/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TELS_RESOL_TER tELS_RESOL_TER = db.TELS_RESOL_TER.Find(id);
            if (tELS_RESOL_TER == null)
            {
                return HttpNotFound();
            }
            return View(tELS_RESOL_TER);
        }

        // GET: TELS_RESOL_TER/Create
        public ActionResult Create()
        {
            ViewBag.ID_RESOL_TER = new SelectList(db.RESOLUTORES_TERCEROS, "ID_RESOL_TER", "NOM_RESOL_TER");
            return View();
        }

        // POST: TELS_RESOL_TER/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TEL_RESOL_TER,ID_TEL_RESTER,ID_RESOL_TER")] TELS_RESOL_TER tELS_RESOL_TER)
        {
            if (ModelState.IsValid)
            {
                db.TELS_RESOL_TER.Add(tELS_RESOL_TER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_RESOL_TER = new SelectList(db.RESOLUTORES_TERCEROS, "ID_RESOL_TER", "NOM_RESOL_TER", tELS_RESOL_TER.ID_RESOL_TER);
            return View(tELS_RESOL_TER);
        }

        // GET: TELS_RESOL_TER/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TELS_RESOL_TER tELS_RESOL_TER = db.TELS_RESOL_TER.Find(id);
            if (tELS_RESOL_TER == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_RESOL_TER = new SelectList(db.RESOLUTORES_TERCEROS, "ID_RESOL_TER", "NOM_RESOL_TER", tELS_RESOL_TER.ID_RESOL_TER);
            return View(tELS_RESOL_TER);
        }

        // POST: TELS_RESOL_TER/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TEL_RESOL_TER,ID_TEL_RESTER,ID_RESOL_TER")] TELS_RESOL_TER tELS_RESOL_TER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tELS_RESOL_TER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_RESOL_TER = new SelectList(db.RESOLUTORES_TERCEROS, "ID_RESOL_TER", "NOM_RESOL_TER", tELS_RESOL_TER.ID_RESOL_TER);
            return View(tELS_RESOL_TER);
        }

        // GET: TELS_RESOL_TER/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TELS_RESOL_TER tELS_RESOL_TER = db.TELS_RESOL_TER.Find(id);
            if (tELS_RESOL_TER == null)
            {
                return HttpNotFound();
            }
            return View(tELS_RESOL_TER);
        }

        // POST: TELS_RESOL_TER/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            TELS_RESOL_TER tELS_RESOL_TER = db.TELS_RESOL_TER.Find(id);
            db.TELS_RESOL_TER.Remove(tELS_RESOL_TER);
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
