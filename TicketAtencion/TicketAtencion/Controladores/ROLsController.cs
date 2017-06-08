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
    public class ROLsController : Controller
    {
        private DBEntities2 db = new DBEntities2();

        // GET: ROLs
        public ActionResult Index()
        {
            var rOL = db.ROL.Include(r => r.LOGIN);
            return View(rOL.ToList());
        }

        // GET: ROLs/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROL rOL = db.ROL.Find(id);
            if (rOL == null)
            {
                return HttpNotFound();
            }
            return View(rOL);
        }

        // GET: ROLs/Create
        public ActionResult Create()
        {
            ViewBag.ID_LOGIN = new SelectList(db.LOGIN, "ID_LOGIN", "PASS_HASH");
            return View();
        }

        // POST: ROLs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RUT_EMPRESA_PROV,ID_ROL,ID_LOGIN,DESCRIPCION_ROL")] ROL rOL)
        {
            if (ModelState.IsValid)
            {
                db.ROL.Add(rOL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_LOGIN = new SelectList(db.LOGIN, "ID_LOGIN", "PASS_HASH", rOL.ID_LOGIN);
            return View(rOL);
        }

        // GET: ROLs/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROL rOL = db.ROL.Find(id);
            if (rOL == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_LOGIN = new SelectList(db.LOGIN, "ID_LOGIN", "PASS_HASH", rOL.ID_LOGIN);
            return View(rOL);
        }

        // POST: ROLs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RUT_EMPRESA_PROV,ID_ROL,ID_LOGIN,DESCRIPCION_ROL")] ROL rOL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rOL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_LOGIN = new SelectList(db.LOGIN, "ID_LOGIN", "PASS_HASH", rOL.ID_LOGIN);
            return View(rOL);
        }

        // GET: ROLs/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROL rOL = db.ROL.Find(id);
            if (rOL == null)
            {
                return HttpNotFound();
            }
            return View(rOL);
        }

        // POST: ROLs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            ROL rOL = db.ROL.Find(id);
            db.ROL.Remove(rOL);
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
