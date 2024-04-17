using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using test_7.Data;
using test_7.Model;

namespace test_7.Data;

[Route("DAOs/Accountinfos")]
[ApiController]
public class AccountDAO
{
    readonly test_7Context _db;

    public AccountDAO(test_7Context db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<List<Accountinfo>> GetAllAsync()
    {
        Console.WriteLine("GetAllAccountinfo");
        return await _db.Accountinfos.ToListAsync();
    }

    [HttpGet("{id}", Name = "AccountinfoGetById")]
    [ActionName("AccountinfoGet1")]
    public async Task<ActionResult<List<Accountinfo>>> GetByIdAsync(int id)
    {
        //await _db.Departments.ToListAsync();
        //await _db.Departments.Where(p => p.Id == id).ToListAsync()
        return
        (await _db.Accountinfos.Where(p => p.Id == id).ToListAsync())
        .OrderByDescending(p => p.Id)
        .ToList();
    }
    ///DAOs/Persons/Departments/1
    // [HttpGet("Departments/{id}", Name = "PersonGetDeptById")]
    // [ActionName("PersonGetDept1")]
    // public async Task<ActionResult<List<Department>>> GetDeptsByIdAsync(int id){

    //     Console.WriteLine("Person need to get departments is arrived");

    //     return 
    //     (await _db.Departments.Where(d=> d.Persons.Any(j => j.Id== id)).ToListAsync())
    //     .OrderByDescending(d => d.Id)
    //     .ToList();
    // }
    //Accountinfos/Password/
    [HttpGet("Passwords/{id}", Name = "AccountinfoGetPasswordById")]
    [ActionName("AccountinfoGetPassword1")]
    public async Task<String?> GetPasswordByIdAsync(int id)
    {

        Console.WriteLine("Account need to get psw is arrived Id:" + id);
        var ac = await _db.Accountinfos.Where(a => a.Id == id).FirstOrDefaultAsync<Accountinfo>();

        if (ac is null)
            return
            // "{}";
            JsonSerializer.Serialize("");
        var psw = ac.Password;
        // Console.WriteLine("1");
        return JsonSerializer.Serialize(psw);
    }


    // //
    // [HttpPost]
    // public async Task AddAsync(Person dept){
    //     _db.Persons.Add(dept);
    //     await _db.SaveChangesAsync();
    // }
    // [HttpPost("Update")]
    // [ActionName("PersonUpdate1")]
    // public async Task UpdateAsync(List<Person> deptlist){
    //     _db.Persons.UpdateRange(deptlist);
    //     await _db.SaveChangesAsync();
    // }

    // [HttpPost("Delete")]
    // [ActionName("PersonDelete1")]
    // public async Task DeleteAsync(List<int>? Idlist){
    //     Console.WriteLine("Idlist arrived");
    //     if(Idlist is null){
    //         Console.WriteLine("Idlist cant remove it is null");
    //         return;
    //     }
    //     List<Person> depts=[];
    //     foreach(var id in Idlist){
    //     var a=await _db.Persons.FindAsync(id);
    //     if(a is null)
    //     {
    //         Console.WriteLine("cant delete : finding dept is null");
    //         continue;//may be break
    //     }
    //     depts.Add(a) ;
    //     }
    //     if (depts is null){
    //         Console.WriteLine("cant delete : finding dept is null");
    //         return;
    //     }
    //     _db.RemoveRange(depts);
    //     Console.WriteLine("depts changed");
    //     await _db.SaveChangesAsync();
    // }

    // [HttpPost("Delete/one")]
    // [ActionName("PersonDelete2")]
    // public async Task DeleteAsync(int id){
    //     Console.WriteLine("Id arrived");
    //     var dept = await _db.Persons.FindAsync(id);
    //     if(dept is null)
    //     {Console.WriteLine("Null id cant delete"); return;}
    //     _db.Remove(dept);
    //     Console.WriteLine("Idlist changed");
    //     await _db.SaveChangesAsync();
    // }

}