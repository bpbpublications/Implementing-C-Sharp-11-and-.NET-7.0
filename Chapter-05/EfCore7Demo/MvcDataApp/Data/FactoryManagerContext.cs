using Microsoft.EntityFrameworkCore;
using MvcDataApp.Models;

namespace MvcDataApp.Data;

public class FactoryManagerContext : DbContext
{

    public FactoryManagerContext(DbContextOptions<FactoryManagerContext> options) : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Supervisor> Supervisors { get; set; }
    public DbSet<Factory> Factories { get; set; }
    public DbSet<Job> Jobs { get; set; }
    public DbSet<Shift> Shifts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.AddInterceptors(new EmployeeCachingInterceptor());

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().UseTpcMappingStrategy();
        modelBuilder.Entity<Employee>();
        modelBuilder.Entity<Supervisor>();
        modelBuilder.Entity<Factory>();
        modelBuilder.Entity<Job>();
        modelBuilder.Entity<Shift>();
    }
}
