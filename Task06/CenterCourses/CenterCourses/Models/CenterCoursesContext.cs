using Microsoft.EntityFrameworkCore;

namespace CenterCourses.Models
{
    public class CenterCoursesContext : DbContext
    {
        public CenterCoursesContext(DbContextOptions<CenterCoursesContext> options) : base(options) { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CrsResult> CrsResults { get; set; }

        //connection string 
        //Data Source=.;Initial Catalog=Company_SD;Integrated Security=True;Encrypt=False
        public CenterCoursesContext():base()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Center_Courses;Integrated Security=True;Encrypt=False");
        }

        
    }
}
