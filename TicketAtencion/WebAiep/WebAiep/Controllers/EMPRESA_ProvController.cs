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
    public class EMPRESA_ProvController : Controller
    {
        private DB_A255CD_MoDeskBDDEntities db = new DB_A255CD_MoDeskBDDEntities();

        // GET: EMPRESA_Prov
        public async Task<ActionResult> Index()
        {
            var eMPRESA_Prov = db.EMPRESA_Prov.Include(e => e.PAISES);
            return View(await eMPRESA_Prov.ToListAsync());
        }

        // GET: EMPRESA_Prov/Details/5
        public async Task<ActionResult> Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPRESA_Prov eMPRESA_Prov = await db.EMPRESA_Prov.FindAsync(id);
            if (eMPRESA_Prov == null)
            {
                return HttpNotFound();
            }
            return View(eMPRESA_Prov);
        }

        // GET: EMPRESA_Prov/Create
        public ActionResult Create()
        {
            ViewBag.ID_PAIS = new SelectList(db.PAISES, "ID_PAIS", "NOM_PAIS");
            return View();
        }

        // POST: EMPRESA_Prov/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_Empresa_Prov,ID_PAIS,NOMBRE_EMPRESA,RAZON_SOCIAL_EMPRESA,DIRECCION_EMPRSA,DNI_Empre_Prov")] EMPRESA_Prov eMPRESA_Prov)
        {
            if (ModelState.IsValid)
            {
                db.EMPRESA_Prov.Add(eMPRESA_Prov);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PAIS = new SelectList(db.PAISES, "ID_PAIS", "NOM_PAIS", eMPRESA_Prov.ID_PAIS);
            return View(eMPRESA_Prov);
        }

        // GET: EMPRESA_Prov/Edit/5
        public async Task<ActionResult> Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPRESA_Prov eMPRESA_Prov = await db.EMPRESA_Prov.FindAsync(id);
            if (eMPRESA_Prov == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PAIS = new SelectList(db.PAISES, "ID_PAIS", "NOM_PAIS", eMPRESA_Prov.ID_PAIS);
            return View(eMPRESA_Prov);
        }

        // POST: EMPRESA_Prov/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_Empresa_Prov,ID_PAIS,NOMBRE_EMPRESA,RAZON_SOCIAL_EMPRESA,DIRECCION_EMPRSA,DNI_Empre_Prov")] EMPRESA_Prov eMPRESA_Prov)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eMPRESA_Prov).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PAIS = new SelectList(db.PAISES, "ID_PAIS", "NOM_PAIS", eMPRESA_Prov.ID_PAIS);
            return View(eMPRESA_Prov);
        }

        // GET: EMPRESA_Prov/Delete/5
        public async Task<ActionResult> Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPRESA_Prov eMPRESA_Prov = await db.EMPRESA_Prov.FindAsync(id);
            if (eMPRESA_Prov == null)
            {
                return HttpNotFound();
            }
            return View(eMPRESA_Prov);
        }

        // POST: EMPRESA_Prov/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(decimal id)
        {
            EMPRESA_Prov eMPRESA_Prov = await db.EMPRESA_Prov.FindAsync(id);
            db.EMPRESA_Prov.Remove(eMPRESA_Prov);
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
