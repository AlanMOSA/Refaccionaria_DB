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
    public class EquipoComputoController : Controller
    {
        private RefaccionariaEntities db = new RefaccionariaEntities();

        // GET: EquipoComputo
        public ActionResult Index()
        {
            var equipoComputo = db.EquipoComputo.Include(e => e.Usuario).Include(e => e.Usuario1);
            return View(equipoComputo.ToList());
        }

        // GET: EquipoComputo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoComputo equipoComputo = db.EquipoComputo.Find(id);
            if (equipoComputo == null)
            {
                return HttpNotFound();
            }
            return View(equipoComputo);
        }

        // GET: EquipoComputo/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: EquipoComputo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEquipoComputo,nombre,precio,marca,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] EquipoComputo equipoComputo)
        {
            if (ModelState.IsValid)
            {
                db.EquipoComputo.Add(equipoComputo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", equipoComputo.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", equipoComputo.idUsuarioModifica);
            return View(equipoComputo);
        }

        // GET: EquipoComputo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoComputo equipoComputo = db.EquipoComputo.Find(id);
            if (equipoComputo == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", equipoComputo.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", equipoComputo.idUsuarioModifica);
            return View(equipoComputo);
        }

        // POST: EquipoComputo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEquipoComputo,nombre,precio,marca,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] EquipoComputo equipoComputo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipoComputo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", equipoComputo.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", equipoComputo.idUsuarioModifica);
            return View(equipoComputo);
        }

        // GET: EquipoComputo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoComputo equipoComputo = db.EquipoComputo.Find(id);
            if (equipoComputo == null)
            {
                return HttpNotFound();
            }
            return View(equipoComputo);
        }

        // POST: EquipoComputo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EquipoComputo equipoComputo = db.EquipoComputo.Find(id);
            db.EquipoComputo.Remove(equipoComputo);
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
