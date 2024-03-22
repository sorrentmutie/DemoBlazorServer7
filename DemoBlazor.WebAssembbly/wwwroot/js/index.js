window.helloWorld = () => { console.log("Hello") };

window.sum = (a, b) => { return a + b; };

window.square = (a) => { return a * a; };

window.doSomething = () => {
    var myString = DotNet.invokeMethod('DemoBlazor.Components.Library', 'MetodoDotNet');
    console.log(myString);

    DotNet.invokeMethodAsync('DemoBlazor.Components.Library', 'RestituisciArrayAsync')
        .then(data => { console.log(data) });
       
}


window.sayHello = (dotnetHelper) => {
    dotnetHelper.invokeMethodAsync('SayHello')
        .then(message => { console.log(message) });
}