using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Investrosite.Models.Database;
using System.Web.Security;


namespace Investrosite.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [HttpGet]
        public ActionResult Home()
        {
            investrositeEntities1 db = new investrositeEntities1();
            var data = db.Posts.ToList();
            return View(data);
        }

        [HttpGet]
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(Admin e)
        {
            investrositeEntities1 db = new investrositeEntities1();
            var data = (from n in db.Admins
                        where n.Password.Equals(e.Password) &&
                        e.Email.Equals(e.Email)
                        select n).FirstOrDefault();
            if (data != null)
            {
                Session["Name"] = data.Name.ToString();
                Session["Role"] = data.Role.ToString();
                Session["Id"] = data.Id.ToString();
                ViewBag.Msg = "Append";
                return RedirectToAction(actionName: "Home", controllerName: "Admin");
            }
            ViewBag.Msg = "Error";
            return View();
        }

        [HttpGet]
        public ActionResult Adminlist()
        {
            investrositeEntities1 db = new investrositeEntities1();
            var data = db.Admins.ToList();
            return View(data);
        }

        [HttpGet]
        public ActionResult Entrepreneurlist()
        {
            investrositeEntities1 db = new investrositeEntities1();
            var data = db.Entrepreneurs.ToList();
            return View(data);
        }

        [HttpGet]
        public ActionResult Managerlist()
        {
            investrositeEntities1 db = new investrositeEntities1();
            var data = db.Managers.ToList();
            return View(data);
        }

        [HttpGet]
        public ActionResult Investorlist()
        {
            investrositeEntities1 db = new investrositeEntities1();
            var data = db.Investors.ToList();
            return View(data);
        }

        [HttpGet]
        public ActionResult CreateManager()
        {
            return View(new Manager());
        }
        [HttpPost]
        public ActionResult CreateManager(Manager add)
        {

            if (ModelState.IsValid)
            {
                investrositeEntities1 db = new investrositeEntities1();
                db.Managers.Add(add);
                db.SaveChanges();
                ViewBag.Msg = "Added Successfully";
                return RedirectToAction(actionName: "Managerlist", controllerName: "Admin");
            }
            ViewBag.Msg = "Error";
            return View();
        }

        [HttpGet]
        public ActionResult CreateAdmin()
        {
            return View(new Admin());
        }
        [HttpPost]
        public ActionResult CreateAdmin(Admin add)
        {

            if (ModelState.IsValid)
            {
                investrositeEntities1 db = new investrositeEntities1();
                db.Admins.Add(add);
                db.SaveChanges();
                ViewBag.Msg = "Added Successfully";
                return RedirectToAction(actionName: "Adminlist", controllerName: "Admin");
            }
            ViewBag.Msg = "Error";
            return View();
        }

        [HttpGet]
        public ActionResult DeleteAdmin(int id)
        {
            if (ModelState.IsValid)
            {
                investrositeEntities1 db = new investrositeEntities1();
                var data = (from u in db.Admins
                            where u.Id == id
                            select u).FirstOrDefault();
                db.Admins.Remove(data);
                db.SaveChanges();
                return RedirectToAction(actionName: "Adminlist", controllerName: "Admin");
            }
            return View();
            
        }

        [HttpGet]
        public ActionResult DeleteManager(int id)
        {
            if (ModelState.IsValid)
            {
                investrositeEntities1 db = new investrositeEntities1();
                var data = (from u in db.Managers
                            where u.Id == id
                            select u).FirstOrDefault();
                db.Managers.Remove(data);
                db.SaveChanges();
                return RedirectToAction(actionName: "Managerlist", controllerName: "Admin");
            }
            return View();

        }

        [HttpGet]
        public ActionResult DeleteEntrepreneur(int id)
        {
            if (ModelState.IsValid)
            {
                investrositeEntities1 db = new investrositeEntities1();
                var data = (from u in db.Entrepreneurs
                            where u.Id == id
                            select u).FirstOrDefault();
                db.Entrepreneurs.Remove(data);
                db.SaveChanges();
                return RedirectToAction(actionName: "Entrepreneurlist", controllerName: "Admin");
            }
            return View();

        }


        [HttpGet]
        public ActionResult DeleteInvestor(int id)
        {
            if (ModelState.IsValid)
            {
                investrositeEntities1 db = new investrositeEntities1();
                var data = (from u in db.Investors
                            where u.Id == id
                            select u).FirstOrDefault();
                db.Investors.Remove(data);
                db.SaveChanges();
                return RedirectToAction(actionName: "Investorlist", controllerName: "Admin");
            }
            return View();

        }

    }
}