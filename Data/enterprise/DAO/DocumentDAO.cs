using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using test_7.Data;
using ehrms.Model;

namespace ehrms.Data;

[Route("DAOs/Documents")]
[ApiController]
public class DocumentDAO {
    readonly EhrmsContext _db;

    public DocumentDAO(EhrmsContext db){
        _db=db;
    }

    [HttpGet]
    public async Task<List<Document>> GetAllAsync(){
        return await _db.Documents.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<Document?> GetByIdAsync(int id){
        return await _db.Documents.Where(p => p.Id == id).FirstOrDefaultAsync();
        
    }


}