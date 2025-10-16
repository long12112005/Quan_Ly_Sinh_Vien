using System;
using System.ComponentModel.DataAnnotations;

namespace Quan_Ly_Sinh_Vien.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
    }
}