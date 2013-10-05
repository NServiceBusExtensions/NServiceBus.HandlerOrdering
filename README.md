HandlerOrdering
===============

Allows a more expressive way to order [NServiceBus](http://nservicebus.com/) handlers.


## Nuget

There are two nuget packages

### The [binary version](http://nuget.org/packages/HandlerOrdering/)

This uses the standard approach to constructing a nuget package. It contains a dll which will be added as a reference to your project. You then deploy the binary with your project.

    PM> Install-Package HandlerOrdering

### The [code only version](http://nuget.org/packages/HandlerOrdering-CodeOnly/)

This is a "code only" package that leverages the [Content Convention](http://docs.nuget.org/docs/creating-packages/creating-and-publishing-a-package#From_a_convention_based_working_directory) of Nuget to inject code files into your project. Note that this is only compatible with C# projects. 

The benefits of this approach are ease of debugging and less files to deploy

    PM> Install-Package HandlerOrdering-CodeOnly

## Existing approach

The current approach to ordering handlers is using [ISpecifyMessageHandlerOrdering](http://support.nservicebus.com/customer/portal/articles/862397-how-do-i-specify-the-order-in-which-handlers-are-invoked)


    public class EndpointConfig : ISpecifyMessageHandlerOrdering
    {
        public void SpecifyOrder(Order order)
        {
            order.Specify(First<HandlerC>.Then<HandlerA>().AndThen<HandlerB>());
        }
    }

## Alternative approach

This sometimes results in hard to read code, especially when the number of handlers increases. Also sometimes the full expression of order is not important. Rather it is important that a given handler is executed after some other handler(s).

So this project supports an interface syntax that allows specifying order by adding an a `IWantToRunAfter<THandler>` to  handler(s). For example.

    public class HandlerA : IWantToRunAfter<HandlerC>
    {
    }

    public class HandlerB : IWantToRunAfter<HandlerA>, IWantToRunAfter<HandlerC>
    {
    }

    public class HandlerC
    {
    }

And the order will be derived by these dependencies.

## Icon

Icon courtesy of [The Noun Project](http://thenounproject.com)



 

