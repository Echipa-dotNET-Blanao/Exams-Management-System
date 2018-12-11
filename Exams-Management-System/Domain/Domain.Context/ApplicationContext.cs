using System;
using System.Collections.Generic;
using System.Text;
using Domain.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Domain.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Courses> Course { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
