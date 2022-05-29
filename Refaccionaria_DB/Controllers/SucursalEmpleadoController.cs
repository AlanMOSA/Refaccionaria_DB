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
    public class SucursalEmpleadoController : Controller
    {
        private RefaccionariaEntities db = new RefaccionariaEntities();

        // GET: SucursalEmpleado
        public ActionResult Index()
        {
            var sucursalEmpleado = db.SucursalEmpleado.Include(s => s.Empleado).Include(s => s.Sucursal).Include(s => s.Usuario).Include(s => s.Usuario1);
            return View(sucursalEmpleado.ToList());
        }

        // GET: SucursalEmpleado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SucursalEmpleado sucursalEmpleado = db.SucursalEmpleado.Find(id);
            if (sucursalEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(sucursalEmpleado);
        }

        // GET: SucursalEmpleado/Create
        public ActionResult Create()
        {
            ViewBag.idEmpleado = new SelectList(db.Empleado, "idEmpleado", "nombre");
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: SucursalEmpleado/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idSucursalEmpleado,idSucursal,idEmpleado,fechaIngreso,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] SucursalEmpleado sucursalEmpleado)
        {
            if (ModelState.IsValid)
            {
                db.SucursalEmpleado.Add(sucursalEmpleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEmpleado = new SelectList(db.Empleado, "idEmpleado", "nombre", sucursalEmpleado.idEmpleado);
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre", sucursalEmpleado.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", sucursalEmpleado.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", sucursalEmpleado.idUsuarioModifica);
            return View(sucursalEmpleado);
        }

        // GET: SucursalEmpleado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SucursalEmpleado sucursalEmpleado = db.SucursalEmpleado.Find(id);
            if (sucursalEmpleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEmpleado = new SelectList(db.Empleado, "idEmpleado", "nombre", sucursalEmpleado.idEmpleado);
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre", sucursalEmpleado.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", sucursalEmpleado.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", sucursalEmpleado.idUsuarioModifica);
            return View(sucursalEmpleado);
        }

        // POST: SucursalEmpleado/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idSucursalEmpleado,idSucursal,idEmpleado,fechaIngreso,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] SucursalEmpleado sucursalEmpleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sucursalEmpleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEmpleado = new SelectList(db.Empleado, "idEmpleado", "nombre", sucursalEmpleado.idEmpleado);
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre", sucursalEmpleado.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", sucursalEmpleado.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", sucursalEmpleado.idUsuarioModifica);
            return View(sucursalEmpleado);
        }

        // GET: SucursalEmpleado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SucursalEmpleado sucursalEmpleado = db.SucursalEmpleado.Find(id);
            if (sucursalEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(sucursalEmpleado);
        }

        // POST: SucursalEmpleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SucursalEmpleado sucursalEmpleado = db.SucursalEmpleado.Find(id);
            db.SucursalEmpleado.Remove(sucursalEmpleado);
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
