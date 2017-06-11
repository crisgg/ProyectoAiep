using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAiep.Models;

namespace WebAiep.Controllers
{
    public class AGENTESController : Controller
    {
        private DB_A255CD_MoDeskBDDEntities db = new DB_A255CD_MoDeskBDDEntities();

        // GET: AGENTES
        public ActionResult Index()
        {
            var aGENTES = db.AGENTES.Include(a => a.AREA).Include(a => a.COMUNAS).Include(a => a.LOGIN);
            return View(aGENTES.ToList());
        }

        // GET: AGENTES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AGENTES aGENTES = db.AGENTES.Find(id);
            if (aGENTES == null)
            {
                return HttpNotFound();
            }
            return View(aGENTES);
        }

        // GET: AGENTES/Create
        public ActionResult Create()
        {
            ViewBag.ID_AREA = new SelectList(db.AREA, "ID_AREA", "RUT_EMPRESA_PROV");
            ViewBag.ID_COMUNA = new SelectList(db.COMUNAS, "ID_COMUNA", "NOM_COMUNA");
            ViewBag.ID_LOGIN = new SelectList(db.LOGIN, "ID_LOGIN", "PASS_HASH");
            return View();
        }

        // POST: AGENTES/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RUT_EMPRESA_PROV,ID_AGENTE,ID_LOGIN,ID_COMUNA,ID_AREA,NOMBRE_AGENTE,APELLIDOP_AGENTE,APELLIDOM_AGENTE,EMAIL_AGENTE")] AGENTES aGENTES)
        {
            if (ModelState.IsValid)
            {
                db.AGENTES.Add(aGENTES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_AREA = new SelectList(db.AREA, "ID_AREA", "RUT_EMPRESA_PROV", aGENTES.ID_AREA);
            ViewBag.ID_COMUNA = new SelectList(db.COMUNAS, "ID_COMUNA", "NOM_COMUNA", aGENTES.ID_COMUNA);
            ViewBag.ID_LOGIN = new SelectList(db.LOGIN, "ID_LOGIN", "PASS_HASH", aGENTES.ID_LOGIN);
            return View(aGENTES);
        }

        // GET: AGENTES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AGENTES aGENTES = db.AGENTES.Find(id);
            if (aGENTES == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_AREA = new SelectList(db.AREA, "ID_AREA", "RUT_EMPRESA_PROV", aGENTES.ID_AREA);
            ViewBag.ID_COMUNA = new SelectList(db.COMUNAS, "ID_COMUNA", "NOM_COMUNA", aGENTES.ID_COMUNA);
            ViewBag.ID_LOGIN = new SelectList(db.LOGIN, "ID_LOGIN", "PASS_HASH", aGENTES.ID_LOGIN);
            return View(aGENTES);
        }

        // POST: AGENTES/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RUT_EMPRESA_PROV,ID_AGENTE,ID_LOGIN,ID_COMUNA,ID_AREA,NOMBRE_AGENTE,APELLIDOP_AGENTE,APELLIDOM_AGENTE,EMAIL_AGENTE")] AGENTES aGENTES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aGENTES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_AREA = new SelectList(db.AREA, "ID_AREA", "RUT_EMPRESA_PROV", aGENTES.ID_AREA);
            ViewBag.ID_COMUNA = new SelectList(db.COMUNAS, "ID_COMUNA", "NOM_COMUNA", aGENTES.ID_COMUNA);
            ViewBag.ID_LOGIN = new SelectList(db.LOGIN, "ID_LOGIN", "PASS_HASH", aGENTES.ID_LOGIN);
            return View(aGENTES);
        }

        // GET: AGENTES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AGENTES aGENTES = db.AGENTES.Find(id);
            if (aGENTES == null)
            {
                return HttpNotFound();
            }
            return View(aGENTES);
        }

        // POST: AGENTES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AGENTES aGENTES = db.AGENTES.Find(id);
            db.AGENTES.Remove(aGENTES);
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
