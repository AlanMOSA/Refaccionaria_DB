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
    public class ProductoVentaController : Controller
    {
        private RefaccionariaEntities db = new RefaccionariaEntities();

        // GET: ProductoVenta
        public ActionResult Index()
        {
            var productoVenta = db.ProductoVenta.Include(p => p.Producto).Include(p => p.Usuario).Include(p => p.Usuario1).Include(p => p.Venta);
            return View(productoVenta.ToList());
        }

        // GET: ProductoVenta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoVenta productoVenta = db.ProductoVenta.Find(id);
            if (productoVenta == null)
            {
                return HttpNotFound();
            }
            return View(productoVenta);
        }

        // GET: ProductoVenta/Create
        public ActionResult Create()
        {
            ViewBag.idProducto = new SelectList(db.Producto, "idProducto", "descripcion");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idVenta = new SelectList(db.Venta, "idVenta", "descripcion");
            return View();
        }

        // POST: ProductoVenta/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProductoVenta,idProducto,idVenta,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] ProductoVenta productoVenta)
        {
            if (ModelState.IsValid)
            {
                db.ProductoVenta.Add(productoVenta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idProducto = new SelectList(db.Producto, "idProducto", "descripcion", productoVenta.idProducto);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", productoVenta.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", productoVenta.idUsuarioModifica);
            ViewBag.idVenta = new SelectList(db.Venta, "idVenta", "descripcion", productoVenta.idVenta);
            return View(productoVenta);
        }

        // GET: ProductoVenta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoVenta productoVenta = db.ProductoVenta.Find(id);
            if (productoVenta == null)
            {
                return HttpNotFound();
            }
            ViewBag.idProducto = new SelectList(db.Producto, "idProducto", "descripcion", productoVenta.idProducto);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", productoVenta.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", productoVenta.idUsuarioModifica);
            ViewBag.idVenta = new SelectList(db.Venta, "idVenta", "descripcion", productoVenta.idVenta);
            return View(productoVenta);
        }

        // POST: ProductoVenta/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProductoVenta,idProducto,idVenta,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] ProductoVenta productoVenta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productoVenta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idProducto = new SelectList(db.Producto, "idProducto", "descripcion", productoVenta.idProducto);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", productoVenta.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", productoVenta.idUsuarioModifica);
            ViewBag.idVenta = new SelectList(db.Venta, "idVenta", "descripcion", productoVenta.idVenta);
            return View(productoVenta);
        }

        // GET: ProductoVenta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoVenta productoVenta = db.ProductoVenta.Find(id);
            if (productoVenta == null)
            {
                return HttpNotFound();
            }
            return View(productoVenta);
        }

        // POST: ProductoVenta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductoVenta productoVenta = db.ProductoVenta.Find(id);
            db.ProductoVenta.Remove(productoVenta);
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
