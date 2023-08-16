using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach_Ivan
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Matriculant> Matriculants { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Examinator> Examinators { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationContext()
        {
            /*Database.EnsureDeleted();*/
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=exams.db");
        }

    }
}
