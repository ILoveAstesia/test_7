namespace ehrms.Model;
public class Recruitment{
    public int Id { get; set;}  
    public Department? Department{ get; set; }
    public string Demand { get; set; }="";
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