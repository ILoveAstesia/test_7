using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using test_7.Data;
using test_7.Model;

namespace test_7.Data;

[Route("DAOs/Classes")]
[ApiController]
public class ClassDAO
{
    readonly test_7Context _db;

    public ClassDAO(test_7Context db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<List<Class>> GetAllAsync()
    {
        return await _db.Clazzs.ToListAsync();
    }

    [HttpGet("{id}")]
    //[ActionName("AccountinfoGet1")] , Name = "AccountinfoGetById"
    public Class? GetById(int id)
    {
        var temp = _db.Clazzs.Where(p => p.Id == id).FirstOrDefault<Class>();
        // if (temp is null){
        //     return null;
        // }
        return temp;

    }

}