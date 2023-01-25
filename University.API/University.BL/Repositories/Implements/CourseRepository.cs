using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using University.BL.Data;
using University.BL.Models;

namespace University.BL.Repositories.Implements
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        private readonly UniversityContext universityContext;
        public CourseRepository(UniversityContext universityContext) :base(universityContext)
        {
            this.universityContext = universityContext;
        }

        public async Task<bool> DeleteCheckOnEntity(int id)
        {
            //Buscar que el curso no tenga dependencia
            var courseFind = await universityContext.Enrollments.AnyAsync(x => x.CourseID == id);
            return courseFind;
        }
    }
}
