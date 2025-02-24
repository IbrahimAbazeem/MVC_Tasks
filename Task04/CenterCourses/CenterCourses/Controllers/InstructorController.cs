using CenterCourses.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CenterCourses.Controllers
{
    public class InstructorController : Controller
    {
            CenterCoursesContext context = new CenterCoursesContext();
        //public IActionResult Index()
        //{
        //    List<Instructor> InstListModel = context.Instructors.ToList();
        //    return View("Index", InstListModel);
        //}
        //public IActionResult Index(int page = 1)
        //{
        //    int pageSize = 3; 
        //    int totalInstructors = context.Instructors.Count();

        //    var instructors = context.Instructors
        //                             .Skip((page - 1) * pageSize)
        //                             .Take(pageSize)
        //                             .ToList();

        //    ViewBag.CurrentPage = page;
        //    ViewBag.TotalPages = (int)Math.Ceiling((double)totalInstructors / pageSize);

        //    return View("Index", instructors);
        //}
        public IActionResult Index(string searchQuery = "", int page = 1)
        {
            int pageSize = 3;

            var query = context.Instructors.AsQueryable();

          
            if (!string.IsNullOrEmpty(searchQuery))
            {
                query = query.Where(i => i.Name.Contains(searchQuery));
            }

            int totalInstructors = query.Count();

            var instructors = query.Skip((page - 1) * pageSize)
                                   .Take(pageSize)
                                   .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalInstructors / pageSize);
            ViewBag.SearchQuery = searchQuery; 

            return View("Index", instructors);
        }

        public IActionResult Details(int id)
        {
            Instructor InstModel = context.Instructors.FirstOrDefault(e => e.Id == id);
            return View("Details", InstModel); 
        }
        #region New Instructor Actions

        //public IActionResult New()
        //{
        //    ViewBag.Departments = context.Departments.ToList();
        //    ViewBag.Courses = context.Courses.ToList();
        //    return View("New");
        //}

        public IActionResult New()
        {
            ViewBag.Departments = context.Departments.ToList();
            ViewBag.Courses = context.Courses.ToList();

            
            string imagesPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
            List<string> imageFiles = Directory.GetFiles(imagesPath)
                                               .Select(Path.GetFileName)
                                               .ToList();

            ViewBag.Images = imageFiles;

            return View("New");
        }


        [HttpPost]
        //public IActionResult SaveNew(Instructor newInstructor)
        //{
        //    if (!string.IsNullOrEmpty(newInstructor.Name))
        //    {
        //        context.Instructors.Add(newInstructor);
        //        context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }          
        //    ViewBag.Departments = context.Departments.ToList();
        //    ViewBag.Courses = context.Courses.ToList();
        //    return View("New", newInstructor);
        //}
        [HttpPost]
        public IActionResult SaveNew(Instructor newInstructor)
        {
            if (!string.IsNullOrEmpty(newInstructor.Name))
            {
                context.Instructors.Add(newInstructor);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            
            ViewBag.Departments = context.Departments.ToList();
            ViewBag.Courses = context.Courses.ToList();

            string imagesPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
            ViewBag.Images = Directory.GetFiles(imagesPath).Select(Path.GetFileName).ToList();

            return View("New", newInstructor);
        }


        #endregion

    }
}
