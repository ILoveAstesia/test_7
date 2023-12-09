using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test_7.Model;

namespace test_7.Data;
[Route("DAOs")]
[ApiController]
public class DataAccessObject(test_7Context db)//where T : class
{
    readonly test_7Context _db = db;

    [HttpGet("{modelType}", Name = "GetforAll")]
    [ActionName("GetAll")]
    public async Task<List<modelType>> GetAllAsync<modelType>(Type modelType){
        return await _db.Set<modelType>().ToListAsync();
        //return await _db.Departments.ToListAsync();
    }


}