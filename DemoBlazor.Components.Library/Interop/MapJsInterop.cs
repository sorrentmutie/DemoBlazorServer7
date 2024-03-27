using DemoBlazor.Models;
using Microsoft.JSInterop;

namespace DemoBlazor.Components.Library;

// This class provides an example of how JavaScript functionality can be wrapped
// in a .NET class for easy consumption. The associated JavaScript module is
// loaded on demand when first needed.
//
// This class can be registered as scoped DI service and then injected into Blazor
// components for use.

public class MapJsInterop : IAsyncDisposable
{
    private readonly Lazy<Task<IJSObjectReference>> moduleTask;

    public MapJsInterop(IJSRuntime jsRuntime)
    {
        moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/DemoBlazor.Components.Library/map.js").AsTask());

    }

    public async ValueTask ShowMap(MapSettings mapSettings)
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("showMap", mapSettings);
    }

    public async ValueTask DisposeAsync()
    {
        if (moduleTask.IsValueCreated)
        {
            var module = await moduleTask.Value;
            await module.DisposeAsync();
        }
    }
}
