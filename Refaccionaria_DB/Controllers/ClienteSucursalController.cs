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
    public class ClienteSucursalController : Controller
    {
        private RefaccionariaEntities db = new RefaccionariaEntities();

        // GET: ClienteSucursal
        public ActionResult Index()
        {
            var clienteSucursal = db.ClienteSucursal.Include(c => c.Cliente).Include(c => c.Sucursal).Include(c => c.Usuario).Include(c => c.Usuario1);
            return View(clienteSucursal.ToList());
        }

        // GET: ClienteSucursal/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteSucursal clienteSucursal = db.ClienteSucursal.Find(id);
            if (clienteSucursal == null)
            {
                return HttpNotFound();
            }
            return View(clienteSucursal);
        }

        // GET: ClienteSucursal/Create
        public ActionResult Create()
        {
            ViewBag.idCliente = new SelectList(db.Cliente, "idCliente", "nombre");
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: ClienteSucursal/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idClienteSucursal,idCliente,idSucursal,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] ClienteSucursal clienteSucursal)
        {
            if (ModelState.IsValid)
            {
                db.ClienteSucursal.Add(clienteSucursal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCliente = new SelectList(db.Cliente, "idCliente", "nombre", clienteSucursal.idCliente);
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre", clienteSucursal.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", clienteSucursal.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", clienteSucursal.idUsuarioModifica);
            return View(clienteSucursal);
        }

        // GET: ClienteSucursal/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteSucursal clienteSucursal = db.ClienteSucursal.Find(id);
            if (clienteSucursal == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCliente = new SelectList(db.Cliente, "idCliente", "nombre", clienteSucursal.idCliente);
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre", clienteSucursal.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", clienteSucursal.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", clienteSucursal.idUsuarioModifica);
            return View(clienteSucursal);
        }

        // POST: ClienteSucursal/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idClienteSucursal,idCliente,idSucursal,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] ClienteSucursal clienteSucursal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clienteSucursal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCliente = new SelectList(db.Cliente, "idCliente", "nombre", clienteSucursal.idCliente);
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre", clienteSucursal.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", clienteSucursal.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", clienteSucursal.idUsuarioModifica);
            return View(clienteSucursal);
        }

        // GET: ClienteSucursal/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteSucursal clienteSucursal = db.ClienteSucursal.Find(id);
            if (clienteSucursal == null)
            {
                return HttpNotFound();
            }
            return View(clienteSucursal);
        }

        // POST: ClienteSucursal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClienteSucursal clienteSucursal = db.ClienteSucursal.Find(id);
            db.ClienteSucursal.Remove(clienteSucursal);
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
