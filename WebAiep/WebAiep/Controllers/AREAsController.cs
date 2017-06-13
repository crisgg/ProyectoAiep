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
    public class AREAsController : Controller
    {
        private DB_A255CD_MoDeskBDDEntities db = new DB_A255CD_MoDeskBDDEntities();

        // GET: AREAs
        public async Task<ActionResult> Index()
        {
            return View(await db.AREA.ToListAsync());
        }

        // GET: AREAs/Details/5
        public async Task<ActionResult> Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AREA aREA = await db.AREA.FindAsync(id);
            if (aREA == null)
            {
                return HttpNotFound();
            }
            return View(aREA);
        }

        // GET: AREAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AREAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_AREA,EMAIL_AREA,DESCRIPCION_AREA")] AREA aREA)
        {
            if (ModelState.IsValid)
            {
                aREA.ID_EMPRESA_PROV = 1;
                db.AREA.Add(aREA);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(aREA);
        }

        // GET: AREAs/Edit/5
        public async Task<ActionResult> Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AREA aREA = await db.AREA.FindAsync(id);
            if (aREA == null)
            {
                return HttpNotFound();
            }
            return View(aREA);
        }

        // POST: AREAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_EMPRESA_PROV,ID_AREA,EMAIL_AREA,DESCRIPCION_AREA")] AREA aREA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aREA).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(aREA);
        }

        // GET: AREAs/Delete/5
        public async Task<ActionResult> Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AREA aREA = await db.AREA.FindAsync(id);
            if (aREA == null)
            {
                return HttpNotFound();
            }
            return View(aREA);
        }

        // POST: AREAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(decimal id)
        {
            AREA aREA = await db.AREA.FindAsync(id);
            db.AREA.Remove(aREA);
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
