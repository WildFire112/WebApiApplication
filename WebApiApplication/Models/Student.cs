using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiApplication.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Required]
        public int Group_id { get; set; }
    }
}
