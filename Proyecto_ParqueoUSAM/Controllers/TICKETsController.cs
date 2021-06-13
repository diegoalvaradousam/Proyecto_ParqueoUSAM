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
    public class TICKETsController : Controller
    {
        private BD_PARQUEO2Entities1 db = new BD_PARQUEO2Entities1();

        // GET: TICKETs
        public async Task<ActionResult> Index()
        {
            var tICKET = db.TICKET.Include(t => t.CLIENTE).Include(t => t.LUGAR_PARQUEO);
            return View(await tICKET.ToListAsync());
        }

        // GET: TICKETs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TICKET tICKET = await db.TICKET.FindAsync(id);
            if (tICKET == null)
            {
                return HttpNotFound();
            }
            return View(tICKET);
        }

        // GET: TICKETs/Create
        public ActionResult Create()
        {
            ViewBag.ID_CLIENTE = new SelectList(db.CLIENTE, "ID_CLIENTE", "NOMBRE_CLIENTE");
            ViewBag.ID_PARQUEO = new SelectList(db.LUGAR_PARQUEO, "ID_PARQUEO", "NOMBRE_PARQUEO");
            return View();
        }

        // POST: TICKETs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_TICKET,ID_CLIENTE,ID_PARQUEO,TIPO_TICKET,FECHA,TIEMPO_PARQUEO,COSTO_FINAL")] TICKET tICKET)
        {
            if (ModelState.IsValid)
            {
                db.TICKET.Add(tICKET);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ID_CLIENTE = new SelectList(db.CLIENTE, "ID_CLIENTE", "NOMBRE_CLIENTE", tICKET.ID_CLIENTE);
            ViewBag.ID_PARQUEO = new SelectList(db.LUGAR_PARQUEO, "ID_PARQUEO", "NOMBRE_PARQUEO", tICKET.ID_PARQUEO);
            return View(tICKET);
        }

        // GET: TICKETs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TICKET tICKET = await db.TICKET.FindAsync(id);
            if (tICKET == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CLIENTE = new SelectList(db.CLIENTE, "ID_CLIENTE", "NOMBRE_CLIENTE", tICKET.ID_CLIENTE);
            ViewBag.ID_PARQUEO = new SelectList(db.LUGAR_PARQUEO, "ID_PARQUEO", "NOMBRE_PARQUEO", tICKET.ID_PARQUEO);
            return View(tICKET);
        }

        // POST: TICKETs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_TICKET,ID_CLIENTE,ID_PARQUEO,TIPO_TICKET,FECHA,TIEMPO_PARQUEO,COSTO_FINAL")] TICKET tICKET)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tICKET).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CLIENTE = new SelectList(db.CLIENTE, "ID_CLIENTE", "NOMBRE_CLIENTE", tICKET.ID_CLIENTE);
            ViewBag.ID_PARQUEO = new SelectList(db.LUGAR_PARQUEO, "ID_PARQUEO", "NOMBRE_PARQUEO", tICKET.ID_PARQUEO);
            return View(tICKET);
        }

        // GET: TICKETs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TICKET tICKET = await db.TICKET.FindAsync(id);
            if (tICKET == null)
            {
                return HttpNotFound();
            }
            return View(tICKET);
        }

        // POST: TICKETs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TICKET tICKET = await db.TICKET.FindAsync(id);
            db.TICKET.Remove(tICKET);
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
