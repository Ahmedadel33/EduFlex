using System.ComponentModel.DataAnnotations;

namespace EduFlex.Models
{
    public class Teacher
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

        [Required(ErrorMessage = "Hire Date is required")]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }

        public  string? SubjectSpecialization { get; set; }

        public  ICollection<Course>? Courses { get; set; }
    }


}
