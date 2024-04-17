namespace test_7.Model;

public class  Student : Person
{
    public List<Class> ClazzsStudedIn { get;set; } = [];
    public List<Course> PresentCourses{get;set;}=[];
    public int CourseTimes {get;set;}=0;

    public int TakeACourse(){
        return CourseTimes--;
    }

}

