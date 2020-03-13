using System.ComponentModel.DataAnnotations;

namespace Bookish.Models.Request
{
    public class CreateMemberModel
    {
        [Required]
        [MinLength(1)]
        [MaxLength(128)]
        public string FirstName { get; set; }
        
        [Required]
        [MinLength(1)]
        [MaxLength(128)]
        public string LastName { get; set; }
    }
}