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
    public class ClienteProductoController : Controller
    {
        private RefaccionariaEntities db = new RefaccionariaEntities();

        // GET: ClienteProducto
        public ActionResult Index()
        {
            var clienteProducto = db.ClienteProducto.Include(c => c.Cliente).Include(c => c.Producto).Include(c => c.Usuario).Include(c => c.Usuario1);
            return View(clienteProducto.ToList());
        }

        // GET: ClienteProducto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteProducto clienteProducto = db.ClienteProducto.Find(id);
            if (clienteProducto == null)
            {
                return HttpNotFound();
            }
            return View(clienteProducto);
        }

        // GET: ClienteProducto/Create
        public ActionResult Create()
        {
            ViewBag.idCliente = new SelectList(db.Cliente, "idCliente", "nombre");
            ViewBag.idProducto = new SelectList(db.Producto, "idProducto", "descripcion");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: ClienteProducto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idClienteProducto,idCliente,idProducto,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] ClienteProducto clienteProducto)
        {
            if (ModelState.IsValid)
            {
                db.ClienteProducto.Add(clienteProducto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCliente = new SelectList(db.Cliente, "idCliente", "nombre", clienteProducto.idCliente);
            ViewBag.idProducto = new SelectList(db.Producto, "idProducto", "descripcion", clienteProducto.idProducto);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", clienteProducto.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", clienteProducto.idUsuarioModifica);
            return View(clienteProducto);
        }

        // GET: ClienteProducto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteProducto clienteProducto = db.ClienteProducto.Find(id);
            if (clienteProducto == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCliente = new SelectList(db.Cliente, "idCliente", "nombre", clienteProducto.idCliente);
            ViewBag.idProducto = new SelectList(db.Producto, "idProducto", "descripcion", clienteProducto.idProducto);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", clienteProducto.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", clienteProducto.idUsuarioModifica);
            return View(clienteProducto);
        }

        // POST: ClienteProducto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idClienteProducto,idCliente,idProducto,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] ClienteProducto clienteProducto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clienteProducto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCliente = new SelectList(db.Cliente, "idCliente", "nombre", clienteProducto.idCliente);
            ViewBag.idProducto = new SelectList(db.Producto, "idProducto", "descripcion", clienteProducto.idProducto);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", clienteProducto.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", clienteProducto.idUsuarioModifica);
            return View(clienteProducto);
        }

        // GET: ClienteProducto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteProducto clienteProducto = db.ClienteProducto.Find(id);
            if (clienteProducto == null)
            {
                return HttpNotFound();
            }
            return View(clienteProducto);
        }

        // POST: ClienteProducto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClienteProducto clienteProducto = db.ClienteProducto.Find(id);
            db.ClienteProducto.Remove(clienteProducto);
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
