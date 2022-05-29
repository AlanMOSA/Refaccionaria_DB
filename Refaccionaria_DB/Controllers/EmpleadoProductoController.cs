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
    public class EmpleadoProductoController : Controller
    {
        private RefaccionariaEntities db = new RefaccionariaEntities();

        // GET: EmpleadoProducto
        public ActionResult Index()
        {
            var empleadoProducto = db.EmpleadoProducto.Include(e => e.Empleado).Include(e => e.Producto).Include(e => e.Usuario).Include(e => e.Usuario1);
            return View(empleadoProducto.ToList());
        }

        // GET: EmpleadoProducto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpleadoProducto empleadoProducto = db.EmpleadoProducto.Find(id);
            if (empleadoProducto == null)
            {
                return HttpNotFound();
            }
            return View(empleadoProducto);
        }

        // GET: EmpleadoProducto/Create
        public ActionResult Create()
        {
            ViewBag.idEmpleado = new SelectList(db.Empleado, "idEmpleado", "nombre");
            ViewBag.idProducto = new SelectList(db.Producto, "idProducto", "descripcion");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: EmpleadoProducto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEmpleadoProducto,idEmpleado,idProducto,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] EmpleadoProducto empleadoProducto)
        {
            if (ModelState.IsValid)
            {
                db.EmpleadoProducto.Add(empleadoProducto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEmpleado = new SelectList(db.Empleado, "idEmpleado", "nombre", empleadoProducto.idEmpleado);
            ViewBag.idProducto = new SelectList(db.Producto, "idProducto", "descripcion", empleadoProducto.idProducto);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", empleadoProducto.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", empleadoProducto.idUsuarioModifica);
            return View(empleadoProducto);
        }

        // GET: EmpleadoProducto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpleadoProducto empleadoProducto = db.EmpleadoProducto.Find(id);
            if (empleadoProducto == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEmpleado = new SelectList(db.Empleado, "idEmpleado", "nombre", empleadoProducto.idEmpleado);
            ViewBag.idProducto = new SelectList(db.Producto, "idProducto", "descripcion", empleadoProducto.idProducto);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", empleadoProducto.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", empleadoProducto.idUsuarioModifica);
            return View(empleadoProducto);
        }

        // POST: EmpleadoProducto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEmpleadoProducto,idEmpleado,idProducto,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] EmpleadoProducto empleadoProducto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleadoProducto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEmpleado = new SelectList(db.Empleado, "idEmpleado", "nombre", empleadoProducto.idEmpleado);
            ViewBag.idProducto = new SelectList(db.Producto, "idProducto", "descripcion", empleadoProducto.idProducto);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", empleadoProducto.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", empleadoProducto.idUsuarioModifica);
            return View(empleadoProducto);
        }

        // GET: EmpleadoProducto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpleadoProducto empleadoProducto = db.EmpleadoProducto.Find(id);
            if (empleadoProducto == null)
            {
                return HttpNotFound();
            }
            return View(empleadoProducto);
        }

        // POST: EmpleadoProducto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmpleadoProducto empleadoProducto = db.EmpleadoProducto.Find(id);
            db.EmpleadoProducto.Remove(empleadoProducto);
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
