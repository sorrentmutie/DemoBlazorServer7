using Microsoft.JSInterop;

namespace DemoBlazor.Components.Library.Interop;

public class IndexJavascriptInterop
{
    private readonly IJSRuntime jSRuntime;
    public IndexJavascriptInterop(IJSRuntime jSRuntime)
    {
        this.jSRuntime = jSRuntime;
    }

    public ValueTask<int> Sum(int a, int b)
    {
        return jSRuntime.InvokeAsync<int>("sum", a, b);
    }

    public ValueTask<int> Square(int a)
    {
        return jSRuntime.InvokeAsync<int>("square", a);
    }

    public async Task DoSomething()
    {
        await jSRuntime.InvokeVoidAsync("doSomething");
    }

}
