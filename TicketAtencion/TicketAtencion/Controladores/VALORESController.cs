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
    public class VALORESController : Controller
    {
        private DBEntities2 db = new DBEntities2();

        // GET: VALORES
        public ActionResult Index()
        {
            var vALORES = db.VALORES.Include(v => v.MONEDA);
            return View(vALORES.ToList());
        }

        // GET: VALORES/Details/5
        public ActionResult Details(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VALORES vALORES = db.VALORES.Find(id);
            if (vALORES == null)
            {
                return HttpNotFound();
            }
            return View(vALORES);
        }

        // GET: VALORES/Create
        public ActionResult Create()
        {
            ViewBag.ID_MONEDA = new SelectList(db.MONEDA, "ID_MONEDA", "MONEDA1");
            return View();
        }

        // POST: VALORES/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FECHA_VALOR,VALOR,ID_MONEDA")] VALORES vALORES)
        {
            if (ModelState.IsValid)
            {
                db.VALORES.Add(vALORES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_MONEDA = new SelectList(db.MONEDA, "ID_MONEDA", "MONEDA1", vALORES.ID_MONEDA);
            return View(vALORES);
        }

        // GET: VALORES/Edit/5
        public ActionResult Edit(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VALORES vALORES = db.VALORES.Find(id);
            if (vALORES == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_MONEDA = new SelectList(db.MONEDA, "ID_MONEDA", "MONEDA1", vALORES.ID_MONEDA);
            return View(vALORES);
        }

        // POST: VALORES/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FECHA_VALOR,VALOR,ID_MONEDA")] VALORES vALORES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vALORES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_MONEDA = new SelectList(db.MONEDA, "ID_MONEDA", "MONEDA1", vALORES.ID_MONEDA);
            return View(vALORES);
        }

        // GET: VALORES/Delete/5
        public ActionResult Delete(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VALORES vALORES = db.VALORES.Find(id);
            if (vALORES == null)
            {
                return HttpNotFound();
            }
            return View(vALORES);
        }

        // POST: VALORES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(DateTime id)
        {
            VALORES vALORES = db.VALORES.Find(id);
            db.VALORES.Remove(vALORES);
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
