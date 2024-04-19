using System.Text.Json;
using System.Text.Json.Serialization;
using Blazored.LocalStorage;
using ehrms.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using test_7.Controller;
using test_7.Data;
using test_7.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddHttpClient("http://localhost:5198/");

builder.Services.AddHttpClient("client_1",config=>  //这里指定的name=client_1，可以方便我们后期服用该实例
    {//https://www.jianshu.com/p/732aee097c6b
        config.BaseAddress= new Uri("http://localhost:5198/");
        config.DefaultRequestHeaders.Add("header_1","header_1");
    });


builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
// builder.Services.AddBlazoredLocalStorage(config =>
// {
//     config.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
//     config.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
//     config.JsonSerializerOptions.IgnoreReadOnlyProperties = true;
//     config.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
//     config.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
//     config.JsonSerializerOptions.ReadCommentHandling = JsonCommentHandling.Skip;
//     config.JsonSerializerOptions.WriteIndented = false;
// });
builder.Services.AddBlazoredLocalStorage();
//AppState store
//builder.Services.AddScoped<Accountinfo>();
// IHttpClientFactory httpClientFactory;
// HttpClient hpc = new(){
//     BaseAddress=new Uri("http://localhost:5198/");
// }
// builder.Services.AddSingleton<DaoController>(
//     hpc
//     //httpClientFactory.CreateClient(client_1);
// );

builder.Services.AddSingleton<Accountinfo>();

//builder.Services.AddSingleton<string>("http://localhost:5198/");

//builder.Services.AddSingleton<WeatherForecastService>();
//builder.Services.AddSingleton<DepartmentService>();
//builder.Services.AddSingleton<DaoService<Type>>();

//conect to my sql
// builder.Services.AddDbContext<test_7Context>(opt =>
// {
//     var cs=builder.Configuration.GetConnectionString("MySqlLapTop");
//     if(cs==null){
//         Console.WriteLine("conectionString is null");
//         Environment.Exit(0);
//     }
//     opt.UseMySQL(cs);
// });
//忽略关系循环，可能导致json无法传输
builder.Services.AddControllersWithViews()
                .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddDbContext<EhrmsContext>(opt =>
{
    var cs=builder.Configuration.GetConnectionString("MySqlLapTopOverWrite");
    if(cs==null){
        Console.WriteLine("conectionString is null");
        Environment.Exit(0);
    }
    opt.UseMySQL(cs);
});

//Add Ant Design
builder.Services.AddAntDesign();


var app = builder.Build();


//add seeding service
/*
*/
var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<EhrmsContext>();
    if (db.Database.EnsureCreated() || !db.Employees.Any() )
    {
        
        EhrmsSeedData.Initialize(db);
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
//MapControllerRoute
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

app.Run();
