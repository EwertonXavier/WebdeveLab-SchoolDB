using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace testezim.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Season(int? id)
        {
            if(id == null)
            {
                ViewBag.id = "unknown";
                ViewBag.name = "unknown";
            }
            else
            {
                TeacherDataController teacherController = new TeacherDataController();
                ViewBag.id = id;
                ViewBag.message = teacherController.BasicInfo();
            }
            return View();
        }

    }
}
