using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace EduFlex.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50)]
        public required string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50)]
        public required string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Enrollment Date is required")]
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }

        public required ICollection<Grade> Grades { get; set; }
        public required ICollection<Course> Courses { get; set; }
        public required ICollection<Attendance> Attendances { get; set; }
    }


}
