using AutoMapper;
using University.BL.Models;

namespace University.BL.DTOs
{
    public class MapperConfig
    {

        public static MapperConfiguration MapperConfiguration()
        {
            return new MapperConfiguration(cfg => {
                cfg.CreateMap<Course, CourseDTO>(); //GET  de curso a DTO, y de DTO a curso para exponer
                cfg.CreateMap<CourseDTO, Course>(); //POST-PUT y para recibir

                cfg.CreateMap<Student, StudentDTO>();
                cfg.CreateMap<StudentDTO, Student>();

                cfg.CreateMap<Enrollment, EnrollmentDTO>();
                cfg.CreateMap<EnrollmentDTO, Enrollment>();
            });
        }

    }
}
