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
    public class IMPACTOesController : Controller
    {
        private DBEntities2 db = new DBEntities2();

        // GET: IMPACTOes
        public ActionResult Index()
        {
            return View(db.IMPACTO.ToList());
        }

        // GET: IMPACTOes/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IMPACTO iMPACTO = db.IMPACTO.Find(id);
            if (iMPACTO == null)
            {
                return HttpNotFound();
            }
            return View(iMPACTO);
        }

        // GET: IMPACTOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IMPACTOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_IMPACTO,NOMBRE_IMPACTO,DESCRIPCION_IMPACTO,VALOR_IMPACTO,RUT_EMPRESA_PROV")] IMPACTO iMPACTO)
        {
            if (ModelState.IsValid)
            {
                db.IMPACTO.Add(iMPACTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(iMPACTO);
        }

        // GET: IMPACTOes/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IMPACTO iMPACTO = db.IMPACTO.Find(id);
            if (iMPACTO == null)
            {
                return HttpNotFound();
            }
            return View(iMPACTO);
        }

        // POST: IMPACTOes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_IMPACTO,NOMBRE_IMPACTO,DESCRIPCION_IMPACTO,VALOR_IMPACTO,RUT_EMPRESA_PROV")] IMPACTO iMPACTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iMPACTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(iMPACTO);
        }

        // GET: IMPACTOes/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IMPACTO iMPACTO = db.IMPACTO.Find(id);
            if (iMPACTO == null)
            {
                return HttpNotFound();
            }
            return View(iMPACTO);
        }

        // POST: IMPACTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            IMPACTO iMPACTO = db.IMPACTO.Find(id);
            db.IMPACTO.Remove(iMPACTO);
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
