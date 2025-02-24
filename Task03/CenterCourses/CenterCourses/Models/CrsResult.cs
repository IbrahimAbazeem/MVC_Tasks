using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CenterCourses.Models
{
    public class CrsResult
    {
        [Key]
        public int Id { get; set; }
        public Double? Degree { get; set; }

        [ForeignKey("Course")]
        public int CrsId { get; set; }
        public Course? Course { get; set; }

        [ForeignKey("Trainee")]
        public int TraineeId { get; set; }
        public Trainee? Trainee { get; set; }
    }
}
