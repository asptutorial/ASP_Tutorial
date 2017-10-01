using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentWebApplication.Models;

namespace StudentWebApplication.Controllers
{
    public class CoursController : Controller
    {
        private DataConnection db = new DataConnection();

        // GET: Cours
        public async Task<ActionResult> Index()
        {
            return View(await db.Courses.ToListAsync());
        }

        // GET: Cours
        public ActionResult _PossibleCourses()
        {
            var student = db.Students.Where(x => x.AspNetUser.UserName.Equals(User.Identity.Name)).First();
            var studentCourses = student.StudentCourses.Select(x => x.CourseId);

            return PartialView(db.Courses.Where(x => !studentCourses.Contains(x.Id)).ToList());
        }

        // GET: Cours
        public ActionResult _SelectedCourses()
        {
            var student = db.Students.Where(x => x.AspNetUser.UserName.Equals(User.Identity.Name)).First();
            var studentCourses = student.StudentCourses.Select(x => x.CourseId);

            return PartialView(db.Courses.Where(x => studentCourses.Contains(x.Id)).ToList());
        }

        [HttpPost]
        public ActionResult Request(int id)
        {
            var student = db.Students.Where(x => x.AspNetUser.UserName.Equals(User.Identity.Name)).First();
            var studentCourse = new StudentCourse ()
            {
                CourseId = id,
                StudentId = student.Id,
                StatusCode = 0
            };
            db.StudentCourses.Add(studentCourse);
            db.SaveChanges();
            return null;
        }

        // GET: Cours/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cours cours = await db.Courses.FindAsync(id);
            if (cours == null)
            {
                return HttpNotFound();
            }
            return View(cours);
        }

        // GET: Cours/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cours/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Title,Description,MaxStudents,Id")] Cours cours)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(cours);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(cours);
        }

        // GET: Cours/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cours cours = await db.Courses.FindAsync(id);
            if (cours == null)
            {
                return HttpNotFound();
            }
            return View(cours);
        }

        // POST: Cours/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Title,Description,MaxStudents,Id")] Cours cours)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cours).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cours);
        }

        // GET: Cours/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cours cours = await db.Courses.FindAsync(id);
            if (cours == null)
            {
                return HttpNotFound();
            }
            return View(cours);
        }

        // POST: Cours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Cours cours = await db.Courses.FindAsync(id);
            db.Courses.Remove(cours);
            await db.SaveChangesAsync();
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
