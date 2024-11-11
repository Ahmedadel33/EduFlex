using System.ComponentModel.DataAnnotations;

namespace EduFlex.Models
{
    public class Parent
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

        [Required(ErrorMessage = "Phone Number is required")]
        [Phone]
        public required string PhoneNumber { get; set; }

        public required ICollection<Student> Children { get; set; }
    }


}
