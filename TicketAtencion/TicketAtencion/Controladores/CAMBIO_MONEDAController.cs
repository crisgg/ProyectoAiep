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
    public class CAMBIO_MONEDAController : Controller
    {
        private DBEntities2 db = new DBEntities2();

        // GET: CAMBIO_MONEDA
        public ActionResult Index()
        {
            var cAMBIO_MONEDA = db.CAMBIO_MONEDA.Include(c => c.MONEDA);
            return View(cAMBIO_MONEDA.ToList());
        }

        // GET: CAMBIO_MONEDA/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAMBIO_MONEDA cAMBIO_MONEDA = db.CAMBIO_MONEDA.Find(id);
            if (cAMBIO_MONEDA == null)
            {
                return HttpNotFound();
            }
            return View(cAMBIO_MONEDA);
        }

        // GET: CAMBIO_MONEDA/Create
        public ActionResult Create()
        {
            ViewBag.ID_MONEDA = new SelectList(db.MONEDA, "ID_MONEDA", "MONEDA1");
            return View();
        }

        // POST: CAMBIO_MONEDA/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_MONEDA,VALOR_CAMBIO,MONEDA_CAMBIO")] CAMBIO_MONEDA cAMBIO_MONEDA)
        {
            if (ModelState.IsValid)
            {
                db.CAMBIO_MONEDA.Add(cAMBIO_MONEDA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_MONEDA = new SelectList(db.MONEDA, "ID_MONEDA", "MONEDA1", cAMBIO_MONEDA.ID_MONEDA);
            return View(cAMBIO_MONEDA);
        }

        // GET: CAMBIO_MONEDA/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAMBIO_MONEDA cAMBIO_MONEDA = db.CAMBIO_MONEDA.Find(id);
            if (cAMBIO_MONEDA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_MONEDA = new SelectList(db.MONEDA, "ID_MONEDA", "MONEDA1", cAMBIO_MONEDA.ID_MONEDA);
            return View(cAMBIO_MONEDA);
        }

        // POST: CAMBIO_MONEDA/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_MONEDA,VALOR_CAMBIO,MONEDA_CAMBIO")] CAMBIO_MONEDA cAMBIO_MONEDA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cAMBIO_MONEDA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_MONEDA = new SelectList(db.MONEDA, "ID_MONEDA", "MONEDA1", cAMBIO_MONEDA.ID_MONEDA);
            return View(cAMBIO_MONEDA);
        }

        // GET: CAMBIO_MONEDA/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAMBIO_MONEDA cAMBIO_MONEDA = db.CAMBIO_MONEDA.Find(id);
            if (cAMBIO_MONEDA == null)
            {
                return HttpNotFound();
            }
            return View(cAMBIO_MONEDA);
        }

        // POST: CAMBIO_MONEDA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            CAMBIO_MONEDA cAMBIO_MONEDA = db.CAMBIO_MONEDA.Find(id);
            db.CAMBIO_MONEDA.Remove(cAMBIO_MONEDA);
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
