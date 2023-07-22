using emplolist.Models;
using System.Linq;
using System.Web.Mvc;
using  static emplolist.Models.emplolistEntities;
using static emplolist.Models.user;
using static emplolist.Models.employee;
using System;

namespace emplolsit.Controllers
{
    public class loginController : Controller
    {
        emplolistEntities db = new emplolistEntities();
        // GET: login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index1()
        {
            return View();
        }
        public ActionResult Index2()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginViewModel1 login)
        {
            if (ModelState.IsValid)
            {
                var user = db.users.FirstOrDefault(u => u.username == login.Username && u.password == login.Password);
                
                if (user != null)
                {
                    Session["UserId"] = user.user_id.ToString();
                    Session["Username"] = user.username.ToString();
                    return RedirectToAction("Index1", "login");
                }
                var admin = db.admins.FirstOrDefault(a => a.username == login.Username && a.password == login.Password);
                if (admin != null)
                {
                    Session["UserId"] = admin.user_id.ToString();
                    Session["Username"] = admin.username.ToString();
                    return RedirectToAction("Index2", "Login");
                }
                else
                {
                    ModelState.AddModelError("", "The username or password is incorrect");
                }
            }

            return View(login);
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}
