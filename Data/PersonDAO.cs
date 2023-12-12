using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using test_7.Data;
using test_7.Model;

namespace test_7.Data;

[Route("DAOs/Persons")]
[ApiController]
public class PersonDAO {
    readonly test_7Context _db;

    public PersonDAO(test_7Context db){
        _db=db;
    }

    [HttpGet]
    public async Task<List<Person>> GetAllAsync(){
        return await _db.Persons.ToListAsync();
    }

    [HttpGet("{id}", Name = "PersonGetById")]
    [ActionName("PersonGet1")]
    public async Task<ActionResult<List<Person>>> GetByIdAsync(int id){
        //await _db.Departments.ToListAsync();
        //await _db.Departments.Where(p => p.Id == id).ToListAsync()
        return 
        (await _db.Persons.Where(p => p.Id == id).ToListAsync())
        .OrderByDescending(p => p.Id)
        .ToList();
    }

    
    //
    [HttpPost]
    public async Task AddAsync(Person dept){
        _db.Persons.Add(dept);
        await _db.SaveChangesAsync();
    }
    [HttpPost("Update")]
    [ActionName("PersonUpdate1")]
    public async Task UpdateAsync(List<Person> deptlist){
        _db.Persons.UpdateRange(deptlist);
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
        List<Person> depts=[];
        foreach(var id in Idlist){
        var a=await _db.Persons.FindAsync(id);
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
    [ActionName("PersonDelete2")]
    public async Task DeleteAsync(int id){
        Console.WriteLine("Id arrived");
        var dept = await _db.Persons.FindAsync(id);
        if(dept is null)
        {Console.WriteLine("Null id cant delete"); return;}
        _db.Remove(dept);
        Console.WriteLine("Idlist changed");
        await _db.SaveChangesAsync();
    }

}