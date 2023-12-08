namespace test_7.Data;

using System.Collections.Generic;
using test_7.Model;
public static class SeedData
{
    public static void Initialize(test_7Context db)
    {

        var par = new Department(){
            Id=1000,
            Name="家长",
        };

        var stu = new Department(){
            Id=1001,
            Name="学生",
        };

        var tch =new Department(){
            Id=0001,
            Name="老师",
        };

        var teacher1 = new Teacher(){
            Id=1,
            Name = "刘",
            };

        var teacher2 = new Teacher(){
            Id=2,
            Name = "徐",
            };

        var teacher3 = new Teacher(){
            Id=3,
            Name = "罗",
            };

        var stu1 = new Student(){
            Id=4,
            Name = "可乐",
            };

        var stu2 = new Student(){
            Id=5,
            Name = "桃桃",
            };

        var stu3 = new Student(){
            Id=6,
            Name = "洋洋",
            };

        var par1 = new Person(){
            Id=7,
            Name = "可乐妈",
            };

        var par2 = new Person(){
            Id=8,
            Name = "可乐爸",
        };

        //List<Person> parl=person7,person8;

        Teacher[] teachers=[
            teacher1,
            teacher2,
            teacher3,
        ];

        Person[] parents=[
            par1,
            par2,
        ];

        Student[] stus=[
            stu1,
            stu2,
            stu3,
        ];


        //par.Persons.Add(person7,person8);
        par.Persons.AddRange(parents);
        tch.Persons.AddRange(teachers);
        stu.Persons.AddRange(stus);

        //db.Persons.AddRange(person);
        db.Departments.AddRange(par,stu,tch);

        Class clazz1 = new(){
            Id=1,
            Name="慧编程 1a-1",
            //Date=DateTime.Now.AddDays(3)
            Date=new DateTime(2023,12,8,16,30,00),
        };
        clazz1.Teachers.Add(teacher1);
        clazz1.Students.Add(stu3);
        clazz1.Students.Add(stu2);

        Class clazz2 = new(){
            Id=2,
            Name="大疆特洛 2b-1",
            Date=DateTime.Now.AddDays(-2),//如何拼接两段时间对象，日期和时间
        };
        clazz2.Teachers.Add(teacher2);
        clazz2.Students.Add(stu1);
        clazz2.Students.Add(stu2);

        db.Clazzs.AddRange(clazz1,clazz2);

        db.SaveChanges();
    }
}