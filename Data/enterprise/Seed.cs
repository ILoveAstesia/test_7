
//using System.Collections.Generic;
using ehrms.Model;
using static ehrms.Model.StateType;
namespace ehrms.Data;
public static class EhrmsSeedData
{
    public static void Initialize(EhrmsContext db)
    {
        var dept0 = new Department()
        {
            Id = 1000,
            Name = "董事",
            Description= @"
            董事是对内掌管公司事务、对外代表公司经营决策和业务执行的机构。
            主要职责包括召开会议、向股东汇报工作、制定计划并落实执行1。
            ",
            DepartmentSize=15,
            ParentDepartmentID=1000,
            ManagerID=1000,
            CreationDate=DateTime.Now,
            Employees=[],
        };

        var dept1 = new Department()
        {
            Id = 1001,
            Name = "人事",
            Description= @"
            人事部门负责制定、建立公司的人力资源管理体系，完善人力资源管理制度及流程。
            具体职责包括机构设置、招聘计划、员工培训、薪酬绩效管理、劳动合同管理等2。
            ",
            DepartmentSize=15,
            ParentDepartmentID=1000,
            ManagerID=1001,
            CreationDate=DateTime.Now,
            Employees=[],
        };
        var dept2 = new Department()
        {
            Id = 2000,
            Name = "策划",            
            Description=@"
            策划部门是一个至关重要的部门，负责制定战略、规划和实施方案，以确保组织的成功。
            工作内容涉及市场研究、策略制定、项目策划、预算分配、团队管理和危机处理等3。
            ",

            DepartmentSize=15,
            ParentDepartmentID=1000,
            ManagerID=2001,
            CreationDate=DateTime.Now,
            Employees=[],
        };
        var dept3 = new Department()
        {
            Id = 3000,
            Name = "研发",            
            Description= @"
            研发部门将策划与销售的承诺兑现。
            ",
            DepartmentSize=50,
            ParentDepartmentID=1000,
            ManagerID=3001,
            CreationDate=DateTime.Now,
            Employees=[],
        };

        var dept4 = new Department()
        {
            Id = 4000,            
            Description= @"
            营销部门负责制定和执行公司的市场推广策略，以促进销售和提高品牌知名度。
主要职责包括市场研究、品牌管理、活动策划、直客业务开发等4。
            ",
            DepartmentSize=30,
            ParentDepartmentID=1000,
            ManagerID=4001,
            CreationDate=DateTime.Now,
            Name = "营销",
            Employees=[],
        };

        var Emp0 = new Employee(){
            Id = 1000,
            Name="樊志安",
            Gender="男",
            Password="fza1000",
            Level_right=3,
            Department=dept0,
            Declarations=[],
            Payrolls=[],
        };
//1 normal, 2 manager, 3 admin
        var Emp1 = new Employee(){
            Id = 1001,
            Name="刘勤",
            Gender="男",
            Password="lq1001",
            Level_right=2,
            Department=dept1,
            Declarations=[],
            Payrolls=[],
        };
        var Emp2 = new Employee(){
            Id = 2001,
            Name="罗维",
            Gender="男",
            Password="lw2001",
            Level_right=2,
            Department=dept2,
            Declarations=[],
        };
        var Emp3 = new Employee(){
            Id = 3001,
            Name="林英明",
            Gender="男",
            Password="lym3001",
            Level_right=2,
            Department=dept3,
            Declarations=[],
        };
        var Emp4 = new Employee(){
            Id = 4001,
            Name="徐昌昆",
            Gender="男",
            Password="xck4001",
            Level_right=2,
            Department=dept4,
            Declarations=[],
        };

        var Emp5 = new Employee(){
            Id = 4002,
            Name="徐昌昆2",
            Gender="男",
            Password="xck4002",
            Level_right=2,
            Department=dept4,
            Declarations=[],
        };
        //dept0.Employees=[];
        dept0.Employees.Add(Emp0);
        dept1.Employees.Add(Emp1);
        dept2.Employees.Add(Emp2);
        dept3.Employees.Add(Emp3);
        dept4.Employees.Add(Emp4);
        dept4.Employees.Add(Emp5);

        

        var rng = new Random();

        var temperatureC = rng.Next(-20, 55);

        //db.Persons.AddRange(admin,SuperAdmin);
        //db.Accountinfos.AddRange(accountinfoSuperAdmin,accountinfo0,accountinfo1,accountinfo2,accountinfo3);
        //db.Accountinfos.AddRange(accountinfoSuperAdmin,accountinfo0,accountinfo1);

        var file = new Document{
            Id=1,
            Title="geometric-7719159.svg",
            Path="geometric-7719159.svg",
            PublishDate=new DateTime(2710, 12, 9, 14, 00, 00),
        };

        var dec0=new Declaration{
            Id=1,
            Title="有关添加和更新的bug",
            Description="无法更新数据库数据。",
            State=Opening,
        };

        Emp0.Declarations.Add(dec0);

        var pay0=new Payroll{
            Id=1,
            MoneyShould=6000.0,
            MoneyPaid=5400.0,
            EmployeeId=1000,
            PayDate=DateTime.Now,
        };

        var pay1=new Payroll{
            Id=2,
            MoneyShould=12000.0,
            MoneyPaid=14000.0,
            EmployeeId=1001,
            PayDate=DateTime.Now,
        };

        Emp0.Payrolls.Add(pay0);
        Emp1.Payrolls.Add(pay1);

        var perf0=new Performance{
            Id=1,
            EmployeeId=1000,
            Evaluation=@"
            绩效考核（performance examine），是企业绩效管理中的一个环节，是指考核主体对照工作目标和绩效标准，采用科学的考核方式，评定员工的工作任务完成情况、员工的工作职责履行程度和员工的发展情况，并且将评定结果反馈给员工的过程。常见绩效考核方法包括BSC、KPI及360度考核等。绩效考核是一项系统工程。绩效考核是绩效管理过程中的一种手段。
            ",
            Rating="好",
        };

        var rec0=new Recruitment{
            Id=1,
            Department=new(),
            Demand="喜欢写故事",
            DemandNumber=7000,
            State=Operating,
        };

        var rec1=new Recruitment{
            Id=2,
            Department=new(),
            Demand="技术能力强",
            DemandNumber=8000,
            State=Operating,
        };

        var rec2=new Recruitment{
            Id=3,
            Department=new(),
            Demand="急需用钱",
            DemandNumber=5000,
            State=Operatied,
        };

        rec0.Department=dept2;
        rec1.Department=dept3;
        rec2.Department=dept4;

        var train0= new Training{
            Id=1,
            Name="关于编程职业技能的课程",
            Description="",
            StarTime=new DateTime(2110, 12, 9, 14, 00, 00),
            EndTime=new DateTime(2710, 12, 9, 14, 00, 00),
        };

        db.Departments.AddRangeAsync(dept0,dept1,dept2,dept3,dept4);
        db.Documents.AddRangeAsync(file);
        db.Declarations.AddRangeAsync(dec0);
        db.Employees.AddRangeAsync(Emp0,Emp1,Emp2,Emp3,Emp4,Emp5);
        db.Payrolls.AddRangeAsync(pay0);
        db.Performances.AddRangeAsync(perf0);
        db.Recruitments.AddRangeAsync(rec0,rec1,rec2);
        db.Trainings.AddRangeAsync(train0);
        db.SaveChanges();
    }
}