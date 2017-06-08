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
    public class HISTORIAsController : Controller
    {
        private DBEntities2 db = new DBEntities2();

        // GET: HISTORIAs
        public ActionResult Index()
        {
            var hISTORIA = db.HISTORIA.Include(h => h.RESOLUTORES_TERCEROS).Include(h => h.TKT);
            return View(hISTORIA.ToList());
        }

        // GET: HISTORIAs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HISTORIA hISTORIA = db.HISTORIA.Find(id);
            if (hISTORIA == null)
            {
                return HttpNotFound();
            }
            return View(hISTORIA);
        }

        // GET: HISTORIAs/Create
        public ActionResult Create()
        {
            ViewBag.ID_RESOL_TER = new SelectList(db.RESOLUTORES_TERCEROS, "ID_RESOL_TER", "NOM_RESOL_TER");
            ViewBag.ID_TKT = new SelectList(db.TKT, "ID_TKT", "AFECTADO_TKT");
            return View();
        }

        // POST: HISTORIAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RESOLUTOR,ID_TKT,ID_RESOL_TER,FECHA_HIST,TIEMPO_HIST,ESTADO_HIST,NOTAS_HIST,ATTACH_HIST")] HISTORIA hISTORIA)
        {
            if (ModelState.IsValid)
            {
                db.HISTORIA.Add(hISTORIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_RESOL_TER = new SelectList(db.RESOLUTORES_TERCEROS, "ID_RESOL_TER", "NOM_RESOL_TER", hISTORIA.ID_RESOL_TER);
            ViewBag.ID_TKT = new SelectList(db.TKT, "ID_TKT", "AFECTADO_TKT", hISTORIA.ID_TKT);
            return View(hISTORIA);
        }

        // GET: HISTORIAs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HISTORIA hISTORIA = db.HISTORIA.Find(id);
            if (hISTORIA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_RESOL_TER = new SelectList(db.RESOLUTORES_TERCEROS, "ID_RESOL_TER", "NOM_RESOL_TER", hISTORIA.ID_RESOL_TER);
            ViewBag.ID_TKT = new SelectList(db.TKT, "ID_TKT", "AFECTADO_TKT", hISTORIA.ID_TKT);
            return View(hISTORIA);
        }

        // POST: HISTORIAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RESOLUTOR,ID_TKT,ID_RESOL_TER,FECHA_HIST,TIEMPO_HIST,ESTADO_HIST,NOTAS_HIST,ATTACH_HIST")] HISTORIA hISTORIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hISTORIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_RESOL_TER = new SelectList(db.RESOLUTORES_TERCEROS, "ID_RESOL_TER", "NOM_RESOL_TER", hISTORIA.ID_RESOL_TER);
            ViewBag.ID_TKT = new SelectList(db.TKT, "ID_TKT", "AFECTADO_TKT", hISTORIA.ID_TKT);
            return View(hISTORIA);
        }

        // GET: HISTORIAs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HISTORIA hISTORIA = db.HISTORIA.Find(id);
            if (hISTORIA == null)
            {
                return HttpNotFound();
            }
            return View(hISTORIA);
        }

        // POST: HISTORIAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HISTORIA hISTORIA = db.HISTORIA.Find(id);
            db.HISTORIA.Remove(hISTORIA);
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
