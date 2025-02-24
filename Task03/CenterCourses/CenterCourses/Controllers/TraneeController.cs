using CenterCourses.Models;
using CenterCourses.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CenterCourses.Controllers
{
    public class TraineeController : Controller
    {
       CenterCoursesContext _context = new CenterCoursesContext();

        public IActionResult Result(int tid, int cid)
        {
            var trainee = _context.Trainees.FirstOrDefault(t => t.Id == tid);
            var course = _context.Courses.FirstOrDefault(c => c.Id == cid);
            var traineeCourseDegree = _context.CrsResults
                .Where(cr => cr.CrsId == cid && cr.TraineeId == tid)
                .Select(cr => cr.Degree)
                .FirstOrDefault();

            if (trainee == null || course == null)
            {
                return NotFound("Trainee or Course not found");
            }

           
            double degree = traineeCourseDegree ?? 0;
            bool isPassed = degree >= course.MinDegree;

            var viewModel = new TraineeViewModel
            {
                TraineeName = trainee.Name,
                ImageURL = trainee.Image,
                CourseName = course.Name,
                TraineeDegree = degree,
                TraineeStatus = isPassed ? "Passed" : "Failed",
                Color = isPassed ? "green" : "red"
            };

            return View("Result", viewModel);
        }
        public IActionResult CResult(int cid)
        {

            var results = _context.CrsResults
                   .Where(r => r.CrsId == cid)
                   .Include(r => r.Trainee)
                   .Include(r => r.Course)
                   .Select(r => new CourseResults
                   {
                       TraineeName = r.Trainee.Name,
                       Degree = r.Degree,
                       MinDegree = r.Course.MinDegree
                   })
                   .ToList();

            return View("CResult", results);
        }
    }
}
