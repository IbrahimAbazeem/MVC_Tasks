using CenterCourses.Models;
using Microsoft.AspNetCore.Mvc;

namespace CenterCourses.Controllers
{
    public class CourseController : Controller
    {
        CenterCoursesContext context = new CenterCoursesContext();
        public IActionResult Index(string searchQuery = "", int page = 1)
        {
            int pageSize = 3;

            var query = context.Courses.AsQueryable();


            if (!string.IsNullOrEmpty(searchQuery))
            {
                query = query.Where(i => i.Name.Contains(searchQuery));
            }

            int totalCourses= query.Count();

            var courses = query.Skip((page - 1) * pageSize)
                                   .Take(pageSize)
                                   .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalCourses / pageSize);
            ViewBag.SearchQuery = searchQuery;

            return View("Index", courses);
        }

        #region new 
        public IActionResult New()
        {
            ViewBag.Departments = context.Departments.ToList();
            return View("New");
        }

        [HttpPost]
        public IActionResult SaveNew(Course newCourse)
        {
            if (!string.IsNullOrEmpty(newCourse.Name))
            {
                context.Courses.Add(newCourse);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Departments = context.Departments.ToList();
           
            return View("New", newCourse);
        }

        #endregion
    }
}
