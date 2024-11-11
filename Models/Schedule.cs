using System.ComponentModel.DataAnnotations;

namespace EduFlex.Models
{
    public class Schedule
    {
        public int Id { get; set; }

        [Required]
        public int CourseId { get; set; }
        public required Course Course { get; set; }

        [Required(ErrorMessage = "Date and Time are required")]
        public DateTime DateTime { get; set; }

        [Required(ErrorMessage = "Location is required")]
        [StringLength(100)]
        public required string Location { get; set; }
    }

}
