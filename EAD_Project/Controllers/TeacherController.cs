using AMS.DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EAD_Project.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Dashboard()
        {
            if (Session["login"] == null)
            {
                return Redirect("~/Home/Index");
            }
            List<CourseDTO> li = CourseDAO.GetCoursesByTeaId(1);
            ViewBag.courses = li;
            return View();
        }

        public ActionResult getCoursesByTchrID(int id)
        {
            if (Session["login"] == null)
            {
                return Redirect("~/Home/Index");
            }
            return View("CoursesView");
        }
    }
}