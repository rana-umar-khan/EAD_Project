using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FunnyVideos.Controllers
{
    public class SignInController : Controller
    {
        // GET: SignIn
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult admin(String mail, String password)
        {
            Object data = null;
            if (mail.Equals("sohailsultan145@gmail.com") && password.Equals("cheema145"))
            {
                data = new
                {
                    valid = true,
                    urlToRedirect = "/Home/adminPanel"
                };
            }
            else
                data = new
                {
                    valid = false
                };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult adminPanel()
        {
            return View();
        }
        public ActionResult addNewSong()
        {
            return View();
        }
        public void uploadSong()
        {
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];
                var path = Path.Combine(Server.MapPath("~/Poster"), file.FileName);
                file.SaveAs(path);
            }

        }
    }
}