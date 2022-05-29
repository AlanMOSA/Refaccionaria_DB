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
    public class ProductoCompraController : Controller
    {
        private RefaccionariaEntities db = new RefaccionariaEntities();

        // GET: ProductoCompra
        public ActionResult Index()
        {
            var productoCompra = db.ProductoCompra.Include(p => p.Compra).Include(p => p.Producto).Include(p => p.Usuario).Include(p => p.Usuario1);
            return View(productoCompra.ToList());
        }

        // GET: ProductoCompra/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoCompra productoCompra = db.ProductoCompra.Find(id);
            if (productoCompra == null)
            {
                return HttpNotFound();
            }
            return View(productoCompra);
        }

        // GET: ProductoCompra/Create
        public ActionResult Create()
        {
            ViewBag.idCompra = new SelectList(db.Compra, "idCompra", "detalles");
            ViewBag.idProducto = new SelectList(db.Producto, "idProducto", "descripcion");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: ProductoCompra/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProductoCompra,idProducto,idCompra,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] ProductoCompra productoCompra)
        {
            if (ModelState.IsValid)
            {
                db.ProductoCompra.Add(productoCompra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCompra = new SelectList(db.Compra, "idCompra", "detalles", productoCompra.idCompra);
            ViewBag.idProducto = new SelectList(db.Producto, "idProducto", "descripcion", productoCompra.idProducto);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", productoCompra.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", productoCompra.idUsuarioModifica);
            return View(productoCompra);
        }

        // GET: ProductoCompra/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoCompra productoCompra = db.ProductoCompra.Find(id);
            if (productoCompra == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCompra = new SelectList(db.Compra, "idCompra", "detalles", productoCompra.idCompra);
            ViewBag.idProducto = new SelectList(db.Producto, "idProducto", "descripcion", productoCompra.idProducto);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", productoCompra.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", productoCompra.idUsuarioModifica);
            return View(productoCompra);
        }

        // POST: ProductoCompra/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProductoCompra,idProducto,idCompra,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] ProductoCompra productoCompra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productoCompra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCompra = new SelectList(db.Compra, "idCompra", "detalles", productoCompra.idCompra);
            ViewBag.idProducto = new SelectList(db.Producto, "idProducto", "descripcion", productoCompra.idProducto);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", productoCompra.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", productoCompra.idUsuarioModifica);
            return View(productoCompra);
        }

        // GET: ProductoCompra/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoCompra productoCompra = db.ProductoCompra.Find(id);
            if (productoCompra == null)
            {
                return HttpNotFound();
            }
            return View(productoCompra);
        }

        // POST: ProductoCompra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductoCompra productoCompra = db.ProductoCompra.Find(id);
            db.ProductoCompra.Remove(productoCompra);
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
