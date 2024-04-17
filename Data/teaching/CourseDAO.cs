using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using test_7.Data;
using test_7.Model;

namespace test_7.Data;

[Route("DAOs/Courses")]
[ApiController]
public class CourseDAO
{
    readonly test_7Context _db;

    public CourseDAO(test_7Context db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<List<Course>> GetAllAsync()
    {
        Console.WriteLine("CourseGetAllAsync");
        return await _db.Courses.ToListAsync();
    }

    [HttpGet("{id}")]
    //[ActionName("AccountinfoGet1")] , Name = "AccountinfoGetById"
    public Course? GetById(int id)
    {
        var temp = _db.Courses.Where(p => p.Id == id).FirstOrDefault<Course>();
        // if (temp is null){
        //     return null;
        // }
        return temp;

    }

}