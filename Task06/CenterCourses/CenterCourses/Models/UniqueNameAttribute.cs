using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;
using CenterCourses.Models;
using System.Linq;

namespace CenterCourses.Validation
{
    public class UniqueNameAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Name is required.");
            }

            // Get the database context from the service provider
            var context = validationContext.GetService(typeof(CenterCoursesContext)) as CenterCoursesContext;

            if (context == null)
            {
                return new ValidationResult("Database context error.");
            }

            string name = value.ToString();
            bool exists = context.Courses.Any(c => c.Name == name);

            return exists ? new ValidationResult("Name must be unique.") : ValidationResult.Success;
        }
    }
}
