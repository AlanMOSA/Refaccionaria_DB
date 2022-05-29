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
    public class FormaPagoController : Controller
    {
        private RefaccionariaEntities db = new RefaccionariaEntities();

        // GET: FormaPago
        public ActionResult Index()
        {
            var formaPago = db.FormaPago.Include(f => f.Usuario).Include(f => f.Usuario1);
            return View(formaPago.ToList());
        }

        // GET: FormaPago/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormaPago formaPago = db.FormaPago.Find(id);
            if (formaPago == null)
            {
                return HttpNotFound();
            }
            return View(formaPago);
        }

        // GET: FormaPago/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: FormaPago/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idFormaPago,nombre,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] FormaPago formaPago)
        {
            if (ModelState.IsValid)
            {
                db.FormaPago.Add(formaPago);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", formaPago.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", formaPago.idUsuarioModifica);
            return View(formaPago);
        }

        // GET: FormaPago/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormaPago formaPago = db.FormaPago.Find(id);
            if (formaPago == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", formaPago.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", formaPago.idUsuarioModifica);
            return View(formaPago);
        }

        // POST: FormaPago/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idFormaPago,nombre,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] FormaPago formaPago)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formaPago).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", formaPago.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", formaPago.idUsuarioModifica);
            return View(formaPago);
        }

        // GET: FormaPago/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormaPago formaPago = db.FormaPago.Find(id);
            if (formaPago == null)
            {
                return HttpNotFound();
            }
            return View(formaPago);
        }

        // POST: FormaPago/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FormaPago formaPago = db.FormaPago.Find(id);
            db.FormaPago.Remove(formaPago);
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
