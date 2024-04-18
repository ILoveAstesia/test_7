using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using test_7.Data;
using ehrms.Model;

namespace ehrms.Data;

[Route("DAOs/Declarations")]
[ApiController]
public class DeclarationDAO(EhrmsContext db)
{
    readonly EhrmsContext _db = db;

    [HttpGet]
    public async Task<List<Declaration>> GetAllAsync(){
        return await _db.Declarations.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<Declaration?> GetByIdAsync(int id){
        return await _db.Declarations.Where(p => p.Id == id).FirstOrDefaultAsync();
        
    }


}