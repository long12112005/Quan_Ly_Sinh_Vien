using Microsoft.EntityFrameworkCore;
using StudentClassApi.Models;
using System;


namespace StudentClassApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>().HasData(
                new Class { Id = 1, Name = "23CT111" },
                new Class { Id = 2, Name = "23CT111" }
            );

            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Name = "Nguyen Van A", DateOfBirth = new DateTime(2002, 5, 1), ClassId = 1 },
                new Student { Id = 2, Name = "Tran Thi B", DateOfBirth = new DateTime(2003, 8, 10), ClassId = 2 }
            );
        }
    }
}