using System.ComponentModel.DataAnnotations.Schema;

namespace test_7.Model;

public class Department{
    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    public int Id {set;get;}
    public String? Name {set;get;}
    public List<Person> Persons { get;set; } = new();
}