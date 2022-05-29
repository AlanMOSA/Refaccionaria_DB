﻿using System;
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
    public class TipoAsentamientoController : Controller
    {
        private RefaccionariaEntities db = new RefaccionariaEntities();

        // GET: TipoAsentamiento
        public ActionResult Index()
        {
            var tipoAsentamiento = db.TipoAsentamiento.Include(t => t.Usuario).Include(t => t.Usuario1);
            return View(tipoAsentamiento.ToList());
        }

        // GET: TipoAsentamiento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAsentamiento tipoAsentamiento = db.TipoAsentamiento.Find(id);
            if (tipoAsentamiento == null)
            {
                return HttpNotFound();
            }
            return View(tipoAsentamiento);
        }

        // GET: TipoAsentamiento/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: TipoAsentamiento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipoAsentamiento,nombre,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] TipoAsentamiento tipoAsentamiento)
        {
            if (ModelState.IsValid)
            {
                db.TipoAsentamiento.Add(tipoAsentamiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", tipoAsentamiento.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", tipoAsentamiento.idUsuarioModifica);
            return View(tipoAsentamiento);
        }

        // GET: TipoAsentamiento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAsentamiento tipoAsentamiento = db.TipoAsentamiento.Find(id);
            if (tipoAsentamiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", tipoAsentamiento.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", tipoAsentamiento.idUsuarioModifica);
            return View(tipoAsentamiento);
        }

        // POST: TipoAsentamiento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipoAsentamiento,nombre,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] TipoAsentamiento tipoAsentamiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoAsentamiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", tipoAsentamiento.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", tipoAsentamiento.idUsuarioModifica);
            return View(tipoAsentamiento);
        }

        // GET: TipoAsentamiento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAsentamiento tipoAsentamiento = db.TipoAsentamiento.Find(id);
            if (tipoAsentamiento == null)
            {
                return HttpNotFound();
            }
            return View(tipoAsentamiento);
        }

        // POST: TipoAsentamiento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoAsentamiento tipoAsentamiento = db.TipoAsentamiento.Find(id);
            db.TipoAsentamiento.Remove(tipoAsentamiento);
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
