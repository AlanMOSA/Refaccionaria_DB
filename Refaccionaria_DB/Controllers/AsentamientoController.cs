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
    public class AsentamientoController : Controller
    {
        private RefaccionariaEntities db = new RefaccionariaEntities();

        // GET: Asentamiento
        public ActionResult Index()
        {
            var asentamiento = db.Asentamiento.Include(a => a.Municipio).Include(a => a.TipoAsentamiento).Include(a => a.Usuario).Include(a => a.Usuario1);
            return View(asentamiento.ToList());
        }

        // GET: Asentamiento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asentamiento asentamiento = db.Asentamiento.Find(id);
            if (asentamiento == null)
            {
                return HttpNotFound();
            }
            return View(asentamiento);
        }

        // GET: Asentamiento/Create
        public ActionResult Create()
        {
            ViewBag.idMunicipio = new SelectList(db.Municipio, "idMunicipio", "nombre");
            ViewBag.idTipoAsentamiento = new SelectList(db.TipoAsentamiento, "idTipoAsentamiento", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: Asentamiento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idAsentamiento,nombre,codigoPostal,idMunicipio,idTipoAsentamiento,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Asentamiento asentamiento)
        {
            if (ModelState.IsValid)
            {
                db.Asentamiento.Add(asentamiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idMunicipio = new SelectList(db.Municipio, "idMunicipio", "nombre", asentamiento.idMunicipio);
            ViewBag.idTipoAsentamiento = new SelectList(db.TipoAsentamiento, "idTipoAsentamiento", "nombre", asentamiento.idTipoAsentamiento);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", asentamiento.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", asentamiento.idUsuarioModifica);
            return View(asentamiento);
        }

        // GET: Asentamiento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asentamiento asentamiento = db.Asentamiento.Find(id);
            if (asentamiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.idMunicipio = new SelectList(db.Municipio, "idMunicipio", "nombre", asentamiento.idMunicipio);
            ViewBag.idTipoAsentamiento = new SelectList(db.TipoAsentamiento, "idTipoAsentamiento", "nombre", asentamiento.idTipoAsentamiento);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", asentamiento.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", asentamiento.idUsuarioModifica);
            return View(asentamiento);
        }

        // POST: Asentamiento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idAsentamiento,nombre,codigoPostal,idMunicipio,idTipoAsentamiento,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Asentamiento asentamiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asentamiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idMunicipio = new SelectList(db.Municipio, "idMunicipio", "nombre", asentamiento.idMunicipio);
            ViewBag.idTipoAsentamiento = new SelectList(db.TipoAsentamiento, "idTipoAsentamiento", "nombre", asentamiento.idTipoAsentamiento);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", asentamiento.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", asentamiento.idUsuarioModifica);
            return View(asentamiento);
        }

        // GET: Asentamiento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asentamiento asentamiento = db.Asentamiento.Find(id);
            if (asentamiento == null)
            {
                return HttpNotFound();
            }
            return View(asentamiento);
        }

        // POST: Asentamiento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asentamiento asentamiento = db.Asentamiento.Find(id);
            db.Asentamiento.Remove(asentamiento);
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
