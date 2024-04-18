using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using test_7.Data;
using ehrms.Model;

namespace ehrms.Data;

[Route("DAOs/Recruitments")]
[ApiController]
public class RecruitmentDAO {
    readonly EhrmsContext _db;

    public RecruitmentDAO(EhrmsContext db){
        _db=db;
    }

    [HttpGet]
    public async Task<List<Recruitment>> GetAllAsync(){
        return await _db.Recruitments.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<Recruitment?> GetByIdAsync(int id){
        return await _db.Recruitments.Where(p => p.Id == id).FirstOrDefaultAsync();
        
    }


}