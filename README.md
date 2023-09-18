Sample project for the issue [#37](https://github.com/jsakamoto/BlazorWasmPreRendering.Build/issues/37) in BlazorWasmPreRendering.Build.

Steps:

* Create a new Blazor WebAssembly App using the template in Visual Studio
* Add package BlazorWasmPreRendering.Build (3.1.0-preview.3)
* Add package SpawnDev.BlazorJS.WebWorkers (2.2.8)
* Extract ConfigureServices in program.cs according to BlazorWasmPreRendering docs
* Register SpawnDev.BlazorJS.WebWorkers services in program.cs
* Add an example worker (IMyWorker.cs, MyWorker.cs)
* Inject WebWorkerService to Counter.razor
* Change IncrementCount() to use the web worker:

```csharp
private async void IncrementCount()
{
    //currentCount++;
    using var webWorker = await WorkerService.GetWebWorker();
    var myWorker = webWorker.GetService<IMyWorker>();
    var result = await myWorker.Add(currentCount, 1);
}
```

* Start the app, and press the Click Me button on the Counter page
* `BlazorWasmPreRendering.Build.lib.module.js` throws an exception when the worker starts, because the DOM is not available in web workers:

```
MONO_WASM: Failed to invoke 'afterStarted' on library initializer '../_content/BlazorWasmPreRendering.Build/BlazorWasmPreRendering.Build.lib.module.js': TypeError: n.createNodeIterator is not a function
```
