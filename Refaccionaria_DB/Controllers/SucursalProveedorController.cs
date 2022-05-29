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
    public class SucursalProveedorController : Controller
    {
        private RefaccionariaEntities db = new RefaccionariaEntities();

        // GET: SucursalProveedor
        public ActionResult Index()
        {
            var sucursalProveedor = db.SucursalProveedor.Include(s => s.Proveedor).Include(s => s.Sucursal).Include(s => s.Usuario).Include(s => s.Usuario1);
            return View(sucursalProveedor.ToList());
        }

        // GET: SucursalProveedor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SucursalProveedor sucursalProveedor = db.SucursalProveedor.Find(id);
            if (sucursalProveedor == null)
            {
                return HttpNotFound();
            }
            return View(sucursalProveedor);
        }

        // GET: SucursalProveedor/Create
        public ActionResult Create()
        {
            ViewBag.idProveedor = new SelectList(db.Proveedor, "idProveedor", "nombre");
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: SucursalProveedor/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idSucursalProveedor,idSucursal,idProveedor,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] SucursalProveedor sucursalProveedor)
        {
            if (ModelState.IsValid)
            {
                db.SucursalProveedor.Add(sucursalProveedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idProveedor = new SelectList(db.Proveedor, "idProveedor", "nombre", sucursalProveedor.idProveedor);
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre", sucursalProveedor.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", sucursalProveedor.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", sucursalProveedor.idUsuarioModifica);
            return View(sucursalProveedor);
        }

        // GET: SucursalProveedor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SucursalProveedor sucursalProveedor = db.SucursalProveedor.Find(id);
            if (sucursalProveedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.idProveedor = new SelectList(db.Proveedor, "idProveedor", "nombre", sucursalProveedor.idProveedor);
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre", sucursalProveedor.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", sucursalProveedor.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", sucursalProveedor.idUsuarioModifica);
            return View(sucursalProveedor);
        }

        // POST: SucursalProveedor/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idSucursalProveedor,idSucursal,idProveedor,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] SucursalProveedor sucursalProveedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sucursalProveedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idProveedor = new SelectList(db.Proveedor, "idProveedor", "nombre", sucursalProveedor.idProveedor);
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre", sucursalProveedor.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", sucursalProveedor.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", sucursalProveedor.idUsuarioModifica);
            return View(sucursalProveedor);
        }

        // GET: SucursalProveedor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SucursalProveedor sucursalProveedor = db.SucursalProveedor.Find(id);
            if (sucursalProveedor == null)
            {
                return HttpNotFound();
            }
            return View(sucursalProveedor);
        }

        // POST: SucursalProveedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SucursalProveedor sucursalProveedor = db.SucursalProveedor.Find(id);
            db.SucursalProveedor.Remove(sucursalProveedor);
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
