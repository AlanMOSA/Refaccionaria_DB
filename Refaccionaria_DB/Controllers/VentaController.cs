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
    public class VentaController : Controller
    {
        private RefaccionariaEntities db = new RefaccionariaEntities();

        // GET: Venta
        public ActionResult Index()
        {
            var venta = db.Venta.Include(v => v.Factura).Include(v => v.FormaPago).Include(v => v.Usuario).Include(v => v.Usuario1);
            return View(venta.ToList());
        }

        // GET: Venta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.Venta.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // GET: Venta/Create
        public ActionResult Create()
        {
            ViewBag.idFactura = new SelectList(db.Factura, "idFactura", "detalles");
            ViewBag.idFormaPago = new SelectList(db.FormaPago, "idFormaPago", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: Venta/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idVenta,fecha,monto,descripcion,idFormaPago,idFactura,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                db.Venta.Add(venta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idFactura = new SelectList(db.Factura, "idFactura", "detalles", venta.idFactura);
            ViewBag.idFormaPago = new SelectList(db.FormaPago, "idFormaPago", "nombre", venta.idFormaPago);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", venta.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", venta.idUsuarioModifica);
            return View(venta);
        }

        // GET: Venta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.Venta.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            ViewBag.idFactura = new SelectList(db.Factura, "idFactura", "detalles", venta.idFactura);
            ViewBag.idFormaPago = new SelectList(db.FormaPago, "idFormaPago", "nombre", venta.idFormaPago);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", venta.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", venta.idUsuarioModifica);
            return View(venta);
        }

        // POST: Venta/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idVenta,fecha,monto,descripcion,idFormaPago,idFactura,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idFactura = new SelectList(db.Factura, "idFactura", "detalles", venta.idFactura);
            ViewBag.idFormaPago = new SelectList(db.FormaPago, "idFormaPago", "nombre", venta.idFormaPago);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", venta.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", venta.idUsuarioModifica);
            return View(venta);
        }

        // GET: Venta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.Venta.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // POST: Venta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Venta venta = db.Venta.Find(id);
            db.Venta.Remove(venta);
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
