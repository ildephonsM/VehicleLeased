using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using VehicleLeasingManager.Models;

namespace VehicleLeasingManager.Controllers
{
    public class ClientsController : Controller
    {
        private VehicleLeasingContext db = new VehicleLeasingContext();

        // GET: Clients
        public ActionResult Index()
        {
            return View(db.Clients.ToList());
        }

        // GET: Clients/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            return View(new Client());
        }

        // POST: Clients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientId,CompanyName,ContactDetails")] Client client)
        {
            if (ModelState.IsValid)
            {
                client.ClientId = Guid.NewGuid();
                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(client);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientId,CompanyName,ContactDetails")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
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
