namespace ehrms.Model;
public class Declaration{
    public int Id { get; set;}
    public string Title { get; set;}="无标题";
    public string Description { get; set;}="无内容";
    public StateType State { get; set;}//=StateType.Opening;
}


public enum StateType
{
    Closed,
    Opening,
    Operating,
    Operatied,
    Delayed,

}