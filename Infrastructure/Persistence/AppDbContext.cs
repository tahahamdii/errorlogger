using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Error> Errors { get; set; }
        public DbSet<Employe> Employees { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Error>()
                .HasOne(e => e.AssignedEmployee)
                .WithMany(emp => emp.AssignedErrors)
                .HasForeignKey(e => e.AssignedEmployeeId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
