using DemoBlazor.Models;
using Microsoft.JSInterop;

namespace DemoBlazor.Components.Library
{
    // This class provides an example of how JavaScript functionality can be wrapped
    // in a .NET class for easy consumption. The associated JavaScript module is
    // loaded on demand when first needed.
    //
    // This class can be registered as scoped DI service and then injected into Blazor
    // components for use.

    public class ModalJsInterop : IAsyncDisposable
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask;

        public ModalJsInterop(IJSRuntime jsRuntime)
        {
            moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./_content/DemoBlazor.Components.Library/modal.js").AsTask());
        }

        public async ValueTask ShowModal(string id)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("showModal", id);
        }

        public async ValueTask HideModal()
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("hideModal");
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
}
