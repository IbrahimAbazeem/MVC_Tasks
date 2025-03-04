using CenterCourses.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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

            int totalCourses = query.Count();
            var courses = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalCourses / pageSize);
            ViewBag.SearchQuery = searchQuery;

            return View("Index", courses);
        }

        public IActionResult New()
        {
            ViewBag.Departments = context.Departments.ToList();
            return View("New");
        }

        [HttpPost]
        public IActionResult SaveNew(Course newCourse)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Departments = context.Departments.ToList();
                return View("New", newCourse);
            }

            context.Courses.Add(newCourse);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        // Remote validation for Unique Name
        public IActionResult IsNameUnique(string name)
        {
            bool exists = context.Courses.Any(c => c.Name == name);
            return Json(!exists);
        }

        // Remote validation for MinDegree < Degree
        public IActionResult ValidateMinDegree(int minDegree, double? degree)
        {
            if (degree.HasValue && minDegree >= degree)
            {
                return Json(false);
            }
            return Json(true);
        }

        // Remote validation for Hours / 3
        public IActionResult ValidateHours(int hours)
        {
            return Json(hours % 3 == 0);
        }

        //delete


        [HttpPost]
        public IActionResult DeleteConfirmed(int? id)
        {
            var course = context.Courses.Find(id);
            if (course == null)
            {
                return NotFound();
            }

            context.Courses.Remove(course);
            context.SaveChanges();

            TempData["SuccessMessage"] = "Course deleted successfully.";
            return RedirectToAction("Index");
        }




    }
}
