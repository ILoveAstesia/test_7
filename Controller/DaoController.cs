namespace test_7.Controller;

public class DaoController(HttpClient httpClient)
{

    //readonly string apiAddress ="http://localhost:5198/" apiAddress +;
    readonly HttpClient _httpClient = httpClient;
    
    public async Task<List<T>?> GetAllAsync<T>()where T:class
    {
        // test_7Context db=new();
        // DataAccessObject dao=new(db);
        // return await dao.GetAllAsync<T>();
        var a =typeof(T);
        Console.WriteLine(_httpClient.BaseAddress+"DAOs/"+a.ToString());
        //T.toString();
        return await _httpClient.GetFromJsonAsync<List<T>>( _httpClient.BaseAddress+"DAOs/"+a.ToString());
       

    }

    public async Task<List<T>?> GetAllAsync<T>(String page)where T:class
    {
        Uri apiuri=_httpClient.BaseAddress!;
        //var a =typeof(T);
        Console.WriteLine(apiuri+"DAOs/"+page);
        //T.toString();
        return await _httpClient.GetFromJsonAsync<List<T>>( apiuri+"DAOs/"+page);
       
    }

    

}