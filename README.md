![Icon](https://raw.github.com/SimonCropp/HandlerOrdering/master/Icons/package_icon.png)


HandlerOrdering
===============

Allows a more expressive way to order [NServiceBus](http://particular.net/NServiceBus) handlers.


## NuGet

http://nuget.org/packages/HandlerOrdering/ [![NuGet Status](http://img.shields.io/nuget/v/HandlerOrdering.svg?style=flat)](https://www.nuget.org/packages/HandlerOrdering/)

    PM> Install-Package HandlerOrdering


## Usage 

```
endpointConfiguration.ApplyInterfaceHandlerOrdering();
```


## Existing approach

The current approach to ordering handlers can be seen at [Handler Ordering](https://docs.particular.net/nservicebus/handlers/handler-ordering).

For example:


```
endpointConfiguration.ExecuteTheseHandlersFirst(typeof(HandlerB), typeof(HandlerA), typeof(HandlerC));
```


## Alternative approach

The above approaches can sometimes results in hard to read code, especially when the number of handlers increases. Also sometimes the full expression of order is not important. Rather it is important that a given handler is executed after some other handler(s).

So this project supports an interface syntax that allows specifying order by adding an a `IWantToRunAfter<THandler>` to  handler(s). For example.

```
public class HandlerA :
        IWantToRunAfter<HandlerC>
{
}

public class HandlerB :
        IWantToRunAfter<HandlerA>, 
        IWantToRunAfter<HandlerC>
{
}

public class HandlerC
{
}
```

And the order will be derived by these dependencies.


## Icon

Icon courtesy of [The Noun Project](http://thenounproject.com)