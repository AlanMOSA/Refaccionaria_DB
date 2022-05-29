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
    public class CompraController : Controller
    {
        private RefaccionariaEntities db = new RefaccionariaEntities();

        // GET: Compra
        public ActionResult Index()
        {
            var compra = db.Compra.Include(c => c.Factura).Include(c => c.FormaPago).Include(c => c.Usuario).Include(c => c.Usuario1);
            return View(compra.ToList());
        }

        // GET: Compra/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.Compra.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // GET: Compra/Create
        public ActionResult Create()
        {
            ViewBag.idFactura = new SelectList(db.Factura, "idFactura", "detalles");
            ViewBag.idFormaPago = new SelectList(db.FormaPago, "idFormaPago", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: Compra/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCompra,fecha,monto,detalles,idFormaPago,idFactura,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                db.Compra.Add(compra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idFactura = new SelectList(db.Factura, "idFactura", "detalles", compra.idFactura);
            ViewBag.idFormaPago = new SelectList(db.FormaPago, "idFormaPago", "nombre", compra.idFormaPago);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", compra.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", compra.idUsuarioModifica);
            return View(compra);
        }

        // GET: Compra/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.Compra.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            ViewBag.idFactura = new SelectList(db.Factura, "idFactura", "detalles", compra.idFactura);
            ViewBag.idFormaPago = new SelectList(db.FormaPago, "idFormaPago", "nombre", compra.idFormaPago);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", compra.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", compra.idUsuarioModifica);
            return View(compra);
        }

        // POST: Compra/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCompra,fecha,monto,detalles,idFormaPago,idFactura,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idFactura = new SelectList(db.Factura, "idFactura", "detalles", compra.idFactura);
            ViewBag.idFormaPago = new SelectList(db.FormaPago, "idFormaPago", "nombre", compra.idFormaPago);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", compra.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", compra.idUsuarioModifica);
            return View(compra);
        }

        // GET: Compra/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.Compra.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // POST: Compra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Compra compra = db.Compra.Find(id);
            db.Compra.Remove(compra);
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
