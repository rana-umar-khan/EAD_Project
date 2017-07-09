using AMS.DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EAD_Project.Controllers
{
    public class HomeController : Controller
    {
        HttpCookie cookie;
        public ActionResult Index()
        {
            if (Session["remember"] != null)
            {
                if ((string)Session["remember"] == "on")
                {
                    SignIn((string)Session["login"], (string)Session["password"], (string)Session["remember"]);
                    return Redirect("~/Teacher/Dashboard");
                }
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
       
        [HttpPost]
        public ActionResult SignIn(string email, string password, string remember)
        {
            if (cookie == null)
            {
                cookie = new HttpCookie("loginCookie", "Invalid");
            }
            Object data = null;
            TeacherDTO d = TeacherDAO.GetTeachherByUsername(email);
            if (d.TeaPassword == password)
            {
                data = new
                {
                    valid = true,
                    urlToRedirect = "/Teacher/Dashboard"
                };
                cookie.Value = "Valid";
                Session["Name"] = d.TeaFirstName + " " + d.TeaLastName;

                Session["login"] = email;
                Session["password"] = password;
                Session["remember"] = remember;
                cookie.Expires= DateTime.Now.AddHours(24);
            }
            else
            {
                Session["login"] = null;
                Session.Abandon();
                return null;
            }
            
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Logout()
        {
            Session["login"] = null;
            Session.Abandon();
            return Redirect("~/Home/Index");
        }
        
    }
}