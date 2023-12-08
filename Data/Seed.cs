namespace test_7.Data;
using test_7.Model;
public static class SeedData
{
    public static void Initialize(test_7Context db)
    {

        var a = new Department(){
            Id=1000,
            Name="Pizza",
        };

        var b = new Department(){
            Id=1001,
            Name="Cola",
        };

        var c =new Department(){
            Id=0001,
            Name="Food",
        };


        var person = new Person(){
            Id=1,
            Name = "Basic Cheese Pizza",
            //Detail = "It's cheesy and delicious. Why wouldn't you want one?",
            

        };
        person.Departments.Add(a);

        db.Persons.AddRange(person);
        db.Departments.AddRange(a,b,c);
        db.SaveChanges();
    }
}