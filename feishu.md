企业人力资源管理系统的设计与实现
Blazor 是什么
一种框架，用于前端。
能用mvc吗
能用antdiseign吗
1. 登录模块 发现有点结构问题，先把所有模块搞完再说具体的细节
2.  
git config --global http.sslVerify false
3. 如何在public之后更改apiaddress和database connect string？
4.  全局apiaddress
5.  
教培系统
1. 需求分析
2. 资产统计
  1. 资产编号（贴纸？）
  2. 出库
  3. 入库
  4. 信息一览
  5. 建模 展示（仅表示空间的关系）不要求物品建模
  6. 资产属性
    1. 名称
    2. 类型
    3. 位置
    4. 价值
    5. 所属
    6.  
  7. 
3. 签到系统
  1. 迟到
  2. 未到
  3. 请假
  4. 已到
4. 课程推进
  1. 还剩/全部 16/64
  2. 进度  48 m3-1
5. 课程续订
  1. 课程类型
  2. 长度
  3. 学生信息
6. 课程转换
  1. 新建学生选课信息
  2. 删除学生选课信息
7. 课程展示
  1. ui Excel表，视频
8. 文件管理
  1. 简单文件共享服务
  2. 课件保存
  3. 在线播放
9. 学生管理
10. 老师管理
11. 选课管理
线性时间顺序
1. 创建项目
  1. 查看.net版本
dotnet --list-sdks
  1. （利用模板）创建新的Blazor应用程序（先要创建并定位到相应文件夹）
dotnet new blazorserver -f net7.0 -o [fileName]
2. git
3. 需求分析
  1.  具体功能模块设计：【待优化】
    1)员工信息档案管理模块
      1. 姓名
      2. 性别
      3. 入职日期
      4. 离职日期
      5. 部门
      6. 岗位
      7. 培训记录
      8. 以往工作记录
      9. 学籍信息
      10. 家庭地址
      11. 联系电话
      12. 绩效信息表id
      13.  政治面貌
      14. 
    2)组织管理模块
      1. 名称
      2. 人员
      3. 简介
      4. 详情
    3)绩效管理模块
      1. 打卡记录
      2. 
    4)人事模块
      1. 会议安排
      2. 面试安排
      3. 人员变动
    5)工资模块
      1. 金额
      2. 员工id
    6)合同模块
      1. 文件
      2. 甲方
    7)培训模块
      1.  日期
      2. 参与人员
4. 设计表结构
  1. 人员表 person
    1. Id 自增
    2. Name
    3. 
  2. 部门表 department
    1. Id
    2. PersonId
    3. Name
    4. 
  3. 薪资发放表 Payroll
    1. Date
    2. Money
    3. PersonId
  4. 面试安排表 Interview
    1. 名称
    2. 电话
    3. 时间
    4. 职位
    5. 
  5. 合同表 Contract
    1. Id
    2. name
  6. 培训表 training
    1. Id
    2. Name
    3. duration
    4. persons
5.  表关系
  1. 人员 多对多 部门
    1. 建立部门人员记录表中间值存放
  2. 人员 一对多 薪资发放
    1. 
  3. 人员 一对一 合同
  4. 人员 多对多 培训
6. 在根目录下创建文件夹
  1. Controller 传递
  2. Service 复用
  3. Model 基础
  4. Component 复用
7. 模型类
  1. Person
namespace EHRMsystem.Model//namespace
{
    public class Person
    {
        public int Id  {set;get;}
        public String? Name {set;get;}
        public int DepartmentId {set;get;}

    }
}

  2.  Department
namespace EHRMsystem.Model;

public class Department{
    //attention get set is required ，if not efcore will not use them！
    public int Id {set;get;}
    public String? Name {set;get;}
    public List<Person> Persons { get;set; } = new();
}
  3. Persondepartment（辅助类）
namespace EHRMsystem.Model;

public class DepartmentPerson{
    public int Id{get;set;}
    public int PersonId {get;set;}

    public int DepartmentId {get;set;}
} 
  4. 
8. dotnet tool update --global dotnet-ef -v 7.0.10
9.  安装前置包 由于之前学习的时候使用过migration框架所以打算安装migration design 的包 【待优化】build warning
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package MySql.EntityFrameworkCore
dotnet add package System.Net.Http.Json 
dotnet add package Microsoft.EntityFrameworkCore.Design
 
dotnet add package Mysql.Data
dotnet add package Microsoft.EntityFrameworkCore --version 7.0.0
dotnet add package MySql.EntityFrameworkCore --version 7.0.0
dotnet add package System.Net.Http.Json --version 7.0.0
dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.0

  1. 无法配置索引服务
  2. 尝试更换镜像
  3. 关闭clash解决
10. Migration//停用中
  1. 
dotnet ef migrations add InitialCreate
  2. 如果不适用migration则
  3. 使用data/seed.cs
namespace EHRMsystem.Data;
using EHRMsystem.Model;
public static class SeedData
{
    public static void Initialize(EHRMContext db)
    {

        var a = new Department(){
            Id=1000,
            Name="Pizza",
        };

        var b = new Department(){
            Id=1001,
            Name="Cola",
        };

        var c =new Department(){
            Id=0001,
            Name="Food",
        };

        var person = new Person(){
            Id=1,
            Name = "Basic Cheese Pizza",
            //Detail = "It's cheesy and delicious. Why wouldn't you want one?",
            

        };
        person.Departments.Add(a);

        
        db.Persons.AddRange(person);
        db.Departments.AddRange(a,b,c);
        db.SaveChanges();
    }
}
  4. 注册 之前看到还有其他的东西 是叫fluentapi？可以达成简单的效果？【improve】
...
var app = builder.Build();//mark-----
...

//add seeding service
var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<EHRMContext>();
    if (db.Database.EnsureCreated())
    {
        SeedData.Initialize(db);
    }
}

  5. 
11. 启动mysql服务 pid18092
12. 确认密码 Astesia root 
13. 配置连接字符串 appsettings.json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "MySql":"server=localhost;user id=root;password=Astesia;port=3306;database=EHRMdb"
  }
}


14. 创建数据库表//停用中
dotnet ef database update
15. [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 好像没有用
16. 发现问题 
  1. 使用多对多（manytomany）的关系时需要额外使用新的model类 例如persondepartment类来当中间表，但是一般情况下efcore在 data context onmodulcreating 使用seeddata会自动创建一个由俩个类名称组成的中间表，但是无法赋值（不知道如何）。于是只能手动使用自建的。创建后会有一个自定义的和一个自动生成的表。【待优化】，到时候试试直接手动删除算逑
17. 级联删除？person和department【待实现】
18. CRUD 先使用成功后在考虑模块化重复利用
19. 创建视图，添加侧边栏，发现点击todo是到featch data里面，要调整跳转的页面，之后用antdesign重构一下, 尝试修改
20. Create 我是先进行的Read实现，->Read Implement
  1. 使用jason 格式，通过网页的page传输到后端。
  2. page//先不自增
  3. 手动输入id
  4. 手动输入name，可能可以是excel输入？
  5.  如何绑定员工？，手动输入对应id即可
  6. index.razor
...
Id:<input type="number" @bind=dept!.Id>
<br>
Name:<input type="text" @bind=dept.Name>
<br>
<button @onclick=addDepartment disabled=@isSubmitting >Add a NewDepartment</button>
<br>
...
@code{
    ...
    bool isSubmitting=false;
    Department? dept=new();
    async Task addDepartment(){//只能写task 不能写 void
        if(dept is null)
        {return;}
        isSubmitting = true;
        await HttpClient.PostAsJsonAsync($"{NavigationManager.BaseUri}Departments", dept);
        isSubmitting = false;
        GetAllDept();
        //NavigationManager.NavigateTo("/",true);//refresh
    }
    
}
  7.   DepartmentService.cs
    ...
    //
    [HttpPost]
    public async Task Add(Department dept){
        _db.Departments.Add(dept);
        await _db.SaveChangesAsync();
    }
  8. 特性，当id默认为0是id会自增，
  9. 【待优化】id重复检测，以及其他相关检测
  10. ->Update implement
21. Read
  1.  index.razor
@page "/"

<input type="number" @bind=id>
<br>
<button @onclick=GetDataList class="primary" >GetData</button>
<br>
<button @onclick=GetAllDept class="secondary">RefreshDept</button>

<ListComponent Name="Department" ItemType="Department" Data="DataList">
<HeadTemplet>
    <th>Id</th>
    <th>Name</th>
</HeadTemplet>
<RowTemplet>
    <td>@context.Id</td>
    <td>@context.Name</td>
</RowTemplet>
<ContentTemplet>

    <p>TotalNumber:@DataList!.Count();</p>

</ContentTemplet>
</ListComponent>

@inject HttpClient HttpClient;
@inject NavigationManager NavigationManager;
@code {
    //String? displayPass="未输入";
    int id ;
    List<Department>? DataList;
    protected override Task OnAfterRenderAsync(bool firstRender)
    {
        if(firstRender){
        GetAllDept();
        //StateHasChanged();//如果不进行firstrender判断，会发生循环，可能是每次statehaschanged都会触发OnAfterRenderAsync。
        }
        return  base.OnAfterRenderAsync(firstRender);
    }
    async void GetDataList(){
        DataList=await HttpClient.GetFromJsonAsync<List<Department>>(NavigationManager.BaseUri + "Departments"+"/"+id);//+"?id="
        StateHasChanged();
    }

    async void GetAllDept(){
        DataList=await HttpClient.GetFromJsonAsync<List<Department>>(NavigationManager.BaseUri + "Departments/");
        StateHasChanged();
    }

}
 
  2. program。cs
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
  3.  ListComponent.razor
@typeparam ItemType

<PageTitle>@Name</PageTitle>

<h1>@Name</h1>

<p>This component demonstrates fetching data from a service.</p>

@if (Data == null)
{
    <p><em>Loading...</em></p>
}
else
{
    <table class="table">
        <thead>
            <tr>
                @HeadTemplet
            </tr>
        </thead>
        <tbody>
            @foreach (var item in Data!)
            {
                <tr>
                    @RowTemplet!(item)
                </tr>
            }
        </tbody>
        <tfoot>
            @ContentTemplet!("This Context Count Has:" + Data.Count())
        </tfoot>
    </table>
}

@code {
    [Parameter] public List<ItemType>? Data { get; set; }
    [Parameter] public String Name { get; set; } = "Fetching Data From A Service";
    [Parameter] public RenderFragment<String>? ContentTemplet { get; set; }
    [Parameter] public RenderFragment<ItemType>? RowTemplet { get; set; }
    [Parameter] public RenderFragment? HeadTemplet { get; set; }
}
 
  4. 
  5. DepartmentService.cs
using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test_7.Model;

namespace test_7.Data;
[Route("Departments")]
[ApiController]
public class DepartmentGetService{
    readonly test_7Context _db;

    public DepartmentGetService(test_7Context db){
        _db=db;
    }

    [HttpGet]
    public async Task<ActionResult<List<Department>>> All(){
        return await _db.Departments.ToListAsync();
    }

    [HttpGet("{id}", Name = "GetById")]
    [ActionName("Get1")]
    public async Task<ActionResult<List<Department>>> ById(int id){
        return 
        (await _db.Departments.Where(p => p.Id == id).ToListAsync())
        .OrderByDescending(p => p.Id)
        .ToList();
    }

} 
  6. ->Create impliment
22. Update
  1. 双向绑定
  2. 可以优化，现在的方法是使用，类似使用离线表的方法，从库中拷贝表，然后修改离线表在和数据库表进行比较更新，而对性能要求可能比较大，可以想办法追踪标记仅仅更新更改了的。
  3.  
  4. delete implement
23. Delete
  1.  通过复选框，加入零时selectedidlist
  2. 通过service将list传输给controller
  3.  controller通过.find方法将查找到的（跟踪该类）department类放入到零时的集合中，通过removerange方法移除对象
  4. 填充和完善外观
24.  boostrap
25. 尝试升级efcore和其他包到8.0版本
26. 失败，未找到方法
27. 将包逐个退级
28. 发现要将efcore本体退级到7版本
29. 成功
30. 添加新的模型类
31. 发现efcore无法匹配到属性值查找方法
32. 判断是否使用有实体的连接方法
33. 如果不使用的话，可能对于程序操作会不会有阻碍？
34. 尝试使用不用实体的manytomany
  1.  可能是因为使用了都是person的teacher和student
  2. 尝试把teacher和student派生成具体的类
  3. 然后直接用对应类而不是person
  4. InverseProperty？
35. 尝试class成功
36. 添加Course
37. Dotnet run 发现multiple course primary key
38. 不能匿名给id，需要显示提供id。
39. 修改seed
40. 添加成功
41. 尝试列出Person
42. 已经利用组件封装了显示代码，
43. 发现person显示的page代码利用的方法也是类似的，可否将所有的按钮输入框也封装？
44. 如何传入dao的方法和服务？
45. 完成了简单的peronservice复制
46. 
47. 尝试封装Service、Dao
public static void TestSwap()
{
    int a = 1;
    int b = 2;

    Swap<int>(ref a, ref b);
    System.Console.WriteLine(a + " " + b);
}

class SampleClass<T>
{
    void Swap(ref T lhs, ref T rhs) {
    T temp;
    temp = lhs;
    lhs = rhs;
    rhs = temp;​
  
  
  
    }
    
    void getall(){
    
    ｝
    // CS0693.不能和类的形式范型参数，相同
    void SampleMethod<T>() {
    Http get name s 
    Return list t
    }
    // No warning.
    void SampleMethod<U>() { }
    
    
}


  1.  想要这样实现两个基本的类实现所有的基本的增删改查。
namespace test_7.Controller;

public class DaoController(HttpClient httpClient)
{

    //readonly string apiAddress ="http://localhost:5198/" apiAddress +;
    readonly HttpClient _httpClient = httpClient;
    
    public async Task<List<T>?> GetAllAsync<T>()where T:class
    {

        var a =typeof(T);

        return await _httpClient.GetFromJsonAsync<List<T>>( _httpClient.BaseAddress+"DAOs/"+a.ToString());
    }
    

} 

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test_7.Model;

namespace test_7.Data;
[Route("DAOs")]
[ApiController]
public class DataAccessObject(test_7Context db)//where T : class
{
    readonly test_7Context _db=db ;

    // [HttpGet("{typeName}", Name = "GetforAll")]
    // [ActionName("GetAll")]//期望通过http的传输，传输一个字符串【typename】当作方法的参数，通过转换使得方法能够动态的转换自己的返回类型为typename的list，以实现复用。
    // public async Task<List<typeName>> GetAllAsync(Type typeName){
    //     return await _db.Set<typeName>().ToListAsync();
    // }
    //报错，无法使用类型变量作为泛型的类型参数。
}
  2. 最后这样了
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using test_7.Data;
using test_7.Model;

namespace test_7.Data;

[Route("DAOs/Persons")]
[ApiController]
public class PersonDAO {
    readonly test_7Context _db;

    public PersonDAO(test_7Context db){
        _db=db;
    }

    [HttpGet]
    public async Task<List<Person>> GetAllAsync(){
        return await _db.Persons.ToListAsync();
    }

    [HttpGet("{id}", Name = "PersonGetById")]
    [ActionName("PersonGet1")]
    public async Task<ActionResult<List<Person>>> GetByIdAsync(int id){
        //await _db.Departments.ToListAsync();
        //await _db.Departments.Where(p => p.Id == id).ToListAsync()
        return 
        (await _db.Persons.Where(p => p.Id == id).ToListAsync())
        .OrderByDescending(p => p.Id)
        .ToList();
    }

    //...
    

} 
  3. 
48. 
服务器设置
1. 服务器局域网（内网）连接
2. 安装https://dotnet.microsoft.com/zh-cn/download/dotnet/8.0 
  Hosting Bundle 
3. 安装 iis 控制面板 -》程序 -》启用或关闭windows功能 -》点一下 internet information serveice
  1. 等待
4. 任务栏搜索 iis 打开 管理器 试着运行，可能自带测试的端口80被占用 修改一下就行，
5. 添加网站，都默认，物理地址就填/publish 就行，端口例如：1324随便写一个
6. 防火墙添加入站规则 允许 例如：1324端口连接 
7. 用其他同网络下设备试试，记得开服务器。
  
  
  
  
  
  





other
运行应用程序（+热重载）
dotnet watch run
创建ToDo组件到Pages目录
dotnet new razorcomponent -n Todo -o Pages
添加包
dotnet add package Microsoft.AspNetCore.SignalR.Client
技术学习
1. Blazor 教程 - 生成首个应用
  1. 
2. ASP.NET Core Blazor 教程
3. 使用 Blazor 生成 Web 应用 - Training
4. 什么是 Blazor？ - Training 
  1.  Blazor WebAssembly 需要新式桌面或移动浏览器。 当前支持以下浏览器：
  - Microsoft Edge
  - Mozilla Firefox
  - Google Chrome
  - Apple Safari
  2. 此模块使用 .NET 6.0 SDK。 通过在首选终端中运行以下命令，确保你已安装 .NET 6.0：
  .NET CLI复制
dotnet --list-sdks
  将显示类似于下面的输出：
  控制台复制
3.1.100 [C:\program files\dotnet\sdk]
  确保列出了以 6 开头的版本。 如果未列出任何版本或未找到命令，请安装最新的 .NET 6.0 SDK。
5.   Blazor 应用的项目结构 - .NET
6. 尝试 将 .NET 应用迁移到 Azure 应用服务 | .NET
7. 什么是 Blazor？ - Training
8. ASP.NET Core Blazor
9. 查询需求
  1. 基于大数据的企业人力资源管理信息化建设探讨 - 中国知网
  2. 基于云计算的企业人力资源管理系统设计与开发探讨 - 中国知网
  3. 基于混合架构的企业人力资源管理系统的设计与实现研究 - 中国知网
10. 
暂时无法在飞书文档外展示此内容
11. 使用 Blazor 路由器组件控制应用的导航 - Training
12.  

测试
1. 创建项目 使用vs22
2. 使用vscode打开
3. 创建Model文件夹在root目录
  1. 创建Person.cs
    1.  内容

namespace BlazorTestStu.Model
{
    public class Person
    {
        public int Id  {set;get;}
        public String Name {set;get;}
        public String Detail {set;get;}
        public int DepetmentId {set;get;}

    }
}

4. 在Data文件夹下创建Seed.cs用来播种数据库
  1. Seed.cs
//continue...
  2. 发现需要context 
5. 创建controller文件夹
  1. PersonController.cs
  2. 发现需要EFcore安装EFcore
6. EF Core install
  1.  原值是使用sqlite 我打算使用mysql
dotnet add package Microsoft.EntityFrameworkCore --version 6.0.8
dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 6.0.8
dotnet add package System.Net.Http.Json --version 6.0.0

MySql.EntityFrameworkCore
  2.  
dotnet add package Microsoft.EntityFrameworkCore --version 6.0.8
dotnet add package MySql.EntityFrameworkCore --version 6.0.0
dotnet add package System.Net.Http.Json --version 6.0.0

7. 在data文件夹下创建上下文内容
  1. PersonContext.cs
using Microsoft.EntityFrameworkCore;
using BlazorTestStu.Model;
namespace BlazorTestStu.Data;

public class PersonContext : DbContext
{
    public PersonContext(DbContextOptions options) : base(options)//warning
    {
    }

    public DbSet<Person> Persons { get; set; }
}
8. 继续配置controller控制器
  1. PersonsController.cs
using BlazorTestStu.Data;
using BlazorTestStu.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace BlazorTestStu.Controllers;

[Route("Person")]//这里有个问题在之后修复了
[ApiController]
public class PersonsController : Controller
{
    private readonly PersonContext _db;

    public PersonsController(PersonContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<Person>>> GetSpecials()
    {
        return (await _db.Persons.ToListAsync()).OrderByDescending(p => p.Id).ToList();
    }
}
  2. 
9. 创建完善seed文件
  1. seed.cs
namespace BlazorTestStu.Data;
using BlazorTestStu.Model;
public static class SeedData
{
    public static void Initialize(PersonContext db)
    {
        var persons = new Person[]
        {
            new Person()
            {
                Name = "Basic Cheese Pizza",
                Detail = "It's cheesy and delicious. Why wouldn't you want one?",
                DepetmentId = 999,
                
            },
            new Person()
            {
                Id = 2,
                Name = "The Baconatorizor",
                Detail = "It has EVERY kind of bacon",
                DepetmentId = 1199,
                
            },
            new Person()
            {
                Id = 3,
                Name = "Classic pepperoni",
                Detail = "It's the pizza you grew up with, but Blazing hot!",
                DepetmentId = 1050,
                
            },
            new Person()
            {
                Id = 4,
                Name = "Buffalo chicken",
                Detail = "Spicy chicken, hot sauce and bleu cheese, guaranteed to warm you up",
                DepetmentId = 1275,
                
            },
            new Person()
            {
                Id = 5,
                Name = "Mushroom Lovers",
                Detail = "It has mushrooms. Isn't that obvious?",
                DepetmentId = 1100,
                
            },
            new Person()
            {
                Id = 7,
                Name = "Veggie Delight",
                Detail = "It's like salad, but on a pizza",
                DepetmentId = 1150,
                
            },
            new Person()
            {
                Id = 8,
                Name = "Margherita",
                Detail = "Traditional Italian pizza with tomatoes and basil",
                DepetmentId = 999,
                
            },
        };
        db.Persons.AddRange(persons);
        db.SaveChanges();
    }
}
10. 配置连接字符串
  1. https://blog.csdn.net/wqq1027/article/details/127310447
 {
  "ConnectionStrings": {
    "MySql":"server=localhost;user id=root;password=123456;port=3306;database=BlazorTestPerson"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}

11. 在program中server注册seed服务
  1. 练习 - 从 Blazor 组件访问数据 - Training
 using BlazingPizza.Data;
 ...
 using Microsoft.EntityFrameworkCore;
 ...
 
 var builder = WebApplication.CreateBuilder(args);
 
 ...
 builder.Services.AddDbContext<PersonContext>(opt =>
    {
        opt.UseMySQL(builder.Configuration.GetConnectionString("MySql"));
    });
 ...
 
 // Initialize the database
var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PersonContext>();
    if (db.Database.EnsureCreated())
    {
        SeedData.Initialize(db);
    }
}
 
 ...
  1. migration?
    1. 直接run就可以创建库
12. 创建视图组件
  1. person查找验证
    1. shared/PersonSearch.razor
@using BlazorTestStu.Model; 

@inject HttpClient HttpClient
@inject NavigationManager NavigationManager

<div class="main">
  <h1>Blazing Person</h1>
  <ul class="person-cards">
    @if (persons != null)
    {
      @foreach (var person in persons)
      {
        //<li @onclick="@(() => OrderState.ShowConfigurePizzaDialog(special))" style="background-image: url('@special.ImageUrl')">  
        //</li>
        <input type="checkbox"/>
          <div class="pizza-info">
                <span class="title">@person.Name</span>
                  @person.Detail
                <span class="price">@person.DepetmentId</span>
          </div>
      }
    }
  </ul>
</div>

@code{
    List<Person> persons = new();
    //public Person[] persons;
    protected override async Task OnInitializedAsync()
    {
    persons = await HttpClient.GetFromJsonAsync<List<Person>>(NavigationManager.BaseUri + "persons");
    }

}
    2. Bug fix 
      1. 上个31行代码
persons = await HttpClient.GetFromJsonAsync<List<Person>>(NavigationManager.BaseUri + "persons");
      2. 而controller/PersonsController.cs
[Route("Person")]//这里有个问题
      3. 修复为
 [Route("Persons")]//修复
      4. 
    3. 在对应界面引用
<PersonSearch /> 
    4. 想使用boostrap美化一下，发现没法提示class中的类型
      1. how to add Intellisense to Visual Studio Code for bootstrap
      2. 有一个小问题，不知道lambda表达式有没有提示
      3. 
  2. CRUD
    1. Create
      1.  使用dialog单独界面 尽量不用上单独的界面
      2. Id name detail did
    2. Read
      1. 想要使用可以选择依旧类型的搜索功能
设想

drop list
    id name departmentid
    \\like detail
input field
btn "search"
 
      2. Sort
      3. 
    3. Update
      1. 感觉可以使用类似create的界面
      2. 但是要自动填充值
      3. 批量修改 复选框选择
    4. Delete
      1. 确定权限？
      2. 
    5. 需要了解数据流动的过程
      1. App 里面设定 练习 - 使用 @page 指令更改 Blazor 应用中的导航 - Training
      2. Context
      3.  
bool isSubmitting;

async Task PlaceOrder()
{
    isSubmitting = true;
    var response = await HttpClient.PostAsJsonAsync(NavigationManager.BaseUri + "orders", OrderState.Order);
    var newOrderId= await response.Content.ReadFromJsonAsync<int>();
    OrderState.ResetOrder();
    NavigationManager.NavigateTo("/");
}
      4.  
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazingPizza;

[Route("orders")]
[ApiController]
public class OrdersController : Controller
{
    private readonly PizzaStoreContext _db;

    public OrdersController(PizzaStoreContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<OrderWithStatus>>> GetOrders()
    {
        var orders = await _db.Orders
             .Include(o => o.Pizzas).ThenInclude(p => p.Special)
             .Include(o => o.Pizzas).ThenInclude(p => p.Toppings).ThenInclude(t => t.Topping)
             .OrderByDescending(o => o.CreatedTime)
             .ToListAsync();

        return orders.Select(o => OrderWithStatus.FromOrder(o)).ToList();
    }

    [HttpPost]
    public async Task<ActionResult<int>> PlaceOrder(Order order)
    {
        order.CreatedTime = DateTime.Now;

        // Enforce existence of Pizza.SpecialId and Topping.ToppingId
        // in the database - prevent the submitter from making up
        // new specials and toppings
        foreach (var pizza in order.Pizzas)
        {
            pizza.SpecialId = pizza.Special.Id;
            pizza.Special = null;
        }

        _db.Orders.Attach(order);
        await _db.SaveChangesAsync();

        return order.OrderId;
    }
}
      5.  上述代码允许应用获取所有当前订单并下订单。 [Route("orders")] Blazor 属性允许此类处理对 /orders 和 /orders/{orderId} 的传入 HTTP 请求。
      6. MyOrder.razor
...
@code {
    List<OrderWithStatus> ordersWithStatus = new List<OrderWithStatus>();

    protected override async Task OnParametersSetAsync()
    {
      ordersWithStatus = await HttpClient.GetFromJsonAsync<List<OrderWithStatus>>(
          $"{NavigationManager.BaseUri}orders");
    }
} 
      7.  
@inject HttpClient HttpClient
@inject NavigationManager NavigationManager
      8.  
    6. 尝试复述过程
      1. 使用input标签输入/输入
      2. 接受到模型实例
      3. 通过post方法传输给控制器
      4. 控制器对实例操作
      5. 控制器保存状态到数据库
      6. 返回给界面提示/输出内容
      7. 
    7. 更新组件
      1. update实现方案一
        1. 在每一个行后放入按钮(缺点是素材冗余）
        2. 按下触发弹窗
        3. 弹窗修改提交更新
      2. 方案二
        1. 每行放入单/多选框 或者选择行变色，选择
        2. 在标题放‘修改’按钮，
          1. 当修改点击后判断是否选择
          2. 选择后弹窗修改
          3. 修改更新
      3. 优化选择器
    8. delete实现
    9. 布局优化
13.  创建窗口
  1. 创建窗口类模型
  2. 优化一下httpget方法，太烂了
  3. 明确id的情况下却要给出list person
  4. 让显示全部和显示单一的区分开来
14. 重要教程
using var context = new BlogsContext();

var blog = context.Blogs.Include(e => e.Posts).First(e => e.Name == ".NET Blog");

// Modify property values
blog.Name = ".NET Blog (Updated!)";

// Insert a new Post
blog.Posts.Add(
    new Post
    {
        Title = "What’s next for System.Text.Json?", Content = ".NET 5.0 was released recently and has come with many..."
    });

// Mark an existing Post as Deleted
var postToDelete = blog.Posts.Single(e => e.Title == "Announcing F# 5");
context.Remove(postToDelete);

context.ChangeTracker.DetectChanges();
Console.WriteLine(context.ChangeTracker.DebugView.LongView);

context.SaveChanges();
  1. 更改跟踪 - EF Core
  2.  开局调用search时会刷新一下
  3. update后使用刷新
可行性分析
如上验证中
需求分析
参考文献
1. 