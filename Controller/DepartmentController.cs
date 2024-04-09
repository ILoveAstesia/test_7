//using Microsoft.AspNetCore.Components;
using System.Security.Policy;
using Microsoft.AspNetCore.Mvc;
using test_7.Model;

namespace test_7.Controller;
public class DepartmentController(HttpClient httpClient)
{   readonly Uri ApiUri=httpClient.BaseAddress!;
    readonly HttpClient _httpClient = httpClient;

    public async Task<List<Department>?> GetAllAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Department>>(ApiUri + "Departments/");
    }

    public async Task<List<Department>?> GetByIdAsync(int id)
    {
        Console.WriteLine(ApiUri + "Departments" + "/" + id);
        return
        await _httpClient
        .GetFromJsonAsync<List<Department>>
            (ApiUri + "Departments" + "/" + id);//+"?id="

    }

    public async Task AddAsync(Department department)
    {
        await _httpClient.PostAsJsonAsync($"{ApiUri}Departments", department);
    }

    public async Task UpdateAsync(List<Department> deptlist)
    {
        await _httpClient.PostAsJsonAsync($"{ApiUri}Departments"+"/"+"Update", deptlist);
    }

    public async Task DeleteAsync(List<int>? idlist)
    {
        Console.WriteLine("point delete idlist");
        await _httpClient.PostAsJsonAsync($"{ApiUri}Departments"+"/"+"Delete", idlist);
    }

    public async Task DeleteAsync(int id)
    {
        Console.WriteLine("point delete id");
        await _httpClient.PostAsJsonAsync($"{ApiUri}Departments"+"/"+"Delete/one",id);
    }


}