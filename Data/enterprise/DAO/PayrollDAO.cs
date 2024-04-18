using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using test_7.Data;
using ehrms.Model;

namespace ehrms.Data;

[Route("DAOs/Payrolls")]
[ApiController]
public class PayrollDAO {
    readonly EhrmsContext _db;

    public PayrollDAO(EhrmsContext db){
        _db=db;
    }

    [HttpGet]
    public async Task<List<Payroll>> GetAllAsync(){
        return await _db.Payrolls.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<Payroll?> GetByIdAsync(int id){
        return await _db.Payrolls.Where(p => p.Id == id).FirstOrDefaultAsync();
        
    }


}