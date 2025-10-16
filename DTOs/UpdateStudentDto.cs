using System;
using System.ComponentModel.DataAnnotations;
namespace Quan_Ly_Sinh_Vien.DTOs
{
    public class UpdateStudentDto
    {
        [Required]
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}