using DemoBlazor.Models;
using Microsoft.JSInterop;

namespace DemoBlazor.Components.Library.Interop;

public class HelloInterop: IDisposable
{
    private readonly IJSRuntime jSRuntime;
    private DotNetObjectReference<HelloHelper>? helloHelperReference;
    private readonly Lazy<Task<IJSObjectReference>> moduleTask;

    public HelloInterop(IJSRuntime jSRuntime)
    {
        this.jSRuntime = jSRuntime;
        moduleTask = new(() => jSRuntime.InvokeAsync<IJSObjectReference>(
           "import", "./_content/DemoBlazor.Components.Library/index.js").AsTask());

    }

    public async Task CallSayHello(string name)
    {
        var helloHelper = new HelloHelper(name);
        helloHelperReference = DotNetObjectReference.Create(helloHelper);

        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("sayHello",helloHelperReference);

    }

    public void Dispose()
    {
        helloHelperReference?.Dispose();
    }
}
