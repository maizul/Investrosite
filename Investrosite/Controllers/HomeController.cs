using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Investrosite.Models.Database;

namespace Investrosite.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Post post)
        {
            if (ModelState.IsValid)
            {
                investrositeEntities1 db = new investrositeEntities1();
                db.Posts.Add(post);
                db.SaveChanges();
                ViewBag.Msg = "Append";
                return View();
            }
            ViewBag.Msg = "Error";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}