using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoParqueoUSAM.Models;

namespace ProyectoParqueoUSAM.Controllers
{
    public class TICKETsController : Controller
    {
        private BD_PARQUEO2Entities db = new BD_PARQUEO2Entities();

        // GET: TICKETs
        public ActionResult Index()
        {
            var tICKET = db.TICKET.Include(t => t.CLIENTE).Include(t => t.LUGAR_PARQUEO);
            return View(tICKET.ToList());
        }

        // GET: TICKETs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TICKET tICKET = db.TICKET.Find(id);
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
        public ActionResult Create([Bind(Include = "ID_TICKET,ID_CLIENTE,ID_PARQUEO,TIPO_TICKET,FECHA,TIEMPO_PARQUEO,COSTO_FINAL")] TICKET tICKET)
        {
            if (ModelState.IsValid)
            {
                db.TICKET.Add(tICKET);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_CLIENTE = new SelectList(db.CLIENTE, "ID_CLIENTE", "NOMBRE_CLIENTE", tICKET.ID_CLIENTE);
            ViewBag.ID_PARQUEO = new SelectList(db.LUGAR_PARQUEO, "ID_PARQUEO", "NOMBRE_PARQUEO", tICKET.ID_PARQUEO);
            return View(tICKET);
        }

        // GET: TICKETs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TICKET tICKET = db.TICKET.Find(id);
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
        public ActionResult Edit([Bind(Include = "ID_TICKET,ID_CLIENTE,ID_PARQUEO,TIPO_TICKET,FECHA,TIEMPO_PARQUEO,COSTO_FINAL")] TICKET tICKET)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tICKET).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CLIENTE = new SelectList(db.CLIENTE, "ID_CLIENTE", "NOMBRE_CLIENTE", tICKET.ID_CLIENTE);
            ViewBag.ID_PARQUEO = new SelectList(db.LUGAR_PARQUEO, "ID_PARQUEO", "NOMBRE_PARQUEO", tICKET.ID_PARQUEO);
            return View(tICKET);
        }

        // GET: TICKETs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TICKET tICKET = db.TICKET.Find(id);
            if (tICKET == null)
            {
                return HttpNotFound();
            }
            return View(tICKET);
        }

        // POST: TICKETs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TICKET tICKET = db.TICKET.Find(id);
            db.TICKET.Remove(tICKET);
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
