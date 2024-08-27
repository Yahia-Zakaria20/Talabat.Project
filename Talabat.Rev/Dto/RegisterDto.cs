using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Talabat.Rev.Dto
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string phonenumber { get; set; }
        [Required]
        public  string Displayname { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
