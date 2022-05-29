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
    public class MoviliarioController : Controller
    {
        private RefaccionariaEntities db = new RefaccionariaEntities();

        // GET: Moviliario
        public ActionResult Index()
        {
            var moviliario = db.Moviliario.Include(m => m.Usuario).Include(m => m.Usuario1);
            return View(moviliario.ToList());
        }

        // GET: Moviliario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moviliario moviliario = db.Moviliario.Find(id);
            if (moviliario == null)
            {
                return HttpNotFound();
            }
            return View(moviliario);
        }

        // GET: Moviliario/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: Moviliario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMoviliario,nombre,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Moviliario moviliario)
        {
            if (ModelState.IsValid)
            {
                db.Moviliario.Add(moviliario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", moviliario.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", moviliario.idUsuarioModifica);
            return View(moviliario);
        }

        // GET: Moviliario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moviliario moviliario = db.Moviliario.Find(id);
            if (moviliario == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", moviliario.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", moviliario.idUsuarioModifica);
            return View(moviliario);
        }

        // POST: Moviliario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMoviliario,nombre,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Moviliario moviliario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moviliario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", moviliario.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", moviliario.idUsuarioModifica);
            return View(moviliario);
        }

        // GET: Moviliario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moviliario moviliario = db.Moviliario.Find(id);
            if (moviliario == null)
            {
                return HttpNotFound();
            }
            return View(moviliario);
        }

        // POST: Moviliario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Moviliario moviliario = db.Moviliario.Find(id);
            db.Moviliario.Remove(moviliario);
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
