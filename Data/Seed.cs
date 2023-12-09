namespace test_7.Data;

using System.Collections.Generic;
using test_7.Model;
using static test_7.Model.StateType;
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

        Class clazz1 = new(){
            Id=1,
            Name="编程班",
            //Date=DateTime.Now.AddDays(3)
            Date="星期二",
        };
   
        Class clazz2 = new(){
            Id=2,
            Name="无人机班",
            Date="星期天",//如何拼接两段时间对象，日期和时间
        };
        
        
        
        //par.Persons.Add(person7,person8);
        par.Persons.AddRange(parents);
        tch.Persons.AddRange(teachers);
        stu.Persons.AddRange(stus);

        clazz1.Teachers.Add(teacher1);
        clazz1.Students.Add(stu3);
        clazz1.Students.Add(stu2);

        clazz2.Teachers.Add(teacher2);
        clazz2.Students.Add(stu1);
        clazz2.Students.Add(stu2);



        //db.Persons.AddRange(person);
        db.Departments.AddRange(par,stu,tch);
        db.Clazzs.AddRange(clazz1,clazz2);


        Course course1=new(){
            Id=1,
            CurrentClazz=clazz1,
            Level="1A-1",
            Time=new DateTime(2710,12,9,14,00,00),
            State=Teached,
            PresentStudents=clazz1.Students,
        };


        Course course2=new(){
            Id=2,
            Level="1A-2",
            CurrentClazz=clazz1,
            Time=new DateTime(2710,12,9,14,00,00).AddDays(7),
            State=Teaching,
            //PresentStudents=clazz1.Students,
        };
        //未到
        course2.PresentStudents.AddRange(clazz1.Students);
        course2.PresentStudents.Remove(stu3);

        //没到
        Course course3=new(){
            Id=3,
            Level="1A-3",
            CurrentClazz=clazz1,
            Time=new DateTime(2710,12,9,14,00,00).AddDays(7*2),
            State=Opening,
        };

        Course course0=new(){
            Id=4,
            Level="2B-5",
            CurrentClazz=clazz2,
            Time=new DateTime(2023,12,9,14,00,00),
            State=Teached,
            PresentStudents=clazz2.Students,
        };

        db.Courses.AddRange(course0,course1,course2,course3);

        db.SaveChanges();
    }
}