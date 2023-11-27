//using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using test_7.Model;

namespace test_7.Data;
public class DepartmentService
{   String apiAddress="http://localhost:5198/";
    readonly HttpClient _httpClient;
    //readonly test_7 _db;
    //NavigationManager nvg;
    public DepartmentService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        //nvg.Uri=_httpClient ;
    }

    public async Task<List<Department>?> GetAllAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Department>>(apiAddress + "Departments/");
    }

    public async Task<List<Department>?> GetByIdAsync(int id)
    {
        return
        await _httpClient
        .GetFromJsonAsync<List<Department>>
            (apiAddress + "Departments" + "/" + id);//+"?id="

    }

    public async Task AddAsync(Department department)
    {
        await _httpClient.PostAsJsonAsync($"{apiAddress}Departments", department);
    }





}