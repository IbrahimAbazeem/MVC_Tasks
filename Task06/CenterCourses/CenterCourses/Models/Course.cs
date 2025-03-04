using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using CenterCourses.Validation;

namespace CenterCourses.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters.")]
        [MaxLength(20, ErrorMessage = "Name cannot be more than 20 characters.")]
        [UniqueName] //custom validation attribute
        [Remote("IsNameUnique", "Course", ErrorMessage = "Name must be unique.")]
        public string Name { get; set; }

        [Range(50, 100, ErrorMessage = "Degree must be between 50 and 100.")]
        public double? Degree { get; set; }

        [Remote("ValidateMinDegree", "Course", AdditionalFields = "Degree", ErrorMessage = "MinDegree must be less than Degree.")]
        public int? MinDegree { get; set; }

        [Remote("ValidateHours", "Course", ErrorMessage = "Hours must be a multiple of 3.")]
        public int? Hours { get; set; }

        [ForeignKey("Department")]
        public int DeptId { get; set; }
        public Department? Department { get; set; }
    }
}
