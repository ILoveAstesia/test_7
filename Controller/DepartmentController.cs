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

    public async Task UpdateAsync(List<Department> deptlist){
        _db.Departments.UpdateRange(deptlist);
        await _db.SaveChangesAsync();
    }

    public void DeleteAsync(int Id){
        ;
    }

}