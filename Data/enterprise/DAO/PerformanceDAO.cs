using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using test_7.Data;
using ehrms.Model;

namespace ehrms.Data;

[Route("DAOs/Performances")]
[ApiController]
public class PerformanceDAO {
    readonly EhrmsContext _db;

    public PerformanceDAO(EhrmsContext db){
        _db=db;
    }

    [HttpGet]
    public async Task<List<Performance>> GetAllAsync(){
        return await _db.Performances.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<Performance?> GetByIdAsync(int id){
        return await _db.Performances.Where(p => p.Id == id).FirstOrDefaultAsync();
        
    }


}