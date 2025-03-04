using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace CenterCourses.Controllers
{
    public class ImageController : Controller
    {
        private readonly string _uploadPath = "wwwroot/images";

        public IActionResult Index()
        {
           
            var imageFiles = Directory.GetFiles(_uploadPath)
                                      .Select(Path.GetFileName)
                                      .ToList();

            return View(imageFiles);
        }

        [HttpPost]
        public IActionResult Upload(IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                string filePath = Path.Combine(_uploadPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }
            }

            return RedirectToAction("Index");
        }
    }
}
