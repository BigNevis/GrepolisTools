using System.ComponentModel.DataAnnotations;

namespace GrepolisTools.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

        public int AllianceId { get; set; }
        public Alliance Alliance { get; set; }

        public int StateId { get; set; }
        public State State { get; set; }
    }
}
