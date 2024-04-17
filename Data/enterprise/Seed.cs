
//using System.Collections.Generic;
using ehrms.Model;
using static ehrms.Model.StateType;
namespace ehrms.Data;
public static class EhrmsSeedData
{
    public static void Initialize(EhrmsContext db)
    {

        var dept1 = new Department()
        {
            Id = 1000,
            Name = "人事",
        };
        var dept2 = new Department()
        {
            Id = 2000,
            Name = "策划",
        };
        var dept3 = new Department()
        {
            Id = 3000,
            Name = "研发",
        };
        var dept4 = new Department()
        {
            Id = 4000,
            Name = "营销",
            
        };

        //db.Persons.AddRange(admin,SuperAdmin);
        //db.Accountinfos.AddRange(accountinfoSuperAdmin,accountinfo0,accountinfo1,accountinfo2,accountinfo3);
        //db.Accountinfos.AddRange(accountinfoSuperAdmin,accountinfo0,accountinfo1);

        db.SaveChanges();
    }
}