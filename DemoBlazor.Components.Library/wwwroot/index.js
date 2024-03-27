export function helloWorld()  { console.log("Hello") };

export function sum(a, b)  { return a + b; };

export function square(a)  { return a * a; };

export function doSomething()  {
    var myString = DotNet.invokeMethod('DemoBlazor.Components.Library', 'MetodoDotNet');
    console.log(myString);

    DotNet.invokeMethodAsync('DemoBlazor.Components.Library', 'RestituisciArrayAsync')
        .then(data => { console.log(data) });
       
}


export function sayHello(dotnetHelper)  {
    dotnetHelper.invokeMethodAsync('SayHello')
        .then(message => { console.log(message) });
}