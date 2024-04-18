using System.Data.SqlTypes;
//using annotation
namespace ehrms.Model;
public class Payroll{
    public int Id { get; set;}
    public double MoneyShould{ get; set;}
    //[money]
    public double MoneyPaid{ get; set;}
    public int EmployeeId{ get; set;}
    public DateTime PayDate{get; set;}

}
//https://www.bing.com/search?q=%E4%BB%80%E4%B9%88%E6%98%AF+Microsoft+Copilot%3F&showconv=1&ntref=1&filters=wholepagesharingscenario%3A%22Conversation%22&shareId=ffc61e0a-b88c-480b-b851-f2c10c7fcf47&shtc=0&shsc=Codex_ConversationMode&form=EX0050&shid=82e27b62-8d25-4169-9041-e628d5362998&shtp=GetUrl&shtk=5a%2B55LqO6Jaq6LWEIOW6lOivpeWMheWQq%2BS7gOS5iOWtl%2BautQ%3D%3D&shdk=5LiL6Z2i5piv5oiR5L2%2F55SoIE1pY3Jvc29mdCBDb3BpbG90ICjlhajnkIPpppbkuKogQUnmlK%2FmjIHnmoTlupTnrZTlvJXmk44p55Sf5oiQ55qE562U5qGI44CC6YCJ5oup5Lul5p%2Bl55yL5a6M5pW0562U5qGI5oiW6Ieq6KGM5bCd6K%2BV44CC&shhk=EkSleeNaWD676hQzbofLecZ3oolcHXy2owjLLP5zNlU%3D&shth=OBFB.73FF6ADE8CC93B6ED1EDA1CE557E2E09