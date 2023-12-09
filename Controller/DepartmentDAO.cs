using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test_7.Data;
using test_7.Model;

[Route("Departments")]
[ApiController]
public class DepartmentController {
    readonly test_7Context _db;

    public DepartmentController(test_7Context db){
        _db=db;
    }

    [HttpGet]
    public async Task<List<Department>> GetAllAsync(){
        return await _db.Departments.ToListAsync();
    }

    [HttpGet("{id}", Name = "GetById")]
    [ActionName("Get1")]
    public async Task<ActionResult<List<Department>>> GetByIdAsync(int id){
        //await _db.Departments.ToListAsync();
        //await _db.Departments.Where(p => p.Id == id).ToListAsync()
        return 
        (await _db.Departments.Where(p => p.Id == id).ToListAsync())
        .OrderByDescending(p => p.Id)
        .ToList();
    }

    
    //
    [HttpPost]
    public async Task AddAsync(Department dept){
        _db.Departments.Add(dept);
        await _db.SaveChangesAsync();
    }
    [HttpPost("Update")]
    [ActionName("Update1")]
    public async Task UpdateAsync(List<Department> deptlist){
        _db.Departments.UpdateRange(deptlist);
        await _db.SaveChangesAsync();
    }
    
    [HttpPost("Delete")]
    [ActionName("Delete1")]
    public async Task DeleteAsync(List<int>? Idlist){
        Console.WriteLine("Idlist arrived");
        if(Idlist is null){
            Console.WriteLine("Idlist cant remove it is null");
            return;
        }
        List<Department> depts=[];
        foreach(var id in Idlist){
        var a=await _db.Departments.FindAsync(id);
        if(a is null)
        {
            Console.WriteLine("cant delete : finding dept is null");
            continue;//may be break
        }
        depts.Add(a) ;
        }
        if (depts is null){
            Console.WriteLine("cant delete : finding dept is null");
            return;
        }
        _db.RemoveRange(depts);
        Console.WriteLine("depts changed");
        await _db.SaveChangesAsync();
    }

    [HttpPost("Delete/one")]
    [ActionName("Delete2")]
    public async Task DeleteAsync(int id){
        Console.WriteLine("Id arrived");
        var dept = await _db.Departments.FindAsync(id);
        if(dept is null)
        {Console.WriteLine("Null id cant delete"); return;}
        _db.Remove(dept);
        Console.WriteLine("Idlist changed");
        await _db.SaveChangesAsync();
    }

}