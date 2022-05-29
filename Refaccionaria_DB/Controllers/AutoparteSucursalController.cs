using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Refaccionaria_DB.Models;

namespace Refaccionaria_DB.Controllers
{
    public class AutoparteSucursalController : Controller
    {
        private RefaccionariaEntities db = new RefaccionariaEntities();

        // GET: AutoparteSucursal
        public ActionResult Index()
        {
            var autoparteSucursal = db.AutoparteSucursal.Include(a => a.AutoParte).Include(a => a.Sucursal).Include(a => a.Usuario).Include(a => a.Usuario1);
            return View(autoparteSucursal.ToList());
        }

        // GET: AutoparteSucursal/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutoparteSucursal autoparteSucursal = db.AutoparteSucursal.Find(id);
            if (autoparteSucursal == null)
            {
                return HttpNotFound();
            }
            return View(autoparteSucursal);
        }

        // GET: AutoparteSucursal/Create
        public ActionResult Create()
        {
            ViewBag.idAutoparte = new SelectList(db.AutoParte, "idAutoParte", "descripcion");
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: AutoparteSucursal/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idAutoparteSucursal,idAutoparte,idSucursal,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] AutoparteSucursal autoparteSucursal)
        {
            if (ModelState.IsValid)
            {
                db.AutoparteSucursal.Add(autoparteSucursal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idAutoparte = new SelectList(db.AutoParte, "idAutoParte", "descripcion", autoparteSucursal.idAutoparte);
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre", autoparteSucursal.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", autoparteSucursal.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", autoparteSucursal.idUsuarioModifica);
            return View(autoparteSucursal);
        }

        // GET: AutoparteSucursal/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutoparteSucursal autoparteSucursal = db.AutoparteSucursal.Find(id);
            if (autoparteSucursal == null)
            {
                return HttpNotFound();
            }
            ViewBag.idAutoparte = new SelectList(db.AutoParte, "idAutoParte", "descripcion", autoparteSucursal.idAutoparte);
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre", autoparteSucursal.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", autoparteSucursal.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", autoparteSucursal.idUsuarioModifica);
            return View(autoparteSucursal);
        }

        // POST: AutoparteSucursal/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idAutoparteSucursal,idAutoparte,idSucursal,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] AutoparteSucursal autoparteSucursal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(autoparteSucursal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idAutoparte = new SelectList(db.AutoParte, "idAutoParte", "descripcion", autoparteSucursal.idAutoparte);
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre", autoparteSucursal.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", autoparteSucursal.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", autoparteSucursal.idUsuarioModifica);
            return View(autoparteSucursal);
        }

        // GET: AutoparteSucursal/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutoparteSucursal autoparteSucursal = db.AutoparteSucursal.Find(id);
            if (autoparteSucursal == null)
            {
                return HttpNotFound();
            }
            return View(autoparteSucursal);
        }

        // POST: AutoparteSucursal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AutoparteSucursal autoparteSucursal = db.AutoparteSucursal.Find(id);
            db.AutoparteSucursal.Remove(autoparteSucursal);
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
