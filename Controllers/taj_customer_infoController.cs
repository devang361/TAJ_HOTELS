using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TAJ_HOTELS.Models;

namespace TAJ_HOTELS.Controllers
{
    public class taj_customer_infoController : Controller
    {
        private hotel_tajEntities db = new hotel_tajEntities();

        // GET: taj_customer_info
        public ActionResult Index()
        {
            return View(db.taj_customer_info.ToList());
        }

        // GET: taj_customer_info/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            taj_customer_info taj_customer_info = db.taj_customer_info.Find(id);
            if (taj_customer_info == null)
            {
                return HttpNotFound();
            }
            return View(taj_customer_info);
        }

        // GET: taj_customer_info/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: taj_customer_info/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,NAME,EMAIL,RTYPE,STAY")] taj_customer_info taj_customer_info)
        {
            if (ModelState.IsValid)
            {
                db.taj_customer_info.Add(taj_customer_info);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(taj_customer_info);
        }

        // GET: taj_customer_info/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            taj_customer_info taj_customer_info = db.taj_customer_info.Find(id);
            if (taj_customer_info == null)
            {
                return HttpNotFound();
            }
            return View(taj_customer_info);
        }

        // POST: taj_customer_info/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,NAME,EMAIL,RTYPE,STAY")] taj_customer_info taj_customer_info)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taj_customer_info).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(taj_customer_info);
        }

        // GET: taj_customer_info/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            taj_customer_info taj_customer_info = db.taj_customer_info.Find(id);
            if (taj_customer_info == null)
            {
                return HttpNotFound();
            }
            return View(taj_customer_info);
        }

        // POST: taj_customer_info/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            taj_customer_info taj_customer_info = db.taj_customer_info.Find(id);
            db.taj_customer_info.Remove(taj_customer_info);
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
