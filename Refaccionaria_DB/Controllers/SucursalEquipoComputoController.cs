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
    public class SucursalEquipoComputoController : Controller
    {
        private RefaccionariaEntities db = new RefaccionariaEntities();

        // GET: SucursalEquipoComputo
        public ActionResult Index()
        {
            var sucursalEquipoComputo = db.SucursalEquipoComputo.Include(s => s.EquipoComputo).Include(s => s.Sucursal).Include(s => s.Usuario).Include(s => s.Usuario1);
            return View(sucursalEquipoComputo.ToList());
        }

        // GET: SucursalEquipoComputo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SucursalEquipoComputo sucursalEquipoComputo = db.SucursalEquipoComputo.Find(id);
            if (sucursalEquipoComputo == null)
            {
                return HttpNotFound();
            }
            return View(sucursalEquipoComputo);
        }

        // GET: SucursalEquipoComputo/Create
        public ActionResult Create()
        {
            ViewBag.idEquipoComputo = new SelectList(db.EquipoComputo, "idEquipoComputo", "nombre");
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: SucursalEquipoComputo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idSucursalEquipoComputo,idSucursal,idEquipoComputo,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] SucursalEquipoComputo sucursalEquipoComputo)
        {
            if (ModelState.IsValid)
            {
                db.SucursalEquipoComputo.Add(sucursalEquipoComputo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEquipoComputo = new SelectList(db.EquipoComputo, "idEquipoComputo", "nombre", sucursalEquipoComputo.idEquipoComputo);
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre", sucursalEquipoComputo.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", sucursalEquipoComputo.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", sucursalEquipoComputo.idUsuarioModifica);
            return View(sucursalEquipoComputo);
        }

        // GET: SucursalEquipoComputo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SucursalEquipoComputo sucursalEquipoComputo = db.SucursalEquipoComputo.Find(id);
            if (sucursalEquipoComputo == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEquipoComputo = new SelectList(db.EquipoComputo, "idEquipoComputo", "nombre", sucursalEquipoComputo.idEquipoComputo);
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre", sucursalEquipoComputo.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", sucursalEquipoComputo.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", sucursalEquipoComputo.idUsuarioModifica);
            return View(sucursalEquipoComputo);
        }

        // POST: SucursalEquipoComputo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idSucursalEquipoComputo,idSucursal,idEquipoComputo,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] SucursalEquipoComputo sucursalEquipoComputo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sucursalEquipoComputo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEquipoComputo = new SelectList(db.EquipoComputo, "idEquipoComputo", "nombre", sucursalEquipoComputo.idEquipoComputo);
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre", sucursalEquipoComputo.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", sucursalEquipoComputo.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", sucursalEquipoComputo.idUsuarioModifica);
            return View(sucursalEquipoComputo);
        }

        // GET: SucursalEquipoComputo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SucursalEquipoComputo sucursalEquipoComputo = db.SucursalEquipoComputo.Find(id);
            if (sucursalEquipoComputo == null)
            {
                return HttpNotFound();
            }
            return View(sucursalEquipoComputo);
        }

        // POST: SucursalEquipoComputo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SucursalEquipoComputo sucursalEquipoComputo = db.SucursalEquipoComputo.Find(id);
            db.SucursalEquipoComputo.Remove(sucursalEquipoComputo);
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
