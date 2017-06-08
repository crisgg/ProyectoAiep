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
    public class URGENCIAsController : Controller
    {
        private DBEntities2 db = new DBEntities2();

        // GET: URGENCIAs
        public ActionResult Index()
        {
            return View(db.URGENCIA.ToList());
        }

        // GET: URGENCIAs/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            URGENCIA uRGENCIA = db.URGENCIA.Find(id);
            if (uRGENCIA == null)
            {
                return HttpNotFound();
            }
            return View(uRGENCIA);
        }

        // GET: URGENCIAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: URGENCIAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RUT_EMPRESA_PROV,ID_URGENCIA,NOMBRE_URGENCIA,DESCRIPCION_URGENCIA,VALOR_URGENCIA")] URGENCIA uRGENCIA)
        {
            if (ModelState.IsValid)
            {
                db.URGENCIA.Add(uRGENCIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uRGENCIA);
        }

        // GET: URGENCIAs/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            URGENCIA uRGENCIA = db.URGENCIA.Find(id);
            if (uRGENCIA == null)
            {
                return HttpNotFound();
            }
            return View(uRGENCIA);
        }

        // POST: URGENCIAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RUT_EMPRESA_PROV,ID_URGENCIA,NOMBRE_URGENCIA,DESCRIPCION_URGENCIA,VALOR_URGENCIA")] URGENCIA uRGENCIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uRGENCIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uRGENCIA);
        }

        // GET: URGENCIAs/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            URGENCIA uRGENCIA = db.URGENCIA.Find(id);
            if (uRGENCIA == null)
            {
                return HttpNotFound();
            }
            return View(uRGENCIA);
        }

        // POST: URGENCIAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            URGENCIA uRGENCIA = db.URGENCIA.Find(id);
            db.URGENCIA.Remove(uRGENCIA);
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
