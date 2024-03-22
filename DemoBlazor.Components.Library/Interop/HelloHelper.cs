using Microsoft.JSInterop;

namespace DemoBlazor.Components.Library.Interop;

public class HelloHelper
{
    public HelloHelper(string name)
    {
        Name = name;
    }

    public string Name { get; set; }

    [JSInvokable]
    public string SayHello()
    {
        return $"Hello, {Name}!";
    }

}
