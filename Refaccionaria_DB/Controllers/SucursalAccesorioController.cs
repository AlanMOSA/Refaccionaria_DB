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
    public class SucursalAccesorioController : Controller
    {
        private RefaccionariaEntities db = new RefaccionariaEntities();

        // GET: SucursalAccesorio
        public ActionResult Index()
        {
            var sucursalAccesorio = db.SucursalAccesorio.Include(s => s.Accesorio).Include(s => s.Sucursal).Include(s => s.Usuario).Include(s => s.Usuario1);
            return View(sucursalAccesorio.ToList());
        }

        // GET: SucursalAccesorio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SucursalAccesorio sucursalAccesorio = db.SucursalAccesorio.Find(id);
            if (sucursalAccesorio == null)
            {
                return HttpNotFound();
            }
            return View(sucursalAccesorio);
        }

        // GET: SucursalAccesorio/Create
        public ActionResult Create()
        {
            ViewBag.idAccesorio = new SelectList(db.Accesorio, "idAccesorio", "descripcion");
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: SucursalAccesorio/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idSucursalAccesorio,idSucursal,idAccesorio,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] SucursalAccesorio sucursalAccesorio)
        {
            if (ModelState.IsValid)
            {
                db.SucursalAccesorio.Add(sucursalAccesorio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idAccesorio = new SelectList(db.Accesorio, "idAccesorio", "descripcion", sucursalAccesorio.idAccesorio);
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre", sucursalAccesorio.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", sucursalAccesorio.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", sucursalAccesorio.idUsuarioModifica);
            return View(sucursalAccesorio);
        }

        // GET: SucursalAccesorio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SucursalAccesorio sucursalAccesorio = db.SucursalAccesorio.Find(id);
            if (sucursalAccesorio == null)
            {
                return HttpNotFound();
            }
            ViewBag.idAccesorio = new SelectList(db.Accesorio, "idAccesorio", "descripcion", sucursalAccesorio.idAccesorio);
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre", sucursalAccesorio.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", sucursalAccesorio.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", sucursalAccesorio.idUsuarioModifica);
            return View(sucursalAccesorio);
        }

        // POST: SucursalAccesorio/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idSucursalAccesorio,idSucursal,idAccesorio,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] SucursalAccesorio sucursalAccesorio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sucursalAccesorio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idAccesorio = new SelectList(db.Accesorio, "idAccesorio", "descripcion", sucursalAccesorio.idAccesorio);
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre", sucursalAccesorio.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", sucursalAccesorio.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", sucursalAccesorio.idUsuarioModifica);
            return View(sucursalAccesorio);
        }

        // GET: SucursalAccesorio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SucursalAccesorio sucursalAccesorio = db.SucursalAccesorio.Find(id);
            if (sucursalAccesorio == null)
            {
                return HttpNotFound();
            }
            return View(sucursalAccesorio);
        }

        // POST: SucursalAccesorio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SucursalAccesorio sucursalAccesorio = db.SucursalAccesorio.Find(id);
            db.SucursalAccesorio.Remove(sucursalAccesorio);
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
