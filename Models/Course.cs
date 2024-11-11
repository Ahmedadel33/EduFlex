using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace EduFlex.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Course Name is required")]
        [StringLength(100)]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Course Code is required")]
        [StringLength(10)]
        public required string Code { get; set; }

        [Required(ErrorMessage = "Credits are required")]
        [Range(1, 5, ErrorMessage = "Credits must be between 1 and 5")]
        public int Credits { get; set; }

        public int TeacherId { get; set; }
        public required Teacher Teacher { get; set; }

        public required ICollection<Student> Students { get; set; }
    }


}
