using System.ComponentModel.DataAnnotations;

namespace EduFlex.Models
{
    public class Notification
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Message Content is required")]
        public required string Message { get; set; }

        [Required]
        public int UserId { get; set; }
       // public AppUser User { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public bool IsRead { get; set; }
    }

}
