using System.ComponentModel.DataAnnotations;

namespace test_7.Model;

public class DepartmentPerson{
    public int Id{get;set;}
    public int PersonId {get;set;}

    public int DepartmentId {get;set;}
}