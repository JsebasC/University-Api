using System.Data.Entity;
using University.BL.Models;

namespace University.BL.Data
{
    public class UniversityContext : DbContext
    {
        //private static UniversityContext universityContext = null;
        public UniversityContext() : base("UniversityContext")
        {

        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        public static UniversityContext Create() //Patron singleton , unica instancia : Se instancia solo una vez y cada vez que lo necesite llama esa misma instancia
        {
            //if (universityContext == null)
            //    universityContext = new UniversityContext();
            
            return new UniversityContext(); ; 
        }
    }
}
