using System.ComponentModel.DataAnnotations;

namespace CenterCourses.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Manager { get; set; }
        public List<Instructor>? Instructors { get; set; } = new List<Instructor>();
        public List<Trainee>? Trainees { get; set; } = new List<Trainee> { };
    }
}
