using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BootstrapSiteLCD.Models;

namespace BootstrapSiteLCD.Controllers
{
    public class AddressesController : Controller
    {
        private ASPTutorialDBEntities db = new ASPTutorialDBEntities();

        [HttpPost]
        public ActionResult SaveData(Address address)
        {
            if (ModelState.IsValid)
            {
                if (address.Id > 0)
                {
                    db.Entry(address).State = EntityState.Modified;
                }
                else
                {
                    db.Addresses.Add(address);
                }
                db.SaveChanges();
            }
            return null;
        }

        [HttpPost]
        public ActionResult UpdateData(Address address)
        {
            if (ModelState.IsValid)
            {
                db.Entry(address).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(address);
        }

        [HttpPost]
        public ActionResult DeleteData(int? id)
        {
            if (id == -1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                db.Addresses.Remove(address);
                db.SaveChanges();
            }
            return null;
        }

        // GET: Addresses
        public ActionResult Index()
        {
            var addresses = db.Addresses.Include(a => a.City).Include(a => a.Student);
            return View(addresses.ToList());
        }

        public ActionResult _Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            var addresses = db.Addresses.Include(a => a.City).Include(a => a.Student).Where(a => a.StudentId.Equals(student.Id));
            ViewBag.StudId = student.Id;
            return View(addresses.ToList());
        }

        // GET: Addresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        public ActionResult _Details(int? id)
        {
            return Details(id);
        }

        // GET: Addresses/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name");
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Prename");
            return View();
        }

        public ActionResult _Create(int? id)
        {
            ViewBag.StudId = id;
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name");
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Prename");
            return View();
        }

        // POST: Addresses/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Street,Postcode,StreetNo,Appendix,StudentId,CityId")] Address address)
        {
            if (ModelState.IsValid)
            {
                db.Addresses.Add(address);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", address.CityId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Prename", address.StudentId);
            return View(address);
        }

        // GET: Addresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", address.CityId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Prename", address.StudentId);
            return View(address);
        }

        public ActionResult _Edit(int? id)
        {
            return Edit(id);
        }

        // POST: Addresses/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Street,Postcode,StreetNo,Appendix,StudentId,CityId")] Address address)
        {
            if (ModelState.IsValid)
            {
                db.Entry(address).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", address.CityId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Prename", address.StudentId);
            return View(address);
        }

        // GET: Addresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        public ActionResult _Delete(int? id)
        {
            return Delete(id);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Address address = db.Addresses.Find(id);
            db.Addresses.Remove(address);
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
