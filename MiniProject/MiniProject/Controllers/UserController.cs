using MiniProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniProject.Controllers
{
    public class UserController : Controller
    {
        public EcommerceEntities db = new EcommerceEntities();
        // GET: User
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }
        public ActionResult Register()
        {


            return View();
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {

                if (db.Users.Any(x => x.Email == user.Email))
                {
                    ViewBag.Message = "Email Already Registered";

                }
                else
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    ModelState.Clear();
                    ViewBag.Message = user.Name + " " + " successfully registered.";
                    return RedirectToAction("Login");
                }
               
            }
       return View(); 
        }


        public ActionResult Login()
        {


            return View();
        }
        [HttpPost]
        public ActionResult Login(User userProfile)
        {

            var user = db.Users.Single(c => c.Email == userProfile.Email && c.Password == userProfile.Password);
            if (user != null)
            {
               
                Session["ID"] = user.ID.ToString();
                Session["Name"] = user.Name.ToString();
                Session["Email"] = user.Email.ToString();
                Session["Image"] = user.PictureProfile ?? "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQqggCJZA4w1utXHToOl2Yun1rdOTQT88EXow&s";
                Session["IsLogin"] = true;

                return RedirectToAction("ProfileUser");
            }
            else { ModelState.AddModelError(" ", "Email or Password is wrong"); }
            return View("Login");

       
        }


        public ActionResult ProfileUser()
        {
            if (Session["ID"] != null)
            {
                //var userId = Convert.ToInt32(Session["ID"]);
                //var userProfile = Find(userId);
                return View();
            }
            else { return RedirectToAction("Login"); }
        }

        private object Find(int userId)
        {
            throw new NotImplementedException();
        }

        private object GetUserProfileById(int userId)
        {
            throw new NotImplementedException();
        }


        public ActionResult Logout()
        {
            // إزالة جميع القيم المخزنة في الـ Session
            Session.Clear();

            // إعادة التوجيه إلى الصفحة الرئيسية
            return RedirectToAction("Index", "Home");
        }




    }
}