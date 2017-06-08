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
    public class USUARIO_FINALController : Controller
    {
        private DBEntities2 db = new DBEntities2();

        // GET: USUARIO_FINAL
        public ActionResult Index()
        {
            var uSUARIO_FINAL = db.USUARIO_FINAL.Include(u => u.EMPRESA_CLI).Include(u => u.LOGIN);
            return View(uSUARIO_FINAL.ToList());
        }

        // GET: USUARIO_FINAL/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO_FINAL uSUARIO_FINAL = db.USUARIO_FINAL.Find(id);
            if (uSUARIO_FINAL == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO_FINAL);
        }

        // GET: USUARIO_FINAL/Create
        public ActionResult Create()
        {
            ViewBag.ID_EMPRESA = new SelectList(db.EMPRESA_CLI, "ID_EMPRESA", "RUT_EMPRESA_PROV");
            ViewBag.ID_LOGIN = new SelectList(db.LOGIN, "ID_LOGIN", "PASS_HASH");
            return View();
        }

        // POST: USUARIO_FINAL/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_USUFINAL,ID_EMPRESA,ID_LOGIN,VIP")] USUARIO_FINAL uSUARIO_FINAL)
        {
            if (ModelState.IsValid)
            {
                db.USUARIO_FINAL.Add(uSUARIO_FINAL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_EMPRESA = new SelectList(db.EMPRESA_CLI, "ID_EMPRESA", "RUT_EMPRESA_PROV", uSUARIO_FINAL.ID_EMPRESA);
            ViewBag.ID_LOGIN = new SelectList(db.LOGIN, "ID_LOGIN", "PASS_HASH", uSUARIO_FINAL.ID_LOGIN);
            return View(uSUARIO_FINAL);
        }

        // GET: USUARIO_FINAL/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO_FINAL uSUARIO_FINAL = db.USUARIO_FINAL.Find(id);
            if (uSUARIO_FINAL == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_EMPRESA = new SelectList(db.EMPRESA_CLI, "ID_EMPRESA", "RUT_EMPRESA_PROV", uSUARIO_FINAL.ID_EMPRESA);
            ViewBag.ID_LOGIN = new SelectList(db.LOGIN, "ID_LOGIN", "PASS_HASH", uSUARIO_FINAL.ID_LOGIN);
            return View(uSUARIO_FINAL);
        }

        // POST: USUARIO_FINAL/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_USUFINAL,ID_EMPRESA,ID_LOGIN,VIP")] USUARIO_FINAL uSUARIO_FINAL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSUARIO_FINAL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_EMPRESA = new SelectList(db.EMPRESA_CLI, "ID_EMPRESA", "RUT_EMPRESA_PROV", uSUARIO_FINAL.ID_EMPRESA);
            ViewBag.ID_LOGIN = new SelectList(db.LOGIN, "ID_LOGIN", "PASS_HASH", uSUARIO_FINAL.ID_LOGIN);
            return View(uSUARIO_FINAL);
        }

        // GET: USUARIO_FINAL/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO_FINAL uSUARIO_FINAL = db.USUARIO_FINAL.Find(id);
            if (uSUARIO_FINAL == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO_FINAL);
        }

        // POST: USUARIO_FINAL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            USUARIO_FINAL uSUARIO_FINAL = db.USUARIO_FINAL.Find(id);
            db.USUARIO_FINAL.Remove(uSUARIO_FINAL);
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
