using System.ComponentModel.DataAnnotations;

namespace CenterCourses.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Degree { get; set; }
        public int? MinDegree { get; set; }
        public int? Hours { get; set; } 
        public List<Instructor>? Instructors { get; set; } = new List<Instructor>();
        public List<CrsResult>? CrsResult { get; set; } = new List<CrsResult>();
    }
}
