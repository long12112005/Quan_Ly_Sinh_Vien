using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentClassApi.Models
{
    public class Class
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
