using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<ActionResult> Index()
        {
            var aGENTES = db.AGENTES.Include(a => a.AREA).Include(a => a.COMUNAS).Include(a => a.LOGIN);
            return View(await aGENTES.ToListAsync());
        }

        // GET: AGENTES/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AGENTES aGENTES = await db.AGENTES.FindAsync(id);
            if (aGENTES == null)
            {
                return HttpNotFound();
            }
            return View(aGENTES);
        }

        // GET: AGENTES/Create
        public ActionResult Create()
        {
            ViewBag.ID_AREA = new SelectList(db.AREA, "ID_AREA", "DESCRIPCION_AREA");
            //ViewBag.ID_PAIS = new SelectList(db.PAISES, "ID_PAIS", "NOM_PAIS");
            //ViewBag.ID_Region = new SelectList(db.REGIONES, "ID_REGION", "NOMBRE_REGION");
            ViewBag.ID_COMUNA = new SelectList(db.COMUNAS, "ID_COMUNA", "NOM_COMUNA");
            ViewBag.ID_LOGIN = new SelectList(db.LOGIN, "ID_LOGIN", "PASS_HASH");
            return View();
        }

        // POST: AGENTES/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create( [Bind(Include = "USER_NAME")]LOGIN lOGIN ,[Bind(Include = "ID_AGENTE,ID_LOGIN,ID_COMUNA,ID_AREA,NOMBRE_AGENTE,APELLIDOP_AGENTE,APELLIDOM_AGENTE,EMAIL_AGENTE")] AGENTES aGENTES)
        {
            if (ModelState.IsValid)
            {
                aGENTES.ID_EMPRESA_PROV = 1;

                db.AGENTES.Add(aGENTES);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ID_AREA = new SelectList(db.AREA, "ID_AREA", "DESCRIPCION_AREA", aGENTES.ID_AREA);
            ViewBag.ID_COMUNA = new SelectList(db.COMUNAS, "ID_COMUNA", "NOM_COMUNA", aGENTES.ID_COMUNA);
            ViewBag.ID_LOGIN = new SelectList(db.LOGIN, "ID_LOGIN", "PASS_HASH", aGENTES.ID_LOGIN);
            return View(aGENTES);
        }

        // GET: AGENTES/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AGENTES aGENTES = await db.AGENTES.FindAsync(id);
            if (aGENTES == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_AREA = new SelectList(db.AREA, "ID_AREA", "EMAIL_AREA", aGENTES.ID_AREA);
            ViewBag.ID_COMUNA = new SelectList(db.COMUNAS, "ID_COMUNA", "NOM_COMUNA", aGENTES.ID_COMUNA);
            ViewBag.ID_LOGIN = new SelectList(db.LOGIN, "ID_LOGIN", "PASS_HASH", aGENTES.ID_LOGIN);
            return View(aGENTES);
        }

        // POST: AGENTES/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_AGENTE,ID_LOGIN,ID_COMUNA,ID_AREA,NOMBRE_AGENTE,APELLIDOP_AGENTE,APELLIDOM_AGENTE,EMAIL_AGENTE")] AGENTES aGENTES)
        {
            if (ModelState.IsValid)
            {

                aGENTES.ID_EMPRESA_PROV = 1;

                db.Entry(aGENTES).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ID_AREA = new SelectList(db.AREA, "ID_AREA", "EMAIL_AREA", aGENTES.ID_AREA);
            ViewBag.ID_COMUNA = new SelectList(db.COMUNAS, "ID_COMUNA", "NOM_COMUNA", aGENTES.ID_COMUNA);
            ViewBag.ID_LOGIN = new SelectList(db.LOGIN, "ID_LOGIN", "PASS_HASH", aGENTES.ID_LOGIN);
            return View(aGENTES);
        }

        // GET: AGENTES/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AGENTES aGENTES = await db.AGENTES.FindAsync(id);
            if (aGENTES == null)
            {
                return HttpNotFound();
            }
            return View(aGENTES);
        }

        // POST: AGENTES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AGENTES aGENTES = await db.AGENTES.FindAsync(id);
            db.AGENTES.Remove(aGENTES);
            await db.SaveChangesAsync();
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
