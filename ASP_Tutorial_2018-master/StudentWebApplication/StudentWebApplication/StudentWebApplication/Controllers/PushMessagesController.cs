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
    public class PushMessagesController : Controller
    {
        private DataConnection db = new DataConnection();

        // GET: PushMessages
        public async Task<ActionResult> Index()
        {
            return View(await db.PushMessages.OrderByDescending(x => x.ID).ToListAsync());
        }

        // GET: PushMessages REST
        public async Task<ActionResult> RestIndex()
        {
            return View();
        }


        // GET: PushMessages API
        public JsonResult RestMessages()
        {
            return Json(db.PushMessages.OrderByDescending(x => x.ID).ToListAsync(), JsonRequestBehavior.AllowGet);
        }

        
        // GET: Update PushMessages API
        public JsonResult RestUpdateMessages(int? lastID)
        {
            var result = from m in db.PushMessages
                         where m.ID > lastID
                         select m;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET: PushMessages/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PushMessage pushMessage = await db.PushMessages.FindAsync(id);
            if (pushMessage == null)
            {
                return HttpNotFound();
            }
            return View(pushMessage);
        }

        [Authorize(Roles = "pushMessage")]
        // GET: PushMessages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PushMessages/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Message,ID")] PushMessage pushMessage)
        {
            //if (ModelState.IsValid)
            //{
                db.PushMessages.Add(pushMessage);
                await db.SaveChangesAsync();
                return RedirectToAction("RestIndex");
            //}

            //return View(pushMessage);
        }

        [Authorize(Roles = "pushMessage")]
        // GET: PushMessages/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PushMessage pushMessage = await db.PushMessages.FindAsync(id);
            if (pushMessage == null)
            {
                return HttpNotFound();
            }
            return View(pushMessage);
        }

        // POST: PushMessages/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Message,ID")] PushMessage pushMessage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pushMessage).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(pushMessage);
        }

        [Authorize(Roles = "pushMessage")]
        // GET: PushMessages/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PushMessage pushMessage = await db.PushMessages.FindAsync(id);
            if (pushMessage == null)
            {
                return HttpNotFound();
            }
            return View(pushMessage);
        }

        // POST: PushMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PushMessage pushMessage = await db.PushMessages.FindAsync(id);
            db.PushMessages.Remove(pushMessage);
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
