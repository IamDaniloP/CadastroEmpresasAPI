using CadastrosEmpresas.API.Model.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CadastrosEmpresas.API.Persistence
{
    public class ConnectionContext : DbContext
    {
        public ConnectionContext(DbContextOptions<ConnectionContext> options) : base(options) { }

        public DbSet<Companies> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Model.Domain.Entities.Task> Tasks { get; set; }
        public DbSet<EmployeeTask> EmployeesTask { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Relacionamentos

            modelBuilder.Entity<Companies>()
                .HasMany(c => c.Employees)
                .WithOne(e => e.Companies)
                .HasForeignKey(e => e.CompaniesCNPJ);

            modelBuilder.Entity<Companies>()
                .HasMany(c => c.Departments)
                .WithOne(d => d.Companies)
                .HasForeignKey(d => d.CompaniesCNPJ);

            modelBuilder.Entity<Department>()
                .HasMany(d => d.Employees)
                .WithOne(e => e.Department)
                .HasForeignKey(e => e.DepartmentId);

            modelBuilder.Entity<Department>()
                .HasMany(d => d.Tasks)
                .WithOne(t => t.Department)
                .HasForeignKey(t => t.DepartmentId);

            modelBuilder.Entity<Department>()
                .HasIndex(d => d.HeadOfTheDepartment)
                .IsUnique();

            modelBuilder.Entity<Employee>()
                .HasIndex(e => new { e.CPF, e.Email, e.PhoneNumber})
                .IsUnique();

            modelBuilder.Entity<Model.Domain.Entities.Task>()
                .HasIndex(t => t.TaskName)
                .IsUnique();

            modelBuilder.Entity<EmployeeTask>()
            .HasKey(et => new { et.EmployeeId, et.TaskId });

            modelBuilder.Entity<EmployeeTask>()
                .HasOne(et => et.Employee)
                .WithMany(e => e.EmployeeTasks)
                .HasForeignKey(e => e.EmployeeId);

            modelBuilder.Entity<EmployeeTask>()
                .HasOne(et => et.Task)
                .WithMany(t => t.EmployeeTasks)
                .HasForeignKey(et => et.TaskId);
        }
    }
}
