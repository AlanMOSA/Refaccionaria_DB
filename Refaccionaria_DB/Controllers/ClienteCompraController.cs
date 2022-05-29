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
    public class ClienteCompraController : Controller
    {
        private RefaccionariaEntities db = new RefaccionariaEntities();

        // GET: ClienteCompra
        public ActionResult Index()
        {
            var clienteCompra = db.ClienteCompra.Include(c => c.Cliente).Include(c => c.Compra).Include(c => c.Usuario).Include(c => c.Usuario1);
            return View(clienteCompra.ToList());
        }

        // GET: ClienteCompra/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteCompra clienteCompra = db.ClienteCompra.Find(id);
            if (clienteCompra == null)
            {
                return HttpNotFound();
            }
            return View(clienteCompra);
        }

        // GET: ClienteCompra/Create
        public ActionResult Create()
        {
            ViewBag.idCliente = new SelectList(db.Cliente, "idCliente", "nombre");
            ViewBag.idCompra = new SelectList(db.Compra, "idCompra", "detalles");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: ClienteCompra/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idClienteCompra,idCliente,idCompra,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] ClienteCompra clienteCompra)
        {
            if (ModelState.IsValid)
            {
                db.ClienteCompra.Add(clienteCompra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCliente = new SelectList(db.Cliente, "idCliente", "nombre", clienteCompra.idCliente);
            ViewBag.idCompra = new SelectList(db.Compra, "idCompra", "detalles", clienteCompra.idCompra);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", clienteCompra.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", clienteCompra.idUsuarioModifica);
            return View(clienteCompra);
        }

        // GET: ClienteCompra/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteCompra clienteCompra = db.ClienteCompra.Find(id);
            if (clienteCompra == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCliente = new SelectList(db.Cliente, "idCliente", "nombre", clienteCompra.idCliente);
            ViewBag.idCompra = new SelectList(db.Compra, "idCompra", "detalles", clienteCompra.idCompra);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", clienteCompra.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", clienteCompra.idUsuarioModifica);
            return View(clienteCompra);
        }

        // POST: ClienteCompra/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idClienteCompra,idCliente,idCompra,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] ClienteCompra clienteCompra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clienteCompra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCliente = new SelectList(db.Cliente, "idCliente", "nombre", clienteCompra.idCliente);
            ViewBag.idCompra = new SelectList(db.Compra, "idCompra", "detalles", clienteCompra.idCompra);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", clienteCompra.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", clienteCompra.idUsuarioModifica);
            return View(clienteCompra);
        }

        // GET: ClienteCompra/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteCompra clienteCompra = db.ClienteCompra.Find(id);
            if (clienteCompra == null)
            {
                return HttpNotFound();
            }
            return View(clienteCompra);
        }

        // POST: ClienteCompra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClienteCompra clienteCompra = db.ClienteCompra.Find(id);
            db.ClienteCompra.Remove(clienteCompra);
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
