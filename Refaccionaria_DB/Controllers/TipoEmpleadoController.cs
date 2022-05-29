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
    public class TipoEmpleadoController : Controller
    {
        private RefaccionariaEntities db = new RefaccionariaEntities();

        // GET: TipoEmpleado
        public ActionResult Index()
        {
            var tipoEmpleado = db.TipoEmpleado.Include(t => t.Empleado).Include(t => t.Usuario).Include(t => t.Usuario1);
            return View(tipoEmpleado.ToList());
        }

        // GET: TipoEmpleado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEmpleado tipoEmpleado = db.TipoEmpleado.Find(id);
            if (tipoEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(tipoEmpleado);
        }

        // GET: TipoEmpleado/Create
        public ActionResult Create()
        {
            ViewBag.idEmpleado = new SelectList(db.Empleado, "idEmpleado", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: TipoEmpleado/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipoEmpleado,nombre,idEmpleado,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] TipoEmpleado tipoEmpleado)
        {
            if (ModelState.IsValid)
            {
                db.TipoEmpleado.Add(tipoEmpleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEmpleado = new SelectList(db.Empleado, "idEmpleado", "nombre", tipoEmpleado.idEmpleado);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", tipoEmpleado.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", tipoEmpleado.idUsuarioModifica);
            return View(tipoEmpleado);
        }

        // GET: TipoEmpleado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEmpleado tipoEmpleado = db.TipoEmpleado.Find(id);
            if (tipoEmpleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEmpleado = new SelectList(db.Empleado, "idEmpleado", "nombre", tipoEmpleado.idEmpleado);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", tipoEmpleado.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", tipoEmpleado.idUsuarioModifica);
            return View(tipoEmpleado);
        }

        // POST: TipoEmpleado/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipoEmpleado,nombre,idEmpleado,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] TipoEmpleado tipoEmpleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoEmpleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEmpleado = new SelectList(db.Empleado, "idEmpleado", "nombre", tipoEmpleado.idEmpleado);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", tipoEmpleado.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", tipoEmpleado.idUsuarioModifica);
            return View(tipoEmpleado);
        }

        // GET: TipoEmpleado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEmpleado tipoEmpleado = db.TipoEmpleado.Find(id);
            if (tipoEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(tipoEmpleado);
        }

        // POST: TipoEmpleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoEmpleado tipoEmpleado = db.TipoEmpleado.Find(id);
            db.TipoEmpleado.Remove(tipoEmpleado);
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
