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
    public class METADATAsController : Controller
    {
        private DBEntities2 db = new DBEntities2();

        // GET: METADATAs
        public ActionResult Index()
        {
            var mETADATA = db.METADATA.Include(m => m.TIPOS_METADTA);
            return View(mETADATA.ToList());
        }

        // GET: METADATAs/Details/5
        public ActionResult Details(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            METADATA mETADATA = db.METADATA.Find(id);
            if (mETADATA == null)
            {
                return HttpNotFound();
            }
            return View(mETADATA);
        }

        // GET: METADATAs/Create
        public ActionResult Create()
        {
            ViewBag.ID_TIPO_META = new SelectList(db.TIPOS_METADTA, "ID_TIPO_META", "DESC_TIPO_META");
            return View();
        }

        // POST: METADATAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FECHA_META,VALOR_META,ID_TIPO_META")] METADATA mETADATA)
        {
            if (ModelState.IsValid)
            {
                db.METADATA.Add(mETADATA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_TIPO_META = new SelectList(db.TIPOS_METADTA, "ID_TIPO_META", "DESC_TIPO_META", mETADATA.ID_TIPO_META);
            return View(mETADATA);
        }

        // GET: METADATAs/Edit/5
        public ActionResult Edit(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            METADATA mETADATA = db.METADATA.Find(id);
            if (mETADATA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_TIPO_META = new SelectList(db.TIPOS_METADTA, "ID_TIPO_META", "DESC_TIPO_META", mETADATA.ID_TIPO_META);
            return View(mETADATA);
        }

        // POST: METADATAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FECHA_META,VALOR_META,ID_TIPO_META")] METADATA mETADATA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mETADATA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_TIPO_META = new SelectList(db.TIPOS_METADTA, "ID_TIPO_META", "DESC_TIPO_META", mETADATA.ID_TIPO_META);
            return View(mETADATA);
        }

        // GET: METADATAs/Delete/5
        public ActionResult Delete(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            METADATA mETADATA = db.METADATA.Find(id);
            if (mETADATA == null)
            {
                return HttpNotFound();
            }
            return View(mETADATA);
        }

        // POST: METADATAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(DateTime id)
        {
            METADATA mETADATA = db.METADATA.Find(id);
            db.METADATA.Remove(mETADATA);
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
