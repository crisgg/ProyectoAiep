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
    public class TKTsController : Controller
    {
        private DBEntities2 db = new DBEntities2();

        // GET: TKTs
        public ActionResult Index()
        {
            var tKT = db.TKT.Include(t => t.ESTADOS).Include(t => t.IMPACTO).Include(t => t.LOGIN).Include(t => t.SERVICIO_EMPRESA).Include(t => t.TIPIFICACION).Include(t => t.URGENCIA);
            return View(tKT.ToList());
        }

        // GET: TKTs/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TKT tKT = db.TKT.Find(id);
            if (tKT == null)
            {
                return HttpNotFound();
            }
            return View(tKT);
        }

        // GET: TKTs/Create
        public ActionResult Create()
        {
            ViewBag.ID_ESTADO = new SelectList(db.ESTADOS, "ID_ESTADO", "RUT_EMPRESA_PROV");
            ViewBag.ID_IMPACTO = new SelectList(db.IMPACTO, "ID_IMPACTO", "NOMBRE_IMPACTO");
            ViewBag.ID_LOGIN = new SelectList(db.LOGIN, "ID_LOGIN", "PASS_HASH");
            ViewBag.ID_SERVI_EMP = new SelectList(db.SERVICIO_EMPRESA, "ID_SERVI_EMP", "ID_SERVI_EMP");
            ViewBag.ID_TIPO = new SelectList(db.TIPIFICACION, "ID_TIPO", "NOMBRE_TIPO");
            ViewBag.ID_URGENCIA = new SelectList(db.URGENCIA, "ID_URGENCIA", "RUT_EMPRESA_PROV");
            return View();
        }

        // POST: TKTs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TKT,ID_URGENCIA,ID_ESTADO,ID_IMPACTO,ID_TIPO,ID_LOGIN,ID_SERVI_EMP,CREADOR_TKT,REPORTADOR_TKT,AFECTADO_TKT,PRIORIDAD_TKT,VALOR_IMPACTO_TKT,VALOR_URGENCIA_TKT,RUT_EMPRESA_PROV")] TKT tKT)
        {
            if (ModelState.IsValid)
            {
                db.TKT.Add(tKT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ESTADO = new SelectList(db.ESTADOS, "ID_ESTADO", "RUT_EMPRESA_PROV", tKT.ID_ESTADO);
            ViewBag.ID_IMPACTO = new SelectList(db.IMPACTO, "ID_IMPACTO", "NOMBRE_IMPACTO", tKT.ID_IMPACTO);
            ViewBag.ID_LOGIN = new SelectList(db.LOGIN, "ID_LOGIN", "PASS_HASH", tKT.ID_LOGIN);
            ViewBag.ID_SERVI_EMP = new SelectList(db.SERVICIO_EMPRESA, "ID_SERVI_EMP", "ID_SERVI_EMP", tKT.ID_SERVI_EMP);
            ViewBag.ID_TIPO = new SelectList(db.TIPIFICACION, "ID_TIPO", "NOMBRE_TIPO", tKT.ID_TIPO);
            ViewBag.ID_URGENCIA = new SelectList(db.URGENCIA, "ID_URGENCIA", "RUT_EMPRESA_PROV", tKT.ID_URGENCIA);
            return View(tKT);
        }

        // GET: TKTs/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TKT tKT = db.TKT.Find(id);
            if (tKT == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ESTADO = new SelectList(db.ESTADOS, "ID_ESTADO", "RUT_EMPRESA_PROV", tKT.ID_ESTADO);
            ViewBag.ID_IMPACTO = new SelectList(db.IMPACTO, "ID_IMPACTO", "NOMBRE_IMPACTO", tKT.ID_IMPACTO);
            ViewBag.ID_LOGIN = new SelectList(db.LOGIN, "ID_LOGIN", "PASS_HASH", tKT.ID_LOGIN);
            ViewBag.ID_SERVI_EMP = new SelectList(db.SERVICIO_EMPRESA, "ID_SERVI_EMP", "ID_SERVI_EMP", tKT.ID_SERVI_EMP);
            ViewBag.ID_TIPO = new SelectList(db.TIPIFICACION, "ID_TIPO", "NOMBRE_TIPO", tKT.ID_TIPO);
            ViewBag.ID_URGENCIA = new SelectList(db.URGENCIA, "ID_URGENCIA", "RUT_EMPRESA_PROV", tKT.ID_URGENCIA);
            return View(tKT);
        }

        // POST: TKTs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TKT,ID_URGENCIA,ID_ESTADO,ID_IMPACTO,ID_TIPO,ID_LOGIN,ID_SERVI_EMP,CREADOR_TKT,REPORTADOR_TKT,AFECTADO_TKT,PRIORIDAD_TKT,VALOR_IMPACTO_TKT,VALOR_URGENCIA_TKT,RUT_EMPRESA_PROV")] TKT tKT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tKT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ESTADO = new SelectList(db.ESTADOS, "ID_ESTADO", "RUT_EMPRESA_PROV", tKT.ID_ESTADO);
            ViewBag.ID_IMPACTO = new SelectList(db.IMPACTO, "ID_IMPACTO", "NOMBRE_IMPACTO", tKT.ID_IMPACTO);
            ViewBag.ID_LOGIN = new SelectList(db.LOGIN, "ID_LOGIN", "PASS_HASH", tKT.ID_LOGIN);
            ViewBag.ID_SERVI_EMP = new SelectList(db.SERVICIO_EMPRESA, "ID_SERVI_EMP", "ID_SERVI_EMP", tKT.ID_SERVI_EMP);
            ViewBag.ID_TIPO = new SelectList(db.TIPIFICACION, "ID_TIPO", "NOMBRE_TIPO", tKT.ID_TIPO);
            ViewBag.ID_URGENCIA = new SelectList(db.URGENCIA, "ID_URGENCIA", "RUT_EMPRESA_PROV", tKT.ID_URGENCIA);
            return View(tKT);
        }

        // GET: TKTs/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TKT tKT = db.TKT.Find(id);
            if (tKT == null)
            {
                return HttpNotFound();
            }
            return View(tKT);
        }

        // POST: TKTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            TKT tKT = db.TKT.Find(id);
            db.TKT.Remove(tKT);
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
