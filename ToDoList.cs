using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoList
{
    public class ToDoList
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime? StartDate { get; set; }

        [Required]
        public DateTime? EndDate { get; set; }

        [Required]
        public bool? IsActive { get; set; }

        public bool? Star { get; set; }

    }
}
