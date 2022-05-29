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
    public class SucursalEstadoController : Controller
    {
        private RefaccionariaEntities db = new RefaccionariaEntities();

        // GET: SucursalEstado
        public ActionResult Index()
        {
            var sucursalEstado = db.SucursalEstado.Include(s => s.Estado).Include(s => s.Sucursal).Include(s => s.Usuario).Include(s => s.Usuario1);
            return View(sucursalEstado.ToList());
        }

        // GET: SucursalEstado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SucursalEstado sucursalEstado = db.SucursalEstado.Find(id);
            if (sucursalEstado == null)
            {
                return HttpNotFound();
            }
            return View(sucursalEstado);
        }

        // GET: SucursalEstado/Create
        public ActionResult Create()
        {
            ViewBag.idEstado = new SelectList(db.Estado, "idEstado", "nombre");
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: SucursalEstado/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idSucursalEstado,idSucursal,idEstado,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] SucursalEstado sucursalEstado)
        {
            if (ModelState.IsValid)
            {
                db.SucursalEstado.Add(sucursalEstado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEstado = new SelectList(db.Estado, "idEstado", "nombre", sucursalEstado.idEstado);
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre", sucursalEstado.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", sucursalEstado.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", sucursalEstado.idUsuarioModifica);
            return View(sucursalEstado);
        }

        // GET: SucursalEstado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SucursalEstado sucursalEstado = db.SucursalEstado.Find(id);
            if (sucursalEstado == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEstado = new SelectList(db.Estado, "idEstado", "nombre", sucursalEstado.idEstado);
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre", sucursalEstado.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", sucursalEstado.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", sucursalEstado.idUsuarioModifica);
            return View(sucursalEstado);
        }

        // POST: SucursalEstado/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idSucursalEstado,idSucursal,idEstado,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] SucursalEstado sucursalEstado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sucursalEstado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEstado = new SelectList(db.Estado, "idEstado", "nombre", sucursalEstado.idEstado);
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre", sucursalEstado.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", sucursalEstado.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", sucursalEstado.idUsuarioModifica);
            return View(sucursalEstado);
        }

        // GET: SucursalEstado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SucursalEstado sucursalEstado = db.SucursalEstado.Find(id);
            if (sucursalEstado == null)
            {
                return HttpNotFound();
            }
            return View(sucursalEstado);
        }

        // POST: SucursalEstado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SucursalEstado sucursalEstado = db.SucursalEstado.Find(id);
            db.SucursalEstado.Remove(sucursalEstado);
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
