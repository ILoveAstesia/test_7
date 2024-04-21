using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using test_7.Data;
using ehrms.Model;

namespace ehrms.Data;

[Route("DAOs/Employees")]
[ApiController]
public class EmployeeDAO {
    readonly EhrmsContext _db;

    public EmployeeDAO(EhrmsContext db){
        _db=db;
    }

    [HttpGet]
    public async Task<List<Employee>> GetAllAsync(){
        var a =await _db.Employees.ToListAsync();
        return a;
    }

    [HttpGet("{id}")]
    public async Task<Employee?>? GetByIdAsync(int id){
        var result = await _db.Employees.Where(p => p.Id == id)
        .FirstOrDefaultAsync();
        if (result is null){
            Employee empnull = new()
            {
                Name = "未找到数据",
                Gender="",
            };
            return empnull;
        }
        
        return result;
        
    }

    [HttpGet("All/{id}")]
    public async Task<Employee?>? GetAllByIdAsync(int id){
        var result = await _db.Employees.Where(p => p.Id == id)
        .Include(p => p.Department)
        // .Include(p => p.Declarations)
        .Include(p => p.Payrolls)
        .FirstOrDefaultAsync();
        if (result is null){
            Employee empnull = new()
            {
                Name = "未找到数据",
                Gender="",
            };
            return empnull;
        }
        
        return result;
        
    }
    ///DAOs/Persons/Departments/1
    // [HttpGet("Departments/{id}")]
    // public async Task<> GetEmpsByIdAsync(int id){

    //     Console.WriteLine("Person need to get departments is arrived");

    //     return 
    //     (await _db.Departments.Where(d=> d.Employees.Any(j => j.Id== id)).ToListAsync())
    //     .OrderByDescending(d => d.Id)
    //     .ToList();
    // }

    // [HttpGet("Courses/{id}")]
    // [ActionName("PersonGetCourse1")]
    // public async Task<ActionResult<List<Course>>> GetCoursesByIdAsync(int id){

    //     Console.WriteLine("Person need to get Courses is arrived");

    //     return 
    //     (await _db.Courses.Where(d=> d.PresentStudents.Any(j => j.Id== id)).ToListAsync())
    //     .OrderByDescending(d => d.Id)
    //     .ToList();
    // }

    
    //
    [HttpPost]
    public async Task AddAsync(Employee dept){
        _db.Employees.Add(dept);
        await _db.SaveChangesAsync();
    }
    [HttpPost("Update")]
    [ActionName("EmployeeUpdate1")]
    public async Task UpdateAsync(List<Employee> deptlist){
        _db.Employees.UpdateRange(deptlist);
        await _db.SaveChangesAsync();
    }
    
    [HttpPost("Delete")]
    [ActionName("PersonDelete1")]
    public async Task DeleteAsync(List<int>? Idlist){
        Console.WriteLine("Idlist arrived");
        if(Idlist is null){
            Console.WriteLine("Idlist cant remove it is null");
            return;
        }
        List<Employee> emplist=[];
        foreach(var id in Idlist){
        var a=await _db.Employees.FindAsync(id);
        if(a is null)
        {
            Console.WriteLine("cant delete : finding dept is null");
            continue;//may be break
        }
        emplist.Add(a) ;
        }
        if (emplist is null){
            Console.WriteLine("cant delete : finding dept is null");
            return;
        }
        _db.RemoveRange(emplist);
        Console.WriteLine("depts changed");
        await _db.SaveChangesAsync();
    }

    [HttpPost("Delete/one")]
    [ActionName("PersonDelete2")]
    public async Task DeleteAsync(int id){
        Console.WriteLine("Id arrived");
        var emp = await _db.Employees.FindAsync(id);
        if(emp is null)
        {Console.WriteLine("Null id cant delete"); return;}
        _db.Remove(emp);
        Console.WriteLine("Idlist changed");
        await _db.SaveChangesAsync();
    }

}