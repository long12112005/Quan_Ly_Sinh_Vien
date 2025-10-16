using System;
using System.ComponentModel.DataAnnotations;
namespace StudentClassApi.Dtos
{
    public class UpdateStudentDto
    {
        [Required]
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}