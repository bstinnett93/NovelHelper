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
    public class CharacterController : Controller
    {
        private NovelDbContext db = new NovelDbContext();

        // GET: Character
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var novel = db.Novels.Find(id);
            UpdateNovelDateAccessed(novel);
            var characters = new List<Character>();

            if (novel.Characters.Count == 0)
            {
                characters.Add(new Character
                {
                    NovelId = id.Value
                });
            }
            else
            {
                characters = novel.Characters.ToList();
            }

            return PartialView(characters);
        }

        // GET: Character/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = db.Characters.Find(id);
            return PartialView(character);
        }

        // GET: Character/Create
        public ActionResult Create(int id)
        {
            Character character = new Character();
            character.NovelId = id;
            return PartialView(character);
        }

        // POST: Character/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Character character)
        {
            if (ModelState.IsValid)
            {
                Novel novel = db.Novels.Find(character.NovelId);
                character.Novel = novel;
                db.Characters.Add(character);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return PartialView(character);
        }

        // GET: Character/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = db.Characters.Find(id);
            return View(character);
        }

        // POST: Character/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CharacterId,Name,Description,NovelId")] Character character)
        {
            if (ModelState.IsValid)
            {
                var novel = db.Novels.Find(character.NovelId);
                character.Novel = novel;
                db.Entry(character).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(character);
        }

        // GET: Character/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = db.Characters.Find(id);
            return View(character);
        }

        // POST: Character/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Character character = db.Characters.Find(id);
            db.Characters.Remove(character);
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
