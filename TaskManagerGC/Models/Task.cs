using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManagerGC.Models
{
    public class Task : BaseModel   
    {
        public Task()
        {
            Completed = false;
        }

        [Required]
        [StringLength(100, ErrorMessage ="Title cannot be longer than 100 characters.")]
        [MinLength(3, ErrorMessage ="Title must be greater than or equal to 3 characters")]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool Completed { get; set; }
    }
}
