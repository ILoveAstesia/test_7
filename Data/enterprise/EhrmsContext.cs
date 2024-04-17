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
        // modelBuilder.Entity<Class>()
        // .HasMany(e => e.Students)
        // .WithMany(e => e.ClazzsStudedIn);

        // modelBuilder.Entity<Class>()
        // .HasMany(e => e.Teachers)
        // .WithMany(e => e.ClazzsNeedtoTeach);

        base.OnModelCreating(modelBuilder);

    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Recruitment> Recruitments { get; set; }
    public DbSet<Payroll> Payrolls { get; set; }
    public DbSet<Trainning> Trainnings { get; set; }
    public DbSet<Declaration> Declarations { get; set; }
    //public DbSet<DepartmentPerson> DepartmentPersons { get; set; }


}