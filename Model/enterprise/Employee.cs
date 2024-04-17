

namespace ehrms.Model;

public class Employee 
{
    public int Id { set; get; }
    public string Password { set; get; } = "";
    //bool Logined =false;
    //public List<SignLog> SignLogs { get; set; } = [];
    public int Level_right { get; set; } = 0;
    public Department Department { set; get; } = new Department();

}

