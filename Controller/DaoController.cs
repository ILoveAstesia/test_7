namespace test_7.Controller;

public class DaoController
{
    //readonly string apiAddress ="http://localhost:5198/" apiAddress +;
    readonly IHttpClientFactory _httpClient ;
    readonly HttpClient Client;
    readonly String apiurl;
    public DaoController(IHttpClientFactory httpClient){

        _httpClient= httpClient;

        Client = _httpClient.CreateClient("client_1"); 

        if(Client.BaseAddress is null){
        Console.WriteLine("HttpClient Uri is null");
        Environment.Exit(0);
        }
        
        apiurl = Client.BaseAddress.ToString();
        //apiuri=_httpClient.BaseAddress;
        
        return ;
        //return ;
    }
    
    public async Task<List<T>?> GetAllAsync<T>()where T:class
    {
        //var Client = _httpClient.CreateClient("client_1"); 
        // test_7Context db=new();
        // DataAccessObject dao=new(db);
        // return await dao.GetAllAsync<T>();
        var a =typeof(T);
        Console.WriteLine(Client.BaseAddress+"DAOs/"+a.ToString());
        //T.toString();
        return await Client.GetFromJsonAsync<List<T>>( apiurl+"DAOs/"+a.ToString());
       

    }

    public async Task<List<T>?> GetAllAsync<T>(String page)where T:class
    {
        
        //var a =typeof(T);
        Console.WriteLine(apiurl+"DAOs/"+page);
        //T.toString();
        return await Client.GetFromJsonAsync<List<T>>( apiurl+"DAOs/"+page);
       
    }

    public async Task<List<T>?> GetOwnPropertyAsync<T>(string PropertyPage,int id)where T:class{
        Console.WriteLine(apiurl+"DAOs/"+PropertyPage+id);
        return await Client.GetFromJsonAsync<List<T>>( apiurl+"DAOs/"+PropertyPage+id);
    }

    

}