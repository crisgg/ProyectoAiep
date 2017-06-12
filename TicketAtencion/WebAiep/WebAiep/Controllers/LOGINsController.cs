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
    public class LOGINsController : Controller
    {
        private DB_A255CD_MoDeskBDDEntities db = new DB_A255CD_MoDeskBDDEntities();

        // GET: LOGINs
        public async Task<ActionResult> Index()
        {
            return View(await db.LOGIN.ToListAsync());
        }

        public async Task<ActionResult> Login()
        {
            return View();
        }

        // GET: LOGINs/Details/5
        public async Task<ActionResult> Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOGIN lOGIN = await db.LOGIN.FindAsync(id);
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
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_LOGIN,PASS_HASH,USER_NAME")] LOGIN lOGIN)
        {
            if (ModelState.IsValid)
            {
                db.LOGIN.Add(lOGIN);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(lOGIN);
        }

        // GET: LOGINs/Edit/5
        public async Task<ActionResult> Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOGIN lOGIN = await db.LOGIN.FindAsync(id);
            if (lOGIN == null)
            {
                return HttpNotFound();
            }
            return View(lOGIN);
        }

        // POST: LOGINs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_LOGIN,PASS_HASH,USER_NAME")] LOGIN lOGIN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lOGIN).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(lOGIN);
        }

        // GET: LOGINs/Delete/5
        public async Task<ActionResult> Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOGIN lOGIN = await db.LOGIN.FindAsync(id);
            if (lOGIN == null)
            {
                return HttpNotFound();
            }
            return View(lOGIN);
        }

        // POST: LOGINs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(decimal id)
        {
            LOGIN lOGIN = await db.LOGIN.FindAsync(id);
            db.LOGIN.Remove(lOGIN);
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
