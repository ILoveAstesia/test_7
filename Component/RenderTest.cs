using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering; 

namespace test_7.Component;
public class RenderTest : ComponentBase{

    public RenderTest(){
        Console.WriteLine($"构造函数启动{nameof(RenderTest)}");
    }

    public override Task SetParametersAsync(ParameterView parameters)
    {
        Console.WriteLine($"{nameof(SetParametersAsync)}"+nameof(SetParametersAsync));
        return base.SetParametersAsync(parameters);
    }


}