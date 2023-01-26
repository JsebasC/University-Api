using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using University.BL.Data;
using University.BL.DTOs;
using University.BL.Models;
using University.BL.Repositories.Implements;
using University.BL.Services.Implements;

namespace University.API.Controllers
{

    [Authorize] //debe tener la petición un token para poder consumir todos los metodos

    /// <summary>
    /// Controlador de Cursos
    /// </summary>
    [RoutePrefix("api/Courses")]
    public class CoursesController : ApiController
    {
        private IMapper mapper;
        private readonly CourseService courseService = new CourseService(new CourseRepository(UniversityContext.Create()));

        /// <summary>
        /// Constructor que inicializa el automapper
        /// </summary>
        public CoursesController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper(); // Maper de un DTO a un curso y un curso a DTO
        }


        /// <summary>
        /// Obtener todos los elementos del curso
        /// </summary>
        /// <returns>Listado,de los objetos de cursos</returns>
        /// <response code = "200">Devuelve el status code</response>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<CourseDTO>))]
        public async Task<IHttpActionResult> GetAll()
        {
            var courses = await courseService.GetAll();
            var coursesDTO = courses.Select(x => mapper.Map<CourseDTO>(x));
            return Ok(coursesDTO);
        }

        /// <summary>
        /// Obtener todos los elementos pero con una anotacion tipo Route
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllTemp")]        
        public async Task<IHttpActionResult> GetAllTemp()
        {
            var courses = await courseService.GetAll();
            var coursesDTO = courses.Select(x => mapper.Map<CourseDTO>(x));
            return Ok(coursesDTO);
        }

        /// <summary>
        /// Obtener elemento por id
        /// </summary>
        /// <remarks>Aqui una descripcion mas larga </remarks>
        /// <param name="id">Id del objeto</param>
        /// <returns>Objeto Course</returns>
        /// <response code = "200">Devuelve el objetos solicitado</response>
        /// <response code = "400">No se ha encontrado el objeto solicitado</response>
        [HttpGet]
        [ResponseType(typeof(CourseDTO))]
        //[Authorize]// autorizacion por metodo
        public async Task<IHttpActionResult> GetById(int id)
        {
            var courses = await courseService.GetById(id);
            if (courses == null)
                return NotFound();

            var coursesDTO = mapper.Map<CourseDTO>(courses);
            return Ok(coursesDTO);
        }

        /// <summary>
        /// Crear curso
        /// </summary>
        /// <param name="courseDTO">Recibe el objeto curso</param>
        /// <returns>Retorna el objeto guardado</returns>
        /// <response code = "400">Devuelve estado si es error el estado del modelo</response>
        /// <response code = "200">Devuelve el objeto guardado</response>
        /// <response code = "500">Devuelve el error del servidor</response>
        [HttpPost]
        [ResponseType(typeof(CourseDTO))]
        public async Task<IHttpActionResult> Post(CourseDTO courseDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var course = mapper.Map<Course>(courseDTO);
                course = await courseService.Insert(course);
                return Ok(course);
            }
            catch (Exception ex) { return InternalServerError(ex); }

        }

        /// <summary>
        /// Actualizar elemento
        /// </summary>
        /// <param name="courseDTO">Recibe la información</param>
        /// <param name="id">Recibe el id para buscar</param>
        /// <returns>Retorna el objeto modificado</returns>
        /// <response code = "400">Devuelve estado si es error el estado del modelo</response>
        /// <response code = "400">Devuelve estado si el id del objeto es diferente al que busca</response>
        /// <response code = "404">Devuelve el objeto no encontrado</response>
        /// <response code = "200">Devuelve el objeto se actualizo correctamente</response>
        /// <response code = "500">Devuelve el error del servidor</response>
        [HttpPut]
        [ResponseType(typeof(CourseDTO))]
        public async Task<IHttpActionResult> Put(CourseDTO courseDTO, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if ( courseDTO.CourseId != id)
                return BadRequest();

            var courseFind = await courseService.GetById(id);

            if (courseFind == null)
                return NotFound();

            try
            {
                var course = mapper.Map<Course>(courseDTO);
                course = await courseService.Update(course);
                return Ok(course);
            }
            catch (Exception ex) { return InternalServerError(ex); }
        }

        /// <summary>
        /// Eliminar elemento por id, verificando las FK
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]        
        public async Task<IHttpActionResult> Delete(int id)
        {
            var courseFind = await courseService.GetById(id);

            if (courseFind == null)
                return NotFound();

            try
            {
                if (!await courseService.DeleteCheckOnEntity(id))
                    await courseService.Delete(id);
                else
                    throw new Exception("ForeingKeys");

                return Ok();
            }
            catch (Exception ex){ return InternalServerError(ex); }
        }
    }
}