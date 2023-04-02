using System.ComponentModel.DataAnnotations;
namespace StaffAPI.Models
{
    public class StaffModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "")]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
