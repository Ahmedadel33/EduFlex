using System.ComponentModel.DataAnnotations;

namespace EduFlex.Models
{
    public class Grade
    {
        public int Id { get; set; }

        [Required]
        public int StudentId { get; set; }
        public required Student Student { get; set; }

        [Required]
        public int CourseId { get; set; }
        public required Course Course { get; set; }

        [Required(ErrorMessage = "Grade is required")]
        [Range(0, 100, ErrorMessage = "Grade must be between 0 and 100")]
        public int Value { get; set; }

        [Required(ErrorMessage = "Grading Date is required")]
        [DataType(DataType.Date)]
        public DateTime GradingDate { get; set; }
    }


}
