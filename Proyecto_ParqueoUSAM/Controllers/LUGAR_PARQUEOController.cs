using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyecto_ParqueoUSAM;

namespace Proyecto_ParqueoUSAM.Controllers
{
    public class LUGAR_PARQUEOController : Controller
    {
        private BD_PARQUEO2Entities1 db = new BD_PARQUEO2Entities1();

        // GET: LUGAR_PARQUEO
        public async Task<ActionResult> Index()
        {
            return View(await db.LUGAR_PARQUEO.ToListAsync());
        }

        // GET: LUGAR_PARQUEO/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LUGAR_PARQUEO lUGAR_PARQUEO = await db.LUGAR_PARQUEO.FindAsync(id);
            if (lUGAR_PARQUEO == null)
            {
                return HttpNotFound();
            }
            return View(lUGAR_PARQUEO);
        }

        // GET: LUGAR_PARQUEO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LUGAR_PARQUEO/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_PARQUEO,NOMBRE_PARQUEO,DESCRIPCION_D_PARQUEO")] LUGAR_PARQUEO lUGAR_PARQUEO)
        {
            if (ModelState.IsValid)
            {
                db.LUGAR_PARQUEO.Add(lUGAR_PARQUEO);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(lUGAR_PARQUEO);
        }

        // GET: LUGAR_PARQUEO/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LUGAR_PARQUEO lUGAR_PARQUEO = await db.LUGAR_PARQUEO.FindAsync(id);
            if (lUGAR_PARQUEO == null)
            {
                return HttpNotFound();
            }
            return View(lUGAR_PARQUEO);
        }

        // POST: LUGAR_PARQUEO/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_PARQUEO,NOMBRE_PARQUEO,DESCRIPCION_D_PARQUEO")] LUGAR_PARQUEO lUGAR_PARQUEO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lUGAR_PARQUEO).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(lUGAR_PARQUEO);
        }

        // GET: LUGAR_PARQUEO/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LUGAR_PARQUEO lUGAR_PARQUEO = await db.LUGAR_PARQUEO.FindAsync(id);
            if (lUGAR_PARQUEO == null)
            {
                return HttpNotFound();
            }
            return View(lUGAR_PARQUEO);
        }

        // POST: LUGAR_PARQUEO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            LUGAR_PARQUEO lUGAR_PARQUEO = await db.LUGAR_PARQUEO.FindAsync(id);
            db.LUGAR_PARQUEO.Remove(lUGAR_PARQUEO);
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
