namespace test_7.Controller;

public class DaoController
{

    //readonly string apiAddress ="http://localhost:5198/" apiAddress +;
    readonly HttpClient _httpClient ;
    readonly Uri apiuri;

    public DaoController(HttpClient httpClient){
        _httpClient=httpClient;
        if(_httpClient.BaseAddress is null){
        Console.WriteLine("HttpClient Uri is null");
        Environment.Exit(0);
        }
        apiuri=_httpClient.BaseAddress;
        return ;
        //return ;
    }
    
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
        
        //var a =typeof(T);
        Console.WriteLine(apiuri+"DAOs/"+page);
        //T.toString();
        return await _httpClient.GetFromJsonAsync<List<T>>( apiuri+"DAOs/"+page);
       
    }

    public async Task<List<T>?> GetOwnPropertyAsync<T>(string PropertyPage,int id)where T:class{
        Console.WriteLine(apiuri+"DAOs/"+PropertyPage+id);
        return await _httpClient.GetFromJsonAsync<List<T>>( apiuri+"DAOs/"+PropertyPage+id);
    }

    

}