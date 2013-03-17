HandlerOrdering
===============

Allows a more expressive way to order [NServiceBus](http://nservicebus.com/) handlers.

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

However I find this sometimes results in hard to read code, especially when the number of handlers increases. Also sometime I don't care about the actual order all the handler are run. I mostly care that a
given handler is executed after some other handler(s).

So I came up with this a `IWantToRunAfter<THandler>` syntax. It allows me to express handler dependencies

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

## Compatible versions

Works with NServicebus 3.3.5 and higher including the new pre-release versions of 4.0.

## Nuget

Here is the nuget package http://nuget.org/packages/HandlerOrdering/



