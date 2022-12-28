using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoDevSystem.Models;

namespace ProyectoDevSystem.Controllers
{
    public class ENCUESTAsController : Controller
    {
        private DB_PROYECTOEntities db = new DB_PROYECTOEntities();

        // GET: ENCUESTAs
        public ActionResult Index()
        {
            var eNCUESTAs = db.ENCUESTAs.Include(e => e.USUARIO);
            return View(eNCUESTAs.ToList());
        }

        // GET: ENCUESTAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ENCUESTA eNCUESTA = db.ENCUESTAs.Find(id);
            if (eNCUESTA == null)
            {
                return HttpNotFound();
            }
            return View(eNCUESTA);
        }

        // GET: ENCUESTAs/Create
        public ActionResult Create()
        {
            ViewBag.IdUsuario = new SelectList(db.USUARIOs, "IdUsuario", "Correo");
            return View();
        }

        // POST: ENCUESTAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEncuesta,IdUsuario,NombreEncuesta,TituloEncuesta,DescripcionEncuesta")] ENCUESTA eNCUESTA)
        {
            if (ModelState.IsValid)
            {
                db.ENCUESTAs.Add(eNCUESTA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdUsuario = new SelectList(db.USUARIOs, "IdUsuario", "Correo", eNCUESTA.IdUsuario);
            return View(eNCUESTA);
        }

        // GET: ENCUESTAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ENCUESTA eNCUESTA = db.ENCUESTAs.Find(id);
            if (eNCUESTA == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdUsuario = new SelectList(db.USUARIOs, "IdUsuario", "Correo", eNCUESTA.IdUsuario);
            return View(eNCUESTA);
        }

        // POST: ENCUESTAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEncuesta,IdUsuario,NombreEncuesta,TituloEncuesta,DescripcionEncuesta")] ENCUESTA eNCUESTA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eNCUESTA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdUsuario = new SelectList(db.USUARIOs, "IdUsuario", "Correo", eNCUESTA.IdUsuario);
            return View(eNCUESTA);
        }

        // GET: ENCUESTAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ENCUESTA eNCUESTA = db.ENCUESTAs.Find(id);
            if (eNCUESTA == null)
            {
                return HttpNotFound();
            }
            return View(eNCUESTA);
        }

        // POST: ENCUESTAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ENCUESTA eNCUESTA = db.ENCUESTAs.Find(id);
            db.ENCUESTAs.Remove(eNCUESTA);
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
