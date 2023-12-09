//using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using test_7.Model;

namespace test_7.Data;
public class PersonService
{   String apiAddress="http://localhost:5198/";
    readonly HttpClient _httpClient;
    //readonly test_7 _db;
    //NavigationManager nvg;
    public PersonService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        //nvg.Uri=_httpClient ;
    }

    public async Task<List<Person>?> GetAllAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Person>>(apiAddress + "Persons/");
    }

    public async Task<List<Person>?> GetByIdAsync(int id)
    {
        return
        await _httpClient
        .GetFromJsonAsync<List<Person>>
            (apiAddress + "Persons" + "/" + id);//+"?id="

    }

    public async Task AddAsync(Person Person)
    {
        await _httpClient.PostAsJsonAsync($"{apiAddress}Persons", Person);
    }

    public async Task UpdateAsync(List<Person> Personlist)
    {
        await _httpClient.PostAsJsonAsync($"{apiAddress}Persons"+"/"+"Update", Personlist);
    }

    public async Task DeleteAsync(List<int>? idlist)
    {
        Console.WriteLine("point delete idlist");
        await _httpClient.PostAsJsonAsync($"{apiAddress}Persons"+"/"+"Delete", idlist);
    }

    public async Task DeleteAsync(int id)
    {
        Console.WriteLine("point delete id");
        await _httpClient.PostAsJsonAsync($"{apiAddress}Persons"+"/"+"Delete/one",id);
    }


}