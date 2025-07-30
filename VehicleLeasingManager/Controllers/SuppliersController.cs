using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using VehicleLeasingManager.Models;

namespace VehicleLeasingManager.Controllers
{
    public class SuppliersController : Controller
    {
        private VehicleLeasingContext db = new VehicleLeasingContext();

        // GET: Supplier
        public ActionResult Index()
        {
            return View(db.Suppliers.ToList());
        }

        // GET: Supplier/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // GET: Supplier/Create
        public ActionResult Create()
        {
            return View(new Supplier());
        }

        // POST: Supplier/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SupplierId,SupplierName,ContactInfo")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                supplier.SupplierId = Guid.NewGuid();
                db.Suppliers.Add(supplier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(supplier);
        }

        // GET: Supplier/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Supplier/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SupplierId,SupplierName,ContactInfo")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supplier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supplier);
        }

        // GET: Supplier/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Supplier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Supplier supplier = db.Suppliers.Find(id);
            db.Suppliers.Remove(supplier);
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
