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
    public class PREGUNTAsController : Controller
    {
        private DB_PROYECTOEntities db = new DB_PROYECTOEntities();

        // GET: PREGUNTAs
        public ActionResult Index()
        {
            var pREGUNTAS = db.PREGUNTAS.Include(p => p.ENCUESTA);
            return View(pREGUNTAS.ToList());
        }

        // GET: PREGUNTAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PREGUNTA pREGUNTA = db.PREGUNTAS.Find(id);
            if (pREGUNTA == null)
            {
                return HttpNotFound();
            }
            return View(pREGUNTA);
        }

        // GET: PREGUNTAs/Create
        public ActionResult Create()
        {
            ViewBag.IdEncuesta = new SelectList(db.ENCUESTAs, "IdEncuesta", "NombreEncuesta");
            return View();
        }

        // POST: PREGUNTAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPreguntas,IdEncuesta,pregunta1,pregunta2,pregunta3,pregunta4,pregunta5")] PREGUNTA pREGUNTA)
        {
            if (ModelState.IsValid)
            {
                db.PREGUNTAS.Add(pREGUNTA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEncuesta = new SelectList(db.ENCUESTAs, "IdEncuesta", "NombreEncuesta", pREGUNTA.IdEncuesta);
            return View(pREGUNTA);
        }

        // GET: PREGUNTAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PREGUNTA pREGUNTA = db.PREGUNTAS.Find(id);
            if (pREGUNTA == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEncuesta = new SelectList(db.ENCUESTAs, "IdEncuesta", "NombreEncuesta", pREGUNTA.IdEncuesta);
            return View(pREGUNTA);
        }

        // POST: PREGUNTAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPreguntas,IdEncuesta,pregunta1,pregunta2,pregunta3,pregunta4,pregunta5")] PREGUNTA pREGUNTA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pREGUNTA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEncuesta = new SelectList(db.ENCUESTAs, "IdEncuesta", "NombreEncuesta", pREGUNTA.IdEncuesta);
            return View(pREGUNTA);
        }

        // GET: PREGUNTAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PREGUNTA pREGUNTA = db.PREGUNTAS.Find(id);
            if (pREGUNTA == null)
            {
                return HttpNotFound();
            }
            return View(pREGUNTA);
        }

        // POST: PREGUNTAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PREGUNTA pREGUNTA = db.PREGUNTAS.Find(id);
            db.PREGUNTAS.Remove(pREGUNTA);
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
