using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using test_7.Data;
using ehrms.Model;

namespace ehrms.Data;

[Route("DAOs/Departments")]
[ApiController]
public class DepartmentDAO {
    readonly EhrmsContext _db;

    public DepartmentDAO(EhrmsContext db){
        _db=db;
    }

    [HttpGet]
    public async Task<List<Department>> GetAllAsync(){
        return await _db.Departments.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<Department?> GetByIdAsync(int id){
        return await _db.Departments.Where(p => p.Id == id).FirstOrDefaultAsync();
        
    }


}