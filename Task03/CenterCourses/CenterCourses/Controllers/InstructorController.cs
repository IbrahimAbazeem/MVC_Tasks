using CenterCourses.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CenterCourses.Controllers
{
    public class InstructorController : Controller
    {
            CenterCoursesContext context = new CenterCoursesContext();
        public IActionResult Index()
        {
            List<Instructor> InstListModel = context.Instructors.ToList();
            return View("Index", InstListModel);
        }
        public IActionResult Details(int id)
        {
            Instructor InstModel = context.Instructors.FirstOrDefault(e => e.Id == id);
            return View("Details", InstModel); 
        }
    }
}
