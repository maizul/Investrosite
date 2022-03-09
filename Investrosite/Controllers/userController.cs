using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Investrosite.Models.Database;
using System.Web.Security;

namespace Investrosite.Controllers
{
    public class userController : Controller
    {
        // GET: register
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Entrepreneur e)
        {
            if (ModelState.IsValid)
            {
                investrositeEntities1 db = new investrositeEntities1();
                db.Entrepreneurs.Add(e);
                db.SaveChanges();
                ViewBag.Msg = "Append";
                return RedirectToAction(actionName: "Index", controllerName: "Home");
            }
            ViewBag.Msg = "Error";
            return View();
        }
        [HttpGet]
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(Entrepreneur e)
        {
            investrositeEntities1 db = new investrositeEntities1();
            var data = (from n in db.Entrepreneurs
                        where n.Password.Equals(e.Password) &&
                        e.Email.Equals(e.Email)
                        select n).FirstOrDefault();
            if(data != null)
            {
                ViewBag.Msg = "Append";
                return RedirectToAction(actionName: "Index", controllerName: "Home"); 
            }
            ViewBag.Msg = "Error";
            return View();
        }
    }
}