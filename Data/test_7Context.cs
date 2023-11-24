using Microsoft.EntityFrameworkCore;
using test_7.Model;
namespace test_7.Data;

public class test_7Context : DbContext
{
    public test_7Context(DbContextOptions options) : base(options)
    {
        if (Persons==null)
        {
        Console.WriteLine("EHRMContext when constroctor finishing Persons is null");
        Environment.Exit(0);
        }
        if (Departments==null)
        {
        Console.WriteLine("EHRMContext when constroctor finishing Departments is null");
        Environment.Exit(0);
        }

    }

    public DbSet<Person> Persons { get; set; }
    public DbSet<Department> Departments { get; set; }
    //public DbSet<DepartmentPerson> DepartmentPersons { get; set; }
    /**
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Department>().HasData(
            new {
                Id=0001,
                Name="Food", 
            },
                        new {
                Id=0002,
                Name="Drink", 
            }
        );
        modelBuilder.Entity<Person>().HasData(          
            new List<Person> {
                new(){                
                Id=0003,
                Name="Basic Cheese Pizza",
                },
                new(){    
                Id=0004,
                Name="Cola",
                }
            }
        );      
        
        modelBuilder.Entity<DepartmentPerson>().HasData(          
            new List<DepartmentPerson> {
                new(){   
                    Id=1,             
                PersonId=0001,
                DepartmentId=3,
                },
                new(){    
                    Id=2,
                PersonId=0002,
                DepartmentId=0004,
                }
            }
        );
            
    }
    **/
        
    public void GetPersonById(){
        
    }

}