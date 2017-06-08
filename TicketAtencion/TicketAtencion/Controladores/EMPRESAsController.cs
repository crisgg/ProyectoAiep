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
    public class EMPRESAsController : Controller
    {
        private DBEntities2 db = new DBEntities2();

        // GET: EMPRESAs
        public ActionResult Index()
        {
            var eMPRESA = db.EMPRESA.Include(e => e.PAISES);
            return View(eMPRESA.ToList());
        }

        // GET: EMPRESAs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPRESA eMPRESA = db.EMPRESA.Find(id);
            if (eMPRESA == null)
            {
                return HttpNotFound();
            }
            return View(eMPRESA);
        }

        // GET: EMPRESAs/Create
        public ActionResult Create()
        {
            ViewBag.ID_PAIS = new SelectList(db.PAISES, "ID_PAIS", "NOM_PAIS");
            return View();
        }

        // POST: EMPRESAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RUT_EMPRESA_PROV,ID_PAIS,NOMBRE_EMPRESA,RAZON_SOCIAL_EMPRESA,DIRECCION_EMPRSA")] EMPRESA eMPRESA)
        {
            if (ModelState.IsValid)
            {
                db.EMPRESA.Add(eMPRESA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PAIS = new SelectList(db.PAISES, "ID_PAIS", "NOM_PAIS", eMPRESA.ID_PAIS);
            return View(eMPRESA);
        }

        // GET: EMPRESAs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPRESA eMPRESA = db.EMPRESA.Find(id);
            if (eMPRESA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PAIS = new SelectList(db.PAISES, "ID_PAIS", "NOM_PAIS", eMPRESA.ID_PAIS);
            return View(eMPRESA);
        }

        // POST: EMPRESAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RUT_EMPRESA_PROV,ID_PAIS,NOMBRE_EMPRESA,RAZON_SOCIAL_EMPRESA,DIRECCION_EMPRSA")] EMPRESA eMPRESA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eMPRESA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PAIS = new SelectList(db.PAISES, "ID_PAIS", "NOM_PAIS", eMPRESA.ID_PAIS);
            return View(eMPRESA);
        }

        // GET: EMPRESAs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPRESA eMPRESA = db.EMPRESA.Find(id);
            if (eMPRESA == null)
            {
                return HttpNotFound();
            }
            return View(eMPRESA);
        }

        // POST: EMPRESAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            EMPRESA eMPRESA = db.EMPRESA.Find(id);
            db.EMPRESA.Remove(eMPRESA);
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
