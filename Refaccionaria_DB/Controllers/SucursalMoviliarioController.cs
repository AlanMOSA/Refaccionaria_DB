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
    public class SucursalMoviliarioController : Controller
    {
        private RefaccionariaEntities db = new RefaccionariaEntities();

        // GET: SucursalMoviliario
        public ActionResult Index()
        {
            var sucursalMoviliario = db.SucursalMoviliario.Include(s => s.Moviliario).Include(s => s.Sucursal).Include(s => s.Usuario).Include(s => s.Usuario1);
            return View(sucursalMoviliario.ToList());
        }

        // GET: SucursalMoviliario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SucursalMoviliario sucursalMoviliario = db.SucursalMoviliario.Find(id);
            if (sucursalMoviliario == null)
            {
                return HttpNotFound();
            }
            return View(sucursalMoviliario);
        }

        // GET: SucursalMoviliario/Create
        public ActionResult Create()
        {
            ViewBag.idMoviliario = new SelectList(db.Moviliario, "idMoviliario", "nombre");
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: SucursalMoviliario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idSucursalMoviliario,idSucursal,idMoviliario,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] SucursalMoviliario sucursalMoviliario)
        {
            if (ModelState.IsValid)
            {
                db.SucursalMoviliario.Add(sucursalMoviliario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idMoviliario = new SelectList(db.Moviliario, "idMoviliario", "nombre", sucursalMoviliario.idMoviliario);
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre", sucursalMoviliario.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", sucursalMoviliario.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", sucursalMoviliario.idUsuarioModifica);
            return View(sucursalMoviliario);
        }

        // GET: SucursalMoviliario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SucursalMoviliario sucursalMoviliario = db.SucursalMoviliario.Find(id);
            if (sucursalMoviliario == null)
            {
                return HttpNotFound();
            }
            ViewBag.idMoviliario = new SelectList(db.Moviliario, "idMoviliario", "nombre", sucursalMoviliario.idMoviliario);
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre", sucursalMoviliario.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", sucursalMoviliario.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", sucursalMoviliario.idUsuarioModifica);
            return View(sucursalMoviliario);
        }

        // POST: SucursalMoviliario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idSucursalMoviliario,idSucursal,idMoviliario,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] SucursalMoviliario sucursalMoviliario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sucursalMoviliario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idMoviliario = new SelectList(db.Moviliario, "idMoviliario", "nombre", sucursalMoviliario.idMoviliario);
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre", sucursalMoviliario.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", sucursalMoviliario.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", sucursalMoviliario.idUsuarioModifica);
            return View(sucursalMoviliario);
        }

        // GET: SucursalMoviliario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SucursalMoviliario sucursalMoviliario = db.SucursalMoviliario.Find(id);
            if (sucursalMoviliario == null)
            {
                return HttpNotFound();
            }
            return View(sucursalMoviliario);
        }

        // POST: SucursalMoviliario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SucursalMoviliario sucursalMoviliario = db.SucursalMoviliario.Find(id);
            db.SucursalMoviliario.Remove(sucursalMoviliario);
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
