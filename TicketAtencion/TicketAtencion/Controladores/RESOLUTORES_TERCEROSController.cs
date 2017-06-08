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
    public class RESOLUTORES_TERCEROSController : Controller
    {
        private DBEntities2 db = new DBEntities2();

        // GET: RESOLUTORES_TERCEROS
        public ActionResult Index()
        {
            var rESOLUTORES_TERCEROS = db.RESOLUTORES_TERCEROS.Include(r => r.COMUNAS);
            return View(rESOLUTORES_TERCEROS.ToList());
        }

        // GET: RESOLUTORES_TERCEROS/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESOLUTORES_TERCEROS rESOLUTORES_TERCEROS = db.RESOLUTORES_TERCEROS.Find(id);
            if (rESOLUTORES_TERCEROS == null)
            {
                return HttpNotFound();
            }
            return View(rESOLUTORES_TERCEROS);
        }

        // GET: RESOLUTORES_TERCEROS/Create
        public ActionResult Create()
        {
            ViewBag.ID_COMUNA = new SelectList(db.COMUNAS, "ID_COMUNA", "NOM_COMUNA");
            return View();
        }

        // POST: RESOLUTORES_TERCEROS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_RESOL_TER,ID_COMUNA,NOM_RESOL_TER,RSOCIAL_RESOL_TER,RUT_RESOL_TER,DIRECCION_RESOL_TER")] RESOLUTORES_TERCEROS rESOLUTORES_TERCEROS)
        {
            if (ModelState.IsValid)
            {
                db.RESOLUTORES_TERCEROS.Add(rESOLUTORES_TERCEROS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_COMUNA = new SelectList(db.COMUNAS, "ID_COMUNA", "NOM_COMUNA", rESOLUTORES_TERCEROS.ID_COMUNA);
            return View(rESOLUTORES_TERCEROS);
        }

        // GET: RESOLUTORES_TERCEROS/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESOLUTORES_TERCEROS rESOLUTORES_TERCEROS = db.RESOLUTORES_TERCEROS.Find(id);
            if (rESOLUTORES_TERCEROS == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_COMUNA = new SelectList(db.COMUNAS, "ID_COMUNA", "NOM_COMUNA", rESOLUTORES_TERCEROS.ID_COMUNA);
            return View(rESOLUTORES_TERCEROS);
        }

        // POST: RESOLUTORES_TERCEROS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_RESOL_TER,ID_COMUNA,NOM_RESOL_TER,RSOCIAL_RESOL_TER,RUT_RESOL_TER,DIRECCION_RESOL_TER")] RESOLUTORES_TERCEROS rESOLUTORES_TERCEROS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rESOLUTORES_TERCEROS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_COMUNA = new SelectList(db.COMUNAS, "ID_COMUNA", "NOM_COMUNA", rESOLUTORES_TERCEROS.ID_COMUNA);
            return View(rESOLUTORES_TERCEROS);
        }

        // GET: RESOLUTORES_TERCEROS/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESOLUTORES_TERCEROS rESOLUTORES_TERCEROS = db.RESOLUTORES_TERCEROS.Find(id);
            if (rESOLUTORES_TERCEROS == null)
            {
                return HttpNotFound();
            }
            return View(rESOLUTORES_TERCEROS);
        }

        // POST: RESOLUTORES_TERCEROS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            RESOLUTORES_TERCEROS rESOLUTORES_TERCEROS = db.RESOLUTORES_TERCEROS.Find(id);
            db.RESOLUTORES_TERCEROS.Remove(rESOLUTORES_TERCEROS);
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
