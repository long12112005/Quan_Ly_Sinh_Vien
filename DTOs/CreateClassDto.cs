using System.ComponentModel.DataAnnotations;
namespace Quan_Ly_Sinh_Vien.DTOs
{
    public class CreateClassDto
    {
        [Required]
        public string Name { get; set; }
    }
}