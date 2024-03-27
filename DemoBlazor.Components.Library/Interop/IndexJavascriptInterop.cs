using Microsoft.JSInterop;

namespace DemoBlazor.Components.Library.Interop;

public class IndexJavascriptInterop
{
    private readonly IJSRuntime jSRuntime;
    private readonly Lazy<Task<IJSObjectReference>> moduleTask;

    public IndexJavascriptInterop(IJSRuntime jSRuntime)
    {
        this.jSRuntime = jSRuntime;
        moduleTask = new(() => jSRuntime.InvokeAsync<IJSObjectReference>(
           "import", "./_content/DemoBlazor.Components.Library/index.js").AsTask());
    }

    public async ValueTask<int> Sum(int a, int b)
    {
        var module = await moduleTask.Value;
       return await module.InvokeAsync<int>("sum", a, b);
    }

    public async ValueTask<int> Square(int a)
    {
        var module = await moduleTask.Value;
       return await module.InvokeAsync<int>("square", a);
    }

    public async Task DoSomething()
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("doSomething");
    }

}
