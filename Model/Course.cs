
namespace test_7.Model;
// once
public enum StateType
{
    Closed,
    Opening,
    Teaching,
    Teached,
    Delayed,

}
public class Course {

    public int Id{get;set;}
    public String Level="";
    public Class CurrentClazz {get;set;} =new();
    public List<Student> PresentStudents {get;set;}=[];
    public DateTime Time{get;set;}
    //public String State="";
    public StateType State{get;set;}=StateType.Closed;


    
}
