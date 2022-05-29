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
    public class TipoAsentamientoZonaController : Controller
    {
        private RefaccionariaEntities db = new RefaccionariaEntities();

        // GET: TipoAsentamientoZona
        public ActionResult Index()
        {
            var tipoAsentamientoZona = db.TipoAsentamientoZona.Include(t => t.TipoAsentamiento).Include(t => t.Usuario).Include(t => t.Usuario1).Include(t => t.Zona);
            return View(tipoAsentamientoZona.ToList());
        }

        // GET: TipoAsentamientoZona/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAsentamientoZona tipoAsentamientoZona = db.TipoAsentamientoZona.Find(id);
            if (tipoAsentamientoZona == null)
            {
                return HttpNotFound();
            }
            return View(tipoAsentamientoZona);
        }

        // GET: TipoAsentamientoZona/Create
        public ActionResult Create()
        {
            ViewBag.idTipoAsentamiento = new SelectList(db.TipoAsentamiento, "idTipoAsentamiento", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idZona = new SelectList(db.Zona, "idZona", "nombre");
            return View();
        }

        // POST: TipoAsentamientoZona/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipoAsentamientoZona,idTipoAsentamiento,idZona,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] TipoAsentamientoZona tipoAsentamientoZona)
        {
            if (ModelState.IsValid)
            {
                db.TipoAsentamientoZona.Add(tipoAsentamientoZona);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idTipoAsentamiento = new SelectList(db.TipoAsentamiento, "idTipoAsentamiento", "nombre", tipoAsentamientoZona.idTipoAsentamiento);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", tipoAsentamientoZona.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", tipoAsentamientoZona.idUsuarioModifica);
            ViewBag.idZona = new SelectList(db.Zona, "idZona", "nombre", tipoAsentamientoZona.idZona);
            return View(tipoAsentamientoZona);
        }

        // GET: TipoAsentamientoZona/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAsentamientoZona tipoAsentamientoZona = db.TipoAsentamientoZona.Find(id);
            if (tipoAsentamientoZona == null)
            {
                return HttpNotFound();
            }
            ViewBag.idTipoAsentamiento = new SelectList(db.TipoAsentamiento, "idTipoAsentamiento", "nombre", tipoAsentamientoZona.idTipoAsentamiento);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", tipoAsentamientoZona.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", tipoAsentamientoZona.idUsuarioModifica);
            ViewBag.idZona = new SelectList(db.Zona, "idZona", "nombre", tipoAsentamientoZona.idZona);
            return View(tipoAsentamientoZona);
        }

        // POST: TipoAsentamientoZona/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipoAsentamientoZona,idTipoAsentamiento,idZona,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] TipoAsentamientoZona tipoAsentamientoZona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoAsentamientoZona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idTipoAsentamiento = new SelectList(db.TipoAsentamiento, "idTipoAsentamiento", "nombre", tipoAsentamientoZona.idTipoAsentamiento);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", tipoAsentamientoZona.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", tipoAsentamientoZona.idUsuarioModifica);
            ViewBag.idZona = new SelectList(db.Zona, "idZona", "nombre", tipoAsentamientoZona.idZona);
            return View(tipoAsentamientoZona);
        }

        // GET: TipoAsentamientoZona/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAsentamientoZona tipoAsentamientoZona = db.TipoAsentamientoZona.Find(id);
            if (tipoAsentamientoZona == null)
            {
                return HttpNotFound();
            }
            return View(tipoAsentamientoZona);
        }

        // POST: TipoAsentamientoZona/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoAsentamientoZona tipoAsentamientoZona = db.TipoAsentamientoZona.Find(id);
            db.TipoAsentamientoZona.Remove(tipoAsentamientoZona);
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
