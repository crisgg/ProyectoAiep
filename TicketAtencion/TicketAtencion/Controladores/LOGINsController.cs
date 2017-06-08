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
    public class LOGINsController : Controller
    {
        private DBEntities2 db = new DBEntities2();

        // GET: LOGINs
        public ActionResult Index()
        {
            return View(db.LOGIN.ToList());
        }

        // GET: LOGINs/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOGIN lOGIN = db.LOGIN.Find(id);
            if (lOGIN == null)
            {
                return HttpNotFound();
            }
            return View(lOGIN);
        }

        // GET: LOGINs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LOGINs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_LOGIN,PASS_HASH,USER_NAME")] LOGIN lOGIN)
        {
            if (ModelState.IsValid)
            {
                db.LOGIN.Add(lOGIN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lOGIN);
        }

        // GET: LOGINs/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOGIN lOGIN = db.LOGIN.Find(id);
            if (lOGIN == null)
            {
                return HttpNotFound();
            }
            return View(lOGIN);
        }

        // POST: LOGINs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_LOGIN,PASS_HASH,USER_NAME")] LOGIN lOGIN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lOGIN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lOGIN);
        }

        // GET: LOGINs/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOGIN lOGIN = db.LOGIN.Find(id);
            if (lOGIN == null)
            {
                return HttpNotFound();
            }
            return View(lOGIN);
        }

        // POST: LOGINs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            LOGIN lOGIN = db.LOGIN.Find(id);
            db.LOGIN.Remove(lOGIN);
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
