using System.ComponentModel.DataAnnotations;

namespace GrepolisTools.Models
{
    public class UserDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public int RoleId { get; set; }

        [Required]
        public int AllianceId { get; set; }

        [Required]
        public int StateId { get; set; }
    }
}
