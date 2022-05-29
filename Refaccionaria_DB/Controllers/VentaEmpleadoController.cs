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
    public class VentaEmpleadoController : Controller
    {
        private RefaccionariaEntities db = new RefaccionariaEntities();

        // GET: VentaEmpleado
        public ActionResult Index()
        {
            var ventaEmpleado = db.VentaEmpleado.Include(v => v.Empleado).Include(v => v.Usuario).Include(v => v.Usuario1).Include(v => v.Venta);
            return View(ventaEmpleado.ToList());
        }

        // GET: VentaEmpleado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentaEmpleado ventaEmpleado = db.VentaEmpleado.Find(id);
            if (ventaEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(ventaEmpleado);
        }

        // GET: VentaEmpleado/Create
        public ActionResult Create()
        {
            ViewBag.idEmpleado = new SelectList(db.Empleado, "idEmpleado", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idVenta = new SelectList(db.Venta, "idVenta", "descripcion");
            return View();
        }

        // POST: VentaEmpleado/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idVentaEmpleado,idVenta,idEmpleado,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] VentaEmpleado ventaEmpleado)
        {
            if (ModelState.IsValid)
            {
                db.VentaEmpleado.Add(ventaEmpleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEmpleado = new SelectList(db.Empleado, "idEmpleado", "nombre", ventaEmpleado.idEmpleado);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", ventaEmpleado.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", ventaEmpleado.idUsuarioModifica);
            ViewBag.idVenta = new SelectList(db.Venta, "idVenta", "descripcion", ventaEmpleado.idVenta);
            return View(ventaEmpleado);
        }

        // GET: VentaEmpleado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentaEmpleado ventaEmpleado = db.VentaEmpleado.Find(id);
            if (ventaEmpleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEmpleado = new SelectList(db.Empleado, "idEmpleado", "nombre", ventaEmpleado.idEmpleado);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", ventaEmpleado.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", ventaEmpleado.idUsuarioModifica);
            ViewBag.idVenta = new SelectList(db.Venta, "idVenta", "descripcion", ventaEmpleado.idVenta);
            return View(ventaEmpleado);
        }

        // POST: VentaEmpleado/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idVentaEmpleado,idVenta,idEmpleado,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] VentaEmpleado ventaEmpleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ventaEmpleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEmpleado = new SelectList(db.Empleado, "idEmpleado", "nombre", ventaEmpleado.idEmpleado);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", ventaEmpleado.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", ventaEmpleado.idUsuarioModifica);
            ViewBag.idVenta = new SelectList(db.Venta, "idVenta", "descripcion", ventaEmpleado.idVenta);
            return View(ventaEmpleado);
        }

        // GET: VentaEmpleado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentaEmpleado ventaEmpleado = db.VentaEmpleado.Find(id);
            if (ventaEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(ventaEmpleado);
        }

        // POST: VentaEmpleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VentaEmpleado ventaEmpleado = db.VentaEmpleado.Find(id);
            db.VentaEmpleado.Remove(ventaEmpleado);
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
