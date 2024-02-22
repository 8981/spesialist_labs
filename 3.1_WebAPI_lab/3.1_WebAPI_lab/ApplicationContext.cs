using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._1_WebAPI_lab
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<Teacher> Teachers { get; set; } = null!;
        public DbSet<Student> Students { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Course>().HasData(
                new Course() { Id = 1, Title = "Programming", Duration = 40, Description = "Study C#" },
                new Course() { Id = 2, Title = "Language", Duration = 20, Description = "Study English" },
                new Course() { Id = 3, Title = "Administration", Duration = 30, Description = "Study administration" }
                );

            modelBuilder.Entity<Teacher>().HasData(
                new Teacher() {Id = 1, Name = "Sergey" },
                new Teacher() {Id = 2, Name = "Anton" },
                new Teacher() {Id = 3, Name = "Roman" }
                );

            modelBuilder.Entity<Student>().HasData(
                new Student() { Id = 1, Name = "Genadiy", Age = 22 },
                new Student() { Id = 2, Name = "Anna", Age = 30 },
                new Student() { Id = 3, Name = "Lana", Age = 25 },
                new Student() { Id = 4, Name = "Artur", Age = 28 }
                );
        }
    }
}
