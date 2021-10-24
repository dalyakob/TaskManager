using System.ComponentModel.DataAnnotations;

namespace TaskManagerGC.Models
{
    public class User : BaseModel  
    {
        [Required]
        [StringLength(50, ErrorMessage ="Username cannot be longer than 50 characters.")]
        public string Username { get; set; } 
        [Required]
        [StringLength(200)]
        [MinLength(1, ErrorMessage = "FullName must be greater than or equal to 1 character")]
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
