namespace ehrms.Model;

public class Department{
    public int Id {get;set;}
    public string Name {get;set;} = "无名称";
    public string Description {get;set;}="无描述";
    public int ParentDepartmentID {get;set;}
    public int DepartmentSize{get;set;}
    public int ManagerID{get;set;}
    public DateTime CreationDate{get;set;}
    public List<Employee>? Employees {get;set;}
}