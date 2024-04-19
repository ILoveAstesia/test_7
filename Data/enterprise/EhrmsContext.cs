using Microsoft.EntityFrameworkCore;
using ehrms.Model;
namespace ehrms.Data;

public class EhrmsContext : DbContext
{
    public EhrmsContext(DbContextOptions options) : base(options)
    {
        // if (Persons==null)
        // {
        // Console.WriteLine("EHRMContext when constroctor finishing Persons is null");
        // Environment.Exit(0);
        // }
        // if (Departments==null)
        // {
        // Console.WriteLine("EHRMContext when constroctor finishing Departments is null");
        // Environment.Exit(0);
        // }

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>()
        .HasMany(e => e.Employees)
        .WithOne(e => e.Department)        
        .HasForeignKey("deptId")
        .IsRequired();

        modelBuilder.Entity<Employee>()
        .HasMany(e => e.Payrolls)
        .WithOne(e => e.Employee)
        .HasForeignKey("empId")
        .IsRequired(false);

        // modelBuilder.Entity<Employee>()
        // .HasMany(e => e.Declarations)
        // ;
        // .WithOne(e => e.)

        // modelBuilder.Entity<Class>()
        // .HasMany(e => e.Teachers)
        // .WithMany(e => e.ClazzsNeedtoTeach);
            // 设置主键
        // modelBuilder.Entity<Department>().HasKey(s => s.Id);
        // // 建立主从关系
        // modelBuilder.Entity<Department>().OwnsMany(s => s.Employees);

        // modelBuilder.Entity<Employee>().HasKey(s => s.Id);
        // modelBuilder.Entity<Payroll>().HasKey(s => s.Id);
        // modelBuilder.Entity<Payroll>().
        // 建立主从关系
        // modelBuilder.Entity<Employee>().OwnsMany(s => s.);
        base.OnModelCreating(modelBuilder);

    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Recruitment> Recruitments { get; set; }
    public DbSet<Performance> Performances { get; set; }
    public DbSet<Payroll> Payrolls { get; set; }
    public DbSet<Training> Trainings { get; set; }
    public DbSet<Declaration> Declarations { get; set; }
    public DbSet<Document> Documents { get; set; }
    //public DbSet<DepartmentPerson> DepartmentPersons { get; set; }


}