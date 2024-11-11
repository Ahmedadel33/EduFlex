using System.ComponentModel.DataAnnotations;

namespace EduFlex.Models
{
    public class Attendance
    {
        public int Id { get; set; }

        [Required]
        public int StudentId { get; set; }
        public required Student Student { get; set; }

        [Required]
        public int CourseId { get; set; }
        public required Course Course { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Attendance Status is required")]
        public bool IsPresent { get; set; }
    }


}
