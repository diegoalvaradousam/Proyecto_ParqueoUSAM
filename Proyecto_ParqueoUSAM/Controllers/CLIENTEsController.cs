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
    public class CLIENTEsController : Controller
    {
        private BD_PARQUEO2Entities1 db = new BD_PARQUEO2Entities1();

        // GET: CLIENTEs
        public async Task<ActionResult> Index()
        {
            var cLIENTE = db.CLIENTE.Include(c => c.LUGAR_PARQUEO);
            return View(await cLIENTE.ToListAsync());
        }

        // GET: CLIENTEs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENTE cLIENTE = await db.CLIENTE.FindAsync(id);
            if (cLIENTE == null)
            {
                return HttpNotFound();
            }
            return View(cLIENTE);
        }

        // GET: CLIENTEs/Create
        public ActionResult Create()
        {
            ViewBag.ID_PARQUEO = new SelectList(db.LUGAR_PARQUEO, "ID_PARQUEO", "NOMBRE_PARQUEO");
            return View();
        }

        // POST: CLIENTEs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_CLIENTE,NOMBRE_CLIENTE,VEHICULO,NUM_PLACA,ID_PARQUEO")] CLIENTE cLIENTE)
        {
            if (ModelState.IsValid)
            {
                db.CLIENTE.Add(cLIENTE);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PARQUEO = new SelectList(db.LUGAR_PARQUEO, "ID_PARQUEO", "NOMBRE_PARQUEO", cLIENTE.ID_PARQUEO);
            return View(cLIENTE);
        }

        // GET: CLIENTEs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENTE cLIENTE = await db.CLIENTE.FindAsync(id);
            if (cLIENTE == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PARQUEO = new SelectList(db.LUGAR_PARQUEO, "ID_PARQUEO", "NOMBRE_PARQUEO", cLIENTE.ID_PARQUEO);
            return View(cLIENTE);
        }

        // POST: CLIENTEs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_CLIENTE,NOMBRE_CLIENTE,VEHICULO,NUM_PLACA,ID_PARQUEO")] CLIENTE cLIENTE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cLIENTE).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PARQUEO = new SelectList(db.LUGAR_PARQUEO, "ID_PARQUEO", "NOMBRE_PARQUEO", cLIENTE.ID_PARQUEO);
            return View(cLIENTE);
        }

        // GET: CLIENTEs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENTE cLIENTE = await db.CLIENTE.FindAsync(id);
            if (cLIENTE == null)
            {
                return HttpNotFound();
            }
            return View(cLIENTE);
        }

        // POST: CLIENTEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CLIENTE cLIENTE = await db.CLIENTE.FindAsync(id);
            db.CLIENTE.Remove(cLIENTE);
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
