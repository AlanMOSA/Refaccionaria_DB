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
    public class TipoProveedorController : Controller
    {
        private RefaccionariaEntities db = new RefaccionariaEntities();

        // GET: TipoProveedor
        public ActionResult Index()
        {
            var tipoProveedor = db.TipoProveedor.Include(t => t.Proveedor).Include(t => t.Usuario).Include(t => t.Usuario1);
            return View(tipoProveedor.ToList());
        }

        // GET: TipoProveedor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoProveedor tipoProveedor = db.TipoProveedor.Find(id);
            if (tipoProveedor == null)
            {
                return HttpNotFound();
            }
            return View(tipoProveedor);
        }

        // GET: TipoProveedor/Create
        public ActionResult Create()
        {
            ViewBag.idProveedor = new SelectList(db.Proveedor, "idProveedor", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: TipoProveedor/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipoProveedor,nombre,idProveedor,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] TipoProveedor tipoProveedor)
        {
            if (ModelState.IsValid)
            {
                db.TipoProveedor.Add(tipoProveedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idProveedor = new SelectList(db.Proveedor, "idProveedor", "nombre", tipoProveedor.idProveedor);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", tipoProveedor.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", tipoProveedor.idUsuarioModifica);
            return View(tipoProveedor);
        }

        // GET: TipoProveedor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoProveedor tipoProveedor = db.TipoProveedor.Find(id);
            if (tipoProveedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.idProveedor = new SelectList(db.Proveedor, "idProveedor", "nombre", tipoProveedor.idProveedor);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", tipoProveedor.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", tipoProveedor.idUsuarioModifica);
            return View(tipoProveedor);
        }

        // POST: TipoProveedor/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipoProveedor,nombre,idProveedor,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] TipoProveedor tipoProveedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoProveedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idProveedor = new SelectList(db.Proveedor, "idProveedor", "nombre", tipoProveedor.idProveedor);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", tipoProveedor.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", tipoProveedor.idUsuarioModifica);
            return View(tipoProveedor);
        }

        // GET: TipoProveedor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoProveedor tipoProveedor = db.TipoProveedor.Find(id);
            if (tipoProveedor == null)
            {
                return HttpNotFound();
            }
            return View(tipoProveedor);
        }

        // POST: TipoProveedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoProveedor tipoProveedor = db.TipoProveedor.Find(id);
            db.TipoProveedor.Remove(tipoProveedor);
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
