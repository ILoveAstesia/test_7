namespace ehrms.Model;

public class Training{
    public int Id { get; set;}
    public string Name { get; set;}="";
    public string Description { get; set;}="";
    public DateTime StarTime{ get; set;}// = new DateTime();
    public DateTime EndTime{ get; set;}
}