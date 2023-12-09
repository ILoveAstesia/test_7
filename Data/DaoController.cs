namespace test_7.Data;

public class DaoController(HttpClient httpClient)
{

    //readonly string apiAddress ="http://localhost:5198/" apiAddress +;
    readonly HttpClient _httpClient = httpClient;

    public async Task<List<T>?> GetAllAsync<T>()
    {
        var a =typeof(T);
        Console.WriteLine(_httpClient.BaseAddress+"DAOs/"+a.ToString());
        //T.toString();
        return await _httpClient.GetFromJsonAsync<List<T>>( _httpClient.BaseAddress+"DAOs/"+a.ToString());

    }

    

}