using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EduFlex.Models
{
    public class ApplicationUser : IdentityUser
    {

        [Required]
        public required string Name { get; set; }



        public string? StreetAddress { get; set; }
        public  string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
    }

}
