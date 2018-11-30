![Icon](https://raw.github.com/NServiceBusExtensions/NServiceBus.HandlerOrdering/master/icon.png)


NServiceBus.HandlerOrdering
===========================

This extension allows a more expressive way to [order handlers](https://docs.particular.net/nservicebus/handlers/handler-ordering).

HandlerOrdering allows the dependency between handlers to be expressed via interfaces and the resulting order is derived at runtime.

<!--- StartOpenCollectiveBackers -->

## Community backed

**This is a community backed project. Backing is done via [opencollective.com/nservicebusextensions](https://opencollective.com/nservicebusextensions/).**

**It is expected that any developer that uses any of these libraries [become at a backer](https://opencollective.com/nservicebusextensions#contribute).** This is an honesty system, there is no code that enforces this requirement. However when raising an issue or a pull request, the GitHub users name may be checked against [the list of backers](https://github.com/NServiceBusExtensions/Home/blob/master/backers.md), and that issue/PR may be closed without further examination.


### Backers

Thanks to all the backers! [[Become a backer](https://opencollective.com/nservicebusextensions#contribute)]

<a href="https://opencollective.com/nservicebusextensions#contribute" target="_blank"><img src="https://opencollective.com/nservicebusextensions/tiers/backer.svg"></a>

[<img src="https://opencollective.com/nservicebusextensions/donate/button@2x.png?color=blue" width="200px">](https://opencollective.com/nservicebusextensions#contribute)

<!--- EndOpenCollectiveBackers -->


## NuGet

https://www.nuget.org/packages/NServiceBus.HandlerOrdering/ [![NuGet Status](http://img.shields.io/nuget/v/NServiceBus.HandlerOrdering.svg?style=flat)](https://www.nuget.org/packages/NServiceBus.HandlerOrdering/)

    PM> Install-Package NServiceBus.HandlerOrdering


## Usage

```
endpointConfiguration.ApplyInterfaceHandlerOrdering();
```


## Documentation

https://docs.particular.net/nuget/NServiceBus.HandlerOrdering


## Icon

Icon courtesy of [The Noun Project](http://thenounproject.com)