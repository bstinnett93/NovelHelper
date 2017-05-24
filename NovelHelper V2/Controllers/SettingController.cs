using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NovelHelper_V2.Models;

namespace NovelHelper_V2.Controllers
{
    public class SettingController : Controller
    {
        private NovelDbContext db = new NovelDbContext();

        // GET: Setting
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var novel = db.Novels.Find(id);
            UpdateNovelDateAccessed(novel);
            var settings = new List<Setting>();
            if (novel.Settings.Count == 0)
            {
                settings.Add(new Setting
                {
                    NovelId = id.Value
                });
            }
            else
            {
                settings = novel.Settings.ToList();
            }

            return PartialView(settings);
        }

        // GET: Setting/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Setting setting = db.Settings.Find(id);
            return PartialView(setting);
        }

        // GET: Setting/Create
        public ActionResult Create(int id)
        {
            var setting = new Setting();
            setting.NovelId = id;
            return PartialView(setting);
        }

        // POST: Setting/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Setting setting)
        {
            if (ModelState.IsValid)
            {
                Novel novel = db.Novels.Find(setting.NovelId);
                setting.Novel = novel;
                db.Settings.Add(setting);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return PartialView(setting);
        }

        // GET: Setting/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Setting setting = db.Settings.Find(id);
            return PartialView(setting);
        }

        // POST: Setting/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Setting setting)
        {
            if (ModelState.IsValid)
            {
                var novel = db.Novels.Find(setting.NovelId);
                setting.Novel = novel;
                db.Entry(setting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return PartialView(setting);
        }

        // GET: Setting/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Setting setting = db.Settings.Find(id);
            return View(setting);
        }

        // POST: Setting/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Setting setting = db.Settings.Find(id);
            db.Settings.Remove(setting);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public void UpdateNovelDateAccessed(Novel novel)
        {
            novel.DateAccessed = DateTime.Now;
            db.Entry(novel).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
