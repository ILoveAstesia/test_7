
namespace test_7.Model;

public class  Accountinfo
{
    public int Id  {set;get;}
    public String Password {set;get;} = "" ;
    bool Logined =false;
    public List<SignLog> SignLogs {get;set;}=[];

}

