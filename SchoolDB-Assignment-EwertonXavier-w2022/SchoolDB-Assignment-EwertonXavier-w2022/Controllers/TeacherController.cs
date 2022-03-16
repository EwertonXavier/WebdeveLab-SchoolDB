using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolDB_Assignment_EwertonXavier_w2022.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index(int? id)
        {
            TeacherDataController teacherDataController = new TeacherDataController();
            
            ViewBag.TeacherData = teacherDataController.ListTeacherClasses(id).ToArray(); ;
            return View();
        }
    }
}