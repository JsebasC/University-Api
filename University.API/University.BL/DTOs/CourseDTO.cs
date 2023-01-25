using System.ComponentModel.DataAnnotations;

namespace University.BL.DTOs
{
    public class CourseDTO
    {
        [Required(ErrorMessage ="The field course ID is required")]
        public int CourseId { get; set; }
        [Required(ErrorMessage = "The field Title ID is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "The field Credits ID is required")]
        public int Credits { get; set; }
    }
}
