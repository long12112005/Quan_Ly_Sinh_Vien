using System;
using System.ComponentModel.DataAnnotations;
namespace Quan_Ly_Sinh_Vien.DTOs
{
    public class CreateStudentDto
    {
        [Required]
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        [Required]
        public int ClassId { get; set; }
    }
}