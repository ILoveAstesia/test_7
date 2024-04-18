namespace ehrms.Model;
public class Performance{
    public int Id { get; set; }
    //public string Name { get; set; }
    public int EmployeeId { get; set; }
    public string Evaluation { get; set; }="";
    public string Rating { get; set; }="";
}