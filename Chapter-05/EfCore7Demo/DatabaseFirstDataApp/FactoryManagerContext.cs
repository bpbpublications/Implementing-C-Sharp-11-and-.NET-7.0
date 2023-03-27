using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DatabaseFirstDataApp
{
    public partial class FactoryManagerContext : DbContext
    {
        public FactoryManagerContext()
        {
        }

        public FactoryManagerContext(DbContextOptions<FactoryManagerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Factory> Factories { get; set; } = null!;
        public virtual DbSet<Job> Jobs { get; set; } = null!;
        public virtual DbSet<Shift> Shifts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=FactoryManager;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.JobId, "IX_Employees_JobId");

                entity.Property(e => e.FirstName).HasMaxLength(20);

                entity.Property(e => e.LastName).HasMaxLength(20);

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.JobId);
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.Property(e => e.Compensation).HasColumnType("decimal(8, 2)");
            });

            modelBuilder.Entity<Shift>(entity =>
            {
                entity.HasIndex(e => e.EmployeeId, "IX_Shifts_EmployeeId");

                entity.HasIndex(e => e.FactoryId, "IX_Shifts_FactoryId");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Shifts)
                    .HasForeignKey(d => d.EmployeeId);

                entity.HasOne(d => d.Factory)
                    .WithMany(p => p.Shifts)
                    .HasForeignKey(d => d.FactoryId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
