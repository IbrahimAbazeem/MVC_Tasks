using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CenterCourses.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double? Degree { get; set; }
        public int? MinDegree { get; set; }
        public int? Hours { get; set; }
        [ForeignKey("Department")]
        public int DeptId { get; set; }
        public Department? Department { get; set; }
       
    }
}
