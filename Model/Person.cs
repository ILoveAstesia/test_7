
namespace test_7.Model;

public class  Person
{
    public int Id  {set;get;}
    //public String Password {set;get;} = "" ;
    public String? Name {set;get;}
    //public int DepartmentId  {set;get;}
    public List<Department> Departments { get;set; } = [];
    //bool Logined =false;

}

