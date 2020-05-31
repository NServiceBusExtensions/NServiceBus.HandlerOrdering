# <img src="/src/icon.png" height="30px"> NServiceBus.HandlerOrdering

[![Build status](https://ci.appveyor.com/api/projects/status/l2jg521r03ei7a3n/branch/master?svg=true)](https://ci.appveyor.com/project/SimonCropp/nservicebus-HandlerOrdering)
[![NuGet Status](https://img.shields.io/nuget/v/NServiceBus.HandlerOrdering.svg)](https://www.nuget.org/packages/NServiceBus.HandlerOrdering/)

This extension allows a more expressive way to [order handlers](https://docs.particular.net/nservicebus/handlers/handler-ordering). HandlerOrdering allows the dependency between handlers to be expressed via interfaces and the resulting order is derived at runtime.

toc

<!--- StartOpenCollectiveBackers -->

[Already a Patron? skip past this section](#endofbacking)


## Community backed

**It is expected that all developers either [become a Patron](https://opencollective.com/nservicebusextensions/contribute/patron-6976) or have a [Tidelift Subscription](#support-via-tidelift) to use NServiceBusExtensions. [Go to licensing FAQ](https://github.com/NServiceBusExtensions/Home/#licensingpatron-faq)**


### Sponsors

Support this project by [becoming a Sponsor](https://opencollective.com/nservicebusextensions/contribute/sponsor-6972). The company avatar will show up here with a website link. The avatar will also be added to all GitHub repositories under the [NServiceBusExtensions organization](https://github.com/NServiceBusExtensions).


### Patrons

Thanks to all the backing developers. Support this project by [becoming a patron](https://opencollective.com/nservicebusextensions/contribute/patron-6976).

<img src="https://opencollective.com/nservicebusextensions/tiers/patron.svg?width=890&avatarHeight=60&button=false">

<a href="#" id="endofbacking"></a>

<!--- EndOpenCollectiveBackers -->


## Support via TideLift

Support is available via a [Tidelift Subscription](https://tidelift.com/subscription/pkg/nuget-nservicebus.handlerordering?utm_source=nuget-nservicebus.handlerordering&utm_medium=referral&utm_campaign=enterprise).


## NuGet package

https://nuget.org/packages/NServiceBus.HandlerOrdering/


## Usage

snippet: Usage


## Expressing dependencies


#### MessageHandler1 wants to run after MessageHandler3

snippet: express-order1


#### MessageHandler2 wants to run after MessageHandler1

snippet: express-order2


### Resulting execution order

 1. MessageHandler3
 1. MessageHandler1
 1. MessageHandler2


## Sample

[The sample](/src/Sample) demonstrates how to use interfaces to express dependencies between handlers.


### Configuring to use HandlerOrdering

snippet: config


### Expressing dependencies


#### MessageHandler1 wants to run after MessageHandler3

snippet: express-order1


#### MessageHandler2 wants to run after MessageHandler1

snippet: express-order2


### Resulting execution order

 1. MessageHandler3
 1. MessageHandler1
 1. MessageHandler2


## Security contact information

To report a security vulnerability, use the [Tidelift security contact](https://tidelift.com/security). Tidelift will coordinate the fix and disclosure.


## Icon

Icon courtesy of [The Noun Project](https://thenounproject.com)