using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test_7.Model;

namespace test_7.Data;
[Route("Departments")]
[ApiController]
public class DepartmentGetService{
    readonly test_7Context _db;

    public DepartmentGetService(test_7Context db){
        _db=db;
    }

    [HttpGet]
    public async Task<ActionResult<List<Department>>> All(){
        return await _db.Departments.ToListAsync();
    }

    [HttpGet("{id}", Name = "GetById")]
    [ActionName("Get1")]
    public async Task<ActionResult<List<Department>>> ById(int id){
        //await _db.Departments.ToListAsync();
        //await _db.Departments.Where(p => p.Id == id).ToListAsync()
        return 
        (await _db.Departments.Where(p => p.Id == id).ToListAsync())
        .OrderByDescending(p => p.Id)
        .ToList();
    }

    //
    [HttpPost]
    public async Task Add(Department dept){
        _db.Departments.Add(dept);
        await _db.SaveChangesAsync();
    }


}