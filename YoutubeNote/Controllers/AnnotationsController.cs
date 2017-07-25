using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using YoutubeNote.Models;

namespace YoutubeNote.Controllers
{
    public class AnnotationsController : Controller
    {
        private YoutubeNoteContext db = new YoutubeNoteContext();

        // GET: Annotations
        public ActionResult Index()
        {
            return View(db.Annotations.ToList());
        }

        // GET: Annotations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Annotations annotations = db.Annotations.Find(id);
            if (annotations == null)
            {
                return HttpNotFound();
            }
            return View(annotations);
        }

        // GET: Annotations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Annotations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,timestamp,message")] Annotations annotations)
        {
            if (ModelState.IsValid)
            {
                db.Annotations.Add(annotations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(annotations);
        }

        // GET: Annotations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Annotations annotations = db.Annotations.Find(id);
            if (annotations == null)
            {
                return HttpNotFound();
            }
            return View(annotations);
        }

        // POST: Annotations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,timestamp,message")] Annotations annotations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(annotations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(annotations);
        }

        // GET: Annotations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Annotations annotations = db.Annotations.Find(id);
            if (annotations == null)
            {
                return HttpNotFound();
            }
            return View(annotations);
        }

        // POST: Annotations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Annotations annotations = db.Annotations.Find(id);
            db.Annotations.Remove(annotations);
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
