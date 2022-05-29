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
    public class AutoParteController : Controller
    {
        private RefaccionariaEntities db = new RefaccionariaEntities();

        // GET: AutoParte
        public ActionResult Index()
        {
            var autoParte = db.AutoParte.Include(a => a.Marca).Include(a => a.TipoAutoparte).Include(a => a.Usuario).Include(a => a.Usuario1);
            return View(autoParte.ToList());
        }

        // GET: AutoParte/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutoParte autoParte = db.AutoParte.Find(id);
            if (autoParte == null)
            {
                return HttpNotFound();
            }
            return View(autoParte);
        }

        // GET: AutoParte/Create
        public ActionResult Create()
        {
            ViewBag.idMarca = new SelectList(db.Marca, "idMarca", "nombre");
            ViewBag.idTipoAutoparte = new SelectList(db.TipoAutoparte, "idTipoAutoparte", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: AutoParte/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idAutoParte,descripcion,precio,idMarca,idTipoAutoparte,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] AutoParte autoParte)
        {
            if (ModelState.IsValid)
            {
                db.AutoParte.Add(autoParte);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idMarca = new SelectList(db.Marca, "idMarca", "nombre", autoParte.idMarca);
            ViewBag.idTipoAutoparte = new SelectList(db.TipoAutoparte, "idTipoAutoparte", "nombre", autoParte.idTipoAutoparte);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", autoParte.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", autoParte.idUsuarioModifica);
            return View(autoParte);
        }

        // GET: AutoParte/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutoParte autoParte = db.AutoParte.Find(id);
            if (autoParte == null)
            {
                return HttpNotFound();
            }
            ViewBag.idMarca = new SelectList(db.Marca, "idMarca", "nombre", autoParte.idMarca);
            ViewBag.idTipoAutoparte = new SelectList(db.TipoAutoparte, "idTipoAutoparte", "nombre", autoParte.idTipoAutoparte);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", autoParte.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", autoParte.idUsuarioModifica);
            return View(autoParte);
        }

        // POST: AutoParte/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idAutoParte,descripcion,precio,idMarca,idTipoAutoparte,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] AutoParte autoParte)
        {
            if (ModelState.IsValid)
            {
                db.Entry(autoParte).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idMarca = new SelectList(db.Marca, "idMarca", "nombre", autoParte.idMarca);
            ViewBag.idTipoAutoparte = new SelectList(db.TipoAutoparte, "idTipoAutoparte", "nombre", autoParte.idTipoAutoparte);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", autoParte.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", autoParte.idUsuarioModifica);
            return View(autoParte);
        }

        // GET: AutoParte/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutoParte autoParte = db.AutoParte.Find(id);
            if (autoParte == null)
            {
                return HttpNotFound();
            }
            return View(autoParte);
        }

        // POST: AutoParte/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AutoParte autoParte = db.AutoParte.Find(id);
            db.AutoParte.Remove(autoParte);
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
