
using System.ComponentModel.DataAnnotations;

namespace Core.Dtos
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
        public string ZipCode { get; set; }
    }
}