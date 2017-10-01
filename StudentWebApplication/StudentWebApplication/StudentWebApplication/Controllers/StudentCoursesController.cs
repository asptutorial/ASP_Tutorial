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
    public class StudentCoursesController : Controller
    {
        private DataConnection db = new DataConnection();

        // GET: StudentCourses
        public async Task<ActionResult> Index()
        {
            var studentCourses = db.StudentCourses.Include(s => s.Cours).Include(s => s.Student);
            return View(await studentCourses.ToListAsync());
        }

        // GET: StudentCourses/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentCourse studentCourse = await db.StudentCourses.FindAsync(id);
            if (studentCourse == null)
            {
                return HttpNotFound();
            }
            return View(studentCourse);
        }

        // GET: StudentCourses/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Title");
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Forename");
            return View();
        }

        public ActionResult Answer(int StudentId, int CourseId, int StatusCode)
        {
            var studentCourse = db.StudentCourses.Where(x => x.StudentId == StudentId && x.CourseId == CourseId).First();
            studentCourse.StatusCode = StatusCode;

            db.Entry(studentCourse).State = EntityState.Modified;
            db.SaveChanges();

            return null;
        }

        // POST: StudentCourses/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "StudentId,CourseId,StatusCode")] StudentCourse studentCourse)
        {
            if (ModelState.IsValid)
            {
                db.StudentCourses.Add(studentCourse);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Title", studentCourse.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Forename", studentCourse.StudentId);
            return View(studentCourse);
        }

        // GET: StudentCourses/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentCourse studentCourse = await db.StudentCourses.FindAsync(id);
            if (studentCourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Title", studentCourse.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Forename", studentCourse.StudentId);
            return View(studentCourse);
        }

        // POST: StudentCourses/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "StudentId,CourseId,StatusCode")] StudentCourse studentCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentCourse).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Title", studentCourse.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Forename", studentCourse.StudentId);
            return View(studentCourse);
        }

        // GET: StudentCourses/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentCourse studentCourse = await db.StudentCourses.FindAsync(id);
            if (studentCourse == null)
            {
                return HttpNotFound();
            }
            return View(studentCourse);
        }

        // POST: StudentCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            StudentCourse studentCourse = await db.StudentCourses.FindAsync(id);
            db.StudentCourses.Remove(studentCourse);
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
