using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NovelHelper_V2.Models;
using NovelHelper_V2.Services;

namespace NovelHelper_V2.Controllers
{
    public class HomeController : Controller
    {
        // GET: LeftSidebar
        private NovelDbContext db = new NovelDbContext();

        private int _numCharacters;

        public HomeController()
        {
            _numCharacters = db.Characters.Count();
        }

        //GET Novels
        public ActionResult Index()
        {
            return View(db.Novels.ToList());
        }
        // GET: Novels/Create
        public ActionResult CreateNovel()
        {
            return PartialView();
        }
        // POST: Novels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNovel([Bind(Include = "NovelId,Title,Synopsis")] Novel novel)
        {
            if (ModelState.IsValid)
            {
                novel.DateAccessed = DateTime.Now;
                db.Novels.Add(novel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(novel);
        }

        //GET Settings
        public ActionResult Settings(int id)
        {
            var novel = db.Novels.Find(id);
            UpdateNovelDateAccessed(novel);
            var settings = new List<Setting>();
            if (novel.Settings.Count == 0)
            {
                settings.Add(new Setting
                {
                    NovelId = id
                });
            }
            else
            {
                settings = novel.Settings.ToList();
            }

            return PartialView(settings);
        }
        // GET: SettingDetail
        public ActionResult SettingDetail(int id)
        {
            var setting = db.Settings.Find(id);
            return PartialView(setting);
        }
        // GET: Settings/Create
        public ActionResult CreateSetting(int id)
        {
            var setting = new Setting();
            setting.NovelId = id;
            return PartialView(setting);
        }
        // POST: Settings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSetting(Setting setting)
        {
            Novel novel = db.Novels.Find(setting.NovelId);
            setting.Novel = novel;
            db.Settings.Add(setting);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        // GET: Settings/Edit
        public ActionResult EditSetting(int id)
        {
            Setting setting = db.Settings.Find(id);
            return View(setting);
        }
        // POST: Settings/Edit
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSetting(Setting setting)
        {
            var novel = db.Novels.Find(setting.NovelId);
            setting.Novel = novel;
            db.Entry(setting).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: Settings/Delete
        public ActionResult DeleteSetting(int id)
        {
            var setting = db.Settings.Find(id);
            return View(setting);
        }
        // POST: Settings/Delete
        public ActionResult DeleteSettingConfirmed(int id)
        {
            //db.delete setting from settings
            var setting = db.Settings.Find(id);
            db.Settings.Remove(setting);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET Characters
        public ActionResult Characters(int id)
        {
            var novel = db.Novels.Find(id);
            UpdateNovelDateAccessed(novel);
            var characters = new List<Character>();
            if (novel.Characters.Count == 0)
            {
                characters.Add(new Character
                {
                    NovelId = id
                });
            }
            else
            {
                characters = novel.Characters.ToList();
            }

            return PartialView(characters);
        }
        // GET: CharacterDetail
        public ActionResult CharacterDetail(int id)
        {
            var character = db.Characters.Find(id);
            return PartialView(character);
        }
        // GET: Characters/Create
        public ActionResult CreateCharacter(int id)
        {
            Character character = new Character();
            character.NovelId = id;
            return PartialView(character);
        }
        // POST: Characters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCharacter(Character character)
        {
            Novel novel = db.Novels.Find(character.NovelId);
            character.Novel = novel;
            db.Characters.Add(character);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        // GET: Character/Edit
        public ActionResult EditCharacter(int id)
        {
            Character character = db.Characters.Find(id);
            return View(character);
        }
        // POST: Character/Edit
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCharacter(Character character)
        {
            var novel = db.Novels.Find(character.NovelId);
            character.Novel = novel;
            db.Entry(character).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: Character/Delete
        public ActionResult DeleteCharacter(int id)
        {
            var character = db.Characters.Find(id);
            return View(character);
        }
        // POST: Settings/Delete
        public ActionResult DeleteCharacterConfirmed(int id)
        {
            //db.delete setting from settings
            var character = db.Characters.Find(id);
            db.Characters.Remove(character);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public void UpdateNovelDateAccessed(Novel novel)
        {
            novel.DateAccessed = DateTime.Now;
            db.Entry(novel).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}