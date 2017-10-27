using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hive2._0.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autherize(Hive2._0.Models.User userModel)
        {
            using (Models.Ingenious_BeeHiveEntities db =new Models.Ingenious_BeeHiveEntities())
            {
                var userDetails = db.Users.Where(x => x.UserName == userModel.UserName &&
                                                       x.Password == userModel.Password).FirstOrDefault(); //Validate Username & password

                if(userDetails==null)                   //Validate IF Username & password incorrect
                {
                    userModel.LoginErrorMessage = "Wrong UserName and Password";
                    return View("Index",userModel);
                }
                else
                {
                    Session["userID"] = userDetails.UserId;
                    Session["userName"] = userDetails.UserName;

                    return RedirectToAction("Index","Home");
                }

            }
               
        }

        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(Models.User obj)
        {
            if (ModelState.IsValid)
            {
                Models.Ingenious_BeeHiveEntities db = new Models.Ingenious_BeeHiveEntities();
                db.Users.Add(obj);
                db.SaveChanges();
            }
            return View(obj);
        }

        public ActionResult LogOut()
        {
            int userID = (int)Session["userID"];        //To show Active User
            Session.Abandon();
            return RedirectToAction("Index","Login");
        }
    }
}