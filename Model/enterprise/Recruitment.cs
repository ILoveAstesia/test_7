namespace ehrms.Model;
public class Recruitment{
    public int Id { get; set;}  
    //意向部门
    public Department? Department{ get; set; }
    //工作期望
    public string Demand { get; set; }="";
    //薪资欲望DemandSalaryNumber
    public int DemandNumber { get; set; }=0;
    public StateType State { get; set;}
}
// public enum StateType
// {
//     Closed,
//     Opening,
//     Operating,
//     Operatied,
//     Delayed,

// }