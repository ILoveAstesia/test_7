using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using test_7.Data;
using ehrms.Model;

namespace ehrms.Data;

[Route("DAOs/Trainings")]
[ApiController]
public class TrainingDAO {
    readonly EhrmsContext _db;

    public TrainingDAO(EhrmsContext db){
        _db=db;
    }

    [HttpGet]
    public async Task<List<Training>> GetAllAsync(){
        return await _db.Trainings.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<Training?> GetByIdAsync(int id){
        return await _db.Trainings.Where(p => p.Id == id).FirstOrDefaultAsync();
        
    }


}