using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test_7.Model;

namespace test_7.Data;
[Route("DAOs")]
[ApiController]
public class DataAccessObject(test_7Context db)//where T : class
{
    readonly test_7Context _db=db ;
//如何通过request的参数例如strin来判断类型
    // [HttpGet("{typeName}", Name = "GetforAll")]
    // [ActionName("GetAll")]
    // public async  dynamic  GetAllAsync(String typeName){
    //     Type? type =  Type.GetType(typeName);
    //     if(type is null){
    //         dynamic obj = "null";
            
    //         return obj;
    //     }
    //     DAO<type> dao=new(_db);
    //     dynamic obj2 = "null";
    //     return obj2;

        // dynamic obj=await _db.Set<Type.GetType(typeName)>().ToListAsync();
        // return obj;
        //return await _db.Set<modelType>().ToListAsync();
        //return await _db.Departments.ToListAsync();
    //}
    public async Task<List<T>> GetAllAsync<T>()where T:class{
        return await _db.Set<T>().ToListAsync();
    }

    // [HttpGet("{typeName}", Name = "GetforAll")]
    // [ActionName("GetAll")]//期望通过http的传输，传输一个字符串【typename】当作方法的参数，通过转换使得方法能够动态的转换自己的返回类型为typename的list，以实现复用。
    // public async Task<List<typeName>> GetAllAsync(Type typeName){
        
    //     return await _db.Set<typeName>().ToListAsync();
    // }


}

// class DAO<T>(test_7Context db)where T : class{
//     readonly test_7Context _db = db;
//     public async Task<List<T>> GetAllAsync(){
//         return await _db.Set<T>().ToListAsync();
//     }

//     //return await _db.Set<modelType>().ToListAsync();
// }