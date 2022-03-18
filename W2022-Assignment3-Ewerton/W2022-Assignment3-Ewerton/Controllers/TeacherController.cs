using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using W2022_Assignment3_Ewerton.Models;
namespace W2022_Assignment3_Ewerton.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Serves the Teacher/List view
        /// </summary>
        /// <returns>List.cshtml</returns>
        public ActionResult List()
        {
            //instantiate a controller and calls list API method
            List<Teacher> teachers= new TeacherDataController().List();

            return View(teachers);
        }


        //PS:From my research, we should use id instead of author id due to routeConfig.cs.
        //   But for me is a little strange.
        [Route("Teacher/Show/{id}")]
        public ActionResult Show(int id)
        {
            //create controller
            TeacherDataController controller = new TeacherDataController();
            //use controller to access API
            Teacher teacherDetails = controller.Describe(id);
            //sends teacherDetails to the Show View
            return View(teacherDetails);
        }

    }
}