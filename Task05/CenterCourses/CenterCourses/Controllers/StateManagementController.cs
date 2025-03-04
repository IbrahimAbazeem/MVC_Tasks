using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CenterCourses.Controllers
{
    public class StateManagementController : Controller
    {
        #region Cookies

        public IActionResult SetCookie()
        {
            // Create a persistent cookie that expires in 1 day
            var cookieOptions = new CookieOptions { Expires = DateTimeOffset.Now.AddDays(1) };

            // Session Cookie (expires when the browser closes)
            HttpContext.Response.Cookies.Append("Name", "Ahmed");

            // Persistent Cookie (expires after a specific time)
            HttpContext.Response.Cookies.Append("Color", "Red", cookieOptions);

            ViewBag.Message = "Cookies have been saved successfully.";
            return View();
        }

        public IActionResult GetCookie()
        {
            // Retrieve cookies from request
            string name = HttpContext.Request.Cookies["Name"];
            string color = HttpContext.Request.Cookies["Color"];

            ViewBag.CookieData = $"Name = {name}, Color = {color}";
            return View();
        }

        #endregion

        #region Session

        public IActionResult SetSession()
        {
            // Store session values
            HttpContext.Session.SetString("Name", "Ahmed");
            HttpContext.Session.SetInt32("Age", 20);

            return Content("Session data has been saved successfully.");
        }

        public IActionResult GetSession()
        {
            // Retrieve session values
            string name = HttpContext.Session.GetString("Name") ?? "Not Set";
            int? age = HttpContext.Session.GetInt32("Age");

            return Content($"Session Data: Name = {name}, Age = {age?.ToString() ?? "Not Set"}");
        }

        #endregion
    }
}
