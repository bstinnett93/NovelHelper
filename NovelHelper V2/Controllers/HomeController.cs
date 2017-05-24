using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NovelHelper_V2.Models;

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
            return View();
        }
    }
}