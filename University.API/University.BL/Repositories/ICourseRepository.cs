using System.Threading.Tasks;
using University.BL.Models;
namespace University.BL.Repositories
{
    public interface ICourseRepository : IGenericRepository<Course>
    {

        //Metodo personalizado para eliminar entidad con sus FK 
        Task<bool> DeleteCheckOnEntity(int id);

    }
}
