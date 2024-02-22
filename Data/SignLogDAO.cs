using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test_7.Model;

namespace test_7.Data;
[Route("DAOs/SignLogs")]
[ApiController]
public class SignLogDAO(test_7Context db)
{
    readonly test_7Context _db = db;

    // [HttpGet("{id}", Name = "GetById")]
    // [ActionName("Get1")]
    [HttpGet("{id}")]
    public async Task<ActionResult<List<SignLog>>> GetByPersonIdAsync(int id){
        return 
        (await _db.SignLogs.Where(p => p.PersonId == id).ToListAsync())
        .OrderByDescending(p => p.Arrive)
        .ToList();
    }

    [HttpPost]
    public async Task AddOneAsync(SignLog log){
        _db.SignLogs.Add(log);
        await _db.SaveChangesAsync();
    }

}