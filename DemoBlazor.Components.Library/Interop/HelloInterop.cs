using Microsoft.JSInterop;

namespace DemoBlazor.Components.Library.Interop;

public class HelloInterop: IDisposable
{
    private readonly IJSRuntime jSRuntime;
    private DotNetObjectReference<HelloHelper>? helloHelperReference;

    public HelloInterop(IJSRuntime jSRuntime)
    {
        this.jSRuntime = jSRuntime;
    }

    public async Task CallSayHello(string name)
    {
        var helloHelper = new HelloHelper(name);
        helloHelperReference = DotNetObjectReference.Create(helloHelper);
        await jSRuntime.InvokeVoidAsync("sayHello", helloHelperReference);
    }

    public void Dispose()
    {
        helloHelperReference?.Dispose();
    }
}
