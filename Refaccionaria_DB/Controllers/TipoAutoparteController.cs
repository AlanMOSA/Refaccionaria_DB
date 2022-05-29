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
    public class TipoAutoparteController : Controller
    {
        private RefaccionariaEntities db = new RefaccionariaEntities();

        // GET: TipoAutoparte
        public ActionResult Index()
        {
            var tipoAutoparte = db.TipoAutoparte.Include(t => t.Usuario).Include(t => t.Usuario1);
            return View(tipoAutoparte.ToList());
        }

        // GET: TipoAutoparte/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAutoparte tipoAutoparte = db.TipoAutoparte.Find(id);
            if (tipoAutoparte == null)
            {
                return HttpNotFound();
            }
            return View(tipoAutoparte);
        }

        // GET: TipoAutoparte/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: TipoAutoparte/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipoAutoparte,nombre,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] TipoAutoparte tipoAutoparte)
        {
            if (ModelState.IsValid)
            {
                db.TipoAutoparte.Add(tipoAutoparte);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", tipoAutoparte.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", tipoAutoparte.idUsuarioModifica);
            return View(tipoAutoparte);
        }

        // GET: TipoAutoparte/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAutoparte tipoAutoparte = db.TipoAutoparte.Find(id);
            if (tipoAutoparte == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", tipoAutoparte.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", tipoAutoparte.idUsuarioModifica);
            return View(tipoAutoparte);
        }

        // POST: TipoAutoparte/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipoAutoparte,nombre,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] TipoAutoparte tipoAutoparte)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoAutoparte).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", tipoAutoparte.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", tipoAutoparte.idUsuarioModifica);
            return View(tipoAutoparte);
        }

        // GET: TipoAutoparte/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAutoparte tipoAutoparte = db.TipoAutoparte.Find(id);
            if (tipoAutoparte == null)
            {
                return HttpNotFound();
            }
            return View(tipoAutoparte);
        }

        // POST: TipoAutoparte/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoAutoparte tipoAutoparte = db.TipoAutoparte.Find(id);
            db.TipoAutoparte.Remove(tipoAutoparte);
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
