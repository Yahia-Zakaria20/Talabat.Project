using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Talabat.Rev.Dto
{
    public class AddressDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string Country { get; set; }

    }
}
