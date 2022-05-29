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
    public class QuimicosSucursalController : Controller
    {
        private RefaccionariaEntities db = new RefaccionariaEntities();

        // GET: QuimicosSucursal
        public ActionResult Index()
        {
            var quimicosSucursal = db.QuimicosSucursal.Include(q => q.Quimicos).Include(q => q.Sucursal).Include(q => q.Usuario).Include(q => q.Usuario1);
            return View(quimicosSucursal.ToList());
        }

        // GET: QuimicosSucursal/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuimicosSucursal quimicosSucursal = db.QuimicosSucursal.Find(id);
            if (quimicosSucursal == null)
            {
                return HttpNotFound();
            }
            return View(quimicosSucursal);
        }

        // GET: QuimicosSucursal/Create
        public ActionResult Create()
        {
            ViewBag.idQuimicos = new SelectList(db.Quimicos, "idQuimicos", "descripcion");
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: QuimicosSucursal/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idQuimicosSucursal,idQuimicos,idSucursal,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] QuimicosSucursal quimicosSucursal)
        {
            if (ModelState.IsValid)
            {
                db.QuimicosSucursal.Add(quimicosSucursal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idQuimicos = new SelectList(db.Quimicos, "idQuimicos", "descripcion", quimicosSucursal.idQuimicos);
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre", quimicosSucursal.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", quimicosSucursal.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", quimicosSucursal.idUsuarioModifica);
            return View(quimicosSucursal);
        }

        // GET: QuimicosSucursal/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuimicosSucursal quimicosSucursal = db.QuimicosSucursal.Find(id);
            if (quimicosSucursal == null)
            {
                return HttpNotFound();
            }
            ViewBag.idQuimicos = new SelectList(db.Quimicos, "idQuimicos", "descripcion", quimicosSucursal.idQuimicos);
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre", quimicosSucursal.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", quimicosSucursal.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", quimicosSucursal.idUsuarioModifica);
            return View(quimicosSucursal);
        }

        // POST: QuimicosSucursal/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idQuimicosSucursal,idQuimicos,idSucursal,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] QuimicosSucursal quimicosSucursal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quimicosSucursal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idQuimicos = new SelectList(db.Quimicos, "idQuimicos", "descripcion", quimicosSucursal.idQuimicos);
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre", quimicosSucursal.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", quimicosSucursal.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", quimicosSucursal.idUsuarioModifica);
            return View(quimicosSucursal);
        }

        // GET: QuimicosSucursal/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuimicosSucursal quimicosSucursal = db.QuimicosSucursal.Find(id);
            if (quimicosSucursal == null)
            {
                return HttpNotFound();
            }
            return View(quimicosSucursal);
        }

        // POST: QuimicosSucursal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuimicosSucursal quimicosSucursal = db.QuimicosSucursal.Find(id);
            db.QuimicosSucursal.Remove(quimicosSucursal);
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
