

namespace ehrms.Model;

public class Employee 
{
    public int Id { set; get; }
    public string Name { set; get; }="未上传姓名";
    public string Gender{get; set;}="男";

    public string? Password { set; get; } 
    //bool Logined =false;
    //public List<SignLog> SignLogs { get; set; } = [];
    public int Level_right { get; set; } = 0;
    public Department? Department { set; get; } 
    public List<Declaration>? Declarations { set; get; } 

}

//https://www.bing.com/search?q=%E4%BB%80%E4%B9%88%E6%98%AF+Microsoft+Copilot%3F&showconv=1&ntref=1&filters=wholepagesharingscenario%3A%22Conversation%22&shareId=486bd35a-3587-4f34-81d9-ce1832f1cef9&shtc=0&shsc=Codex_ConversationMode&form=EX0050&shid=82e27b62-8d25-4169-9041-e628d5362998&shtp=GetUrl&shtk=5a%2B55LqO5ZGY5bel6ZyA6KaB5LuA5LmI5a2X5q61&shdk=5LiL6Z2i5piv5oiR5L2%2F55SoIE1pY3Jvc29mdCBDb3BpbG90ICjlhajnkIPpppbkuKogQUnmlK%2FmjIHnmoTlupTnrZTlvJXmk44p55Sf5oiQ55qE562U5qGI44CC6YCJ5oup5Lul5p%2Bl55yL5a6M5pW0562U5qGI5oiW6Ieq6KGM5bCd6K%2BV44CC&shhk=aaQMREgu%2Fhsc4lua8jTKQZYX1kfPNBtzjI5Gjpi5%2BLE%3D&shth=OBFB.73FF6ADE8CC93B6ED1EDA1CE557E2E09