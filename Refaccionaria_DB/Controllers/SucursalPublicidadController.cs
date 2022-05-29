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
    public class SucursalPublicidadController : Controller
    {
        private RefaccionariaEntities db = new RefaccionariaEntities();

        // GET: SucursalPublicidad
        public ActionResult Index()
        {
            var sucursalPublicidad = db.SucursalPublicidad.Include(s => s.Publicidad).Include(s => s.Sucursal).Include(s => s.Usuario).Include(s => s.Usuario1);
            return View(sucursalPublicidad.ToList());
        }

        // GET: SucursalPublicidad/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SucursalPublicidad sucursalPublicidad = db.SucursalPublicidad.Find(id);
            if (sucursalPublicidad == null)
            {
                return HttpNotFound();
            }
            return View(sucursalPublicidad);
        }

        // GET: SucursalPublicidad/Create
        public ActionResult Create()
        {
            ViewBag.idPublicidad = new SelectList(db.Publicidad, "idPublicidad", "Tipo");
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: SucursalPublicidad/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idSucursalPublicidad,idSucursal,idPublicidad,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] SucursalPublicidad sucursalPublicidad)
        {
            if (ModelState.IsValid)
            {
                db.SucursalPublicidad.Add(sucursalPublicidad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPublicidad = new SelectList(db.Publicidad, "idPublicidad", "Tipo", sucursalPublicidad.idPublicidad);
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre", sucursalPublicidad.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", sucursalPublicidad.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", sucursalPublicidad.idUsuarioModifica);
            return View(sucursalPublicidad);
        }

        // GET: SucursalPublicidad/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SucursalPublicidad sucursalPublicidad = db.SucursalPublicidad.Find(id);
            if (sucursalPublicidad == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPublicidad = new SelectList(db.Publicidad, "idPublicidad", "Tipo", sucursalPublicidad.idPublicidad);
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre", sucursalPublicidad.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", sucursalPublicidad.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", sucursalPublicidad.idUsuarioModifica);
            return View(sucursalPublicidad);
        }

        // POST: SucursalPublicidad/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idSucursalPublicidad,idSucursal,idPublicidad,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] SucursalPublicidad sucursalPublicidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sucursalPublicidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPublicidad = new SelectList(db.Publicidad, "idPublicidad", "Tipo", sucursalPublicidad.idPublicidad);
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre", sucursalPublicidad.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", sucursalPublicidad.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", sucursalPublicidad.idUsuarioModifica);
            return View(sucursalPublicidad);
        }

        // GET: SucursalPublicidad/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SucursalPublicidad sucursalPublicidad = db.SucursalPublicidad.Find(id);
            if (sucursalPublicidad == null)
            {
                return HttpNotFound();
            }
            return View(sucursalPublicidad);
        }

        // POST: SucursalPublicidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SucursalPublicidad sucursalPublicidad = db.SucursalPublicidad.Find(id);
            db.SucursalPublicidad.Remove(sucursalPublicidad);
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
