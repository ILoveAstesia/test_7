using System.Data.SqlTypes;

namespace ehrms.Model;
public class Payroll{
    public int Id { get; set;}
    public SqlMoney MoneyLevel{ get; set;}
    public SqlMoney MoneyPaid{ get; set;}
    public int EmployeeId{ get; set;}

}