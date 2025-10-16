using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Quan_Ly_Sinh_Vien.Models
{
    public class Class
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
