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
    public class MunicipioController : Controller
    {
        private RefaccionariaEntities db = new RefaccionariaEntities();

        // GET: Municipio
        public ActionResult Index()
        {
            var municipio = db.Municipio.Include(m => m.Estado).Include(m => m.Usuario).Include(m => m.Usuario1);
            return View(municipio.ToList());
        }

        // GET: Municipio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Municipio municipio = db.Municipio.Find(id);
            if (municipio == null)
            {
                return HttpNotFound();
            }
            return View(municipio);
        }

        // GET: Municipio/Create
        public ActionResult Create()
        {
            ViewBag.idEstado = new SelectList(db.Estado, "idEstado", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: Municipio/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMunicipio,nombre,idEstado,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Municipio municipio)
        {
            if (ModelState.IsValid)
            {
                db.Municipio.Add(municipio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEstado = new SelectList(db.Estado, "idEstado", "nombre", municipio.idEstado);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", municipio.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", municipio.idUsuarioModifica);
            return View(municipio);
        }

        // GET: Municipio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Municipio municipio = db.Municipio.Find(id);
            if (municipio == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEstado = new SelectList(db.Estado, "idEstado", "nombre", municipio.idEstado);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", municipio.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", municipio.idUsuarioModifica);
            return View(municipio);
        }

        // POST: Municipio/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMunicipio,nombre,idEstado,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Municipio municipio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(municipio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEstado = new SelectList(db.Estado, "idEstado", "nombre", municipio.idEstado);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", municipio.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", municipio.idUsuarioModifica);
            return View(municipio);
        }

        // GET: Municipio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Municipio municipio = db.Municipio.Find(id);
            if (municipio == null)
            {
                return HttpNotFound();
            }
            return View(municipio);
        }

        // POST: Municipio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Municipio municipio = db.Municipio.Find(id);
            db.Municipio.Remove(municipio);
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
