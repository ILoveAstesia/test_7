using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using test_7.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

//builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<DepartmentService>();


//conect to my sql
builder.Services.AddDbContext<test_7Context>(opt =>
{
    var cs=builder.Configuration.GetConnectionString("MySql");
    if(cs==null){
        Console.WriteLine("conectionString is null");
        Environment.Exit(0);
    }
    opt.UseMySQL(cs);
});


var app = builder.Build();

//add seeding service
/*
var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<test_7Context>();
    if (db.Database.EnsureCreated())
    {
        SeedData.Initialize(db);
    }
}
*/

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
