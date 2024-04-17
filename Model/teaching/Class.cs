
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace test_7.Model;

public class Class{
    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    public int Id {set;get;}
    public String Name {set;get;}="there is no name";// name must be force to write ,but if some teacher have own course it may make mistakes bugs
    //[InverseProperty("Clazzs")]
    public List<Student> Students { get;set; } = [];
    //[ForeignKey("ClassId_Teachers")]
    public List<Teacher> Teachers { get;set; } = [];
    public List<Course> PlanedCourse{get;set;}=[];
    public String Date { get;set; } ="";
    //public time
    public String? Location { get;set; }="";
    // public DateTime SetDateTimeToNow(){
    //     Date=DateTime.Now;
    //     return DateTime.Now;
    // }

} 