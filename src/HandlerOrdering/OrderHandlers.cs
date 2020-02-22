using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HandlerOrdering;
using NServiceBus;

class OrderHandlers :
    INeedInitialization
{
    public void Customize(EndpointConfiguration configuration)
    {
        if (configuration.GetApplyInterfaceHandlerOrdering())
        {
            ApplyInterfaceHandlerOrdering(configuration);
        }
    }

    public void ApplyInterfaceHandlerOrdering(EndpointConfiguration configuration)
    {
        var handlerDependencies = GetHandlerDependencies(configuration);
        var sorted = new TypeSorter(handlerDependencies).Sorted;
        configuration.ExecuteTheseHandlersFirst(sorted);
    }

    static Dictionary<Type, List<Type>> GetHandlerDependencies(EndpointConfiguration configuration)
    {
        var field = typeof(EndpointConfiguration)
            .GetField("scannedTypes", BindingFlags.Instance | BindingFlags.NonPublic);
        if (field == null)
        {
            throw new Exception($"Could not extract 'scannedTypes' field from {nameof(EndpointConfiguration)}. Raise an issue here https://github.com/NServiceBusExtensions/NServiceBus.HandlerOrdering/issues/new");
        }
        var types = (List<Type>) field.GetValue(configuration);
        return GetHandlerDependencies(types);
    }

    internal static Dictionary<Type, List<Type>> GetHandlerDependencies(List<Type> types)
    {
        var dictionary = new Dictionary<Type, List<Type>>();
        foreach (var type in types)
        {
            var interfaces = type.GetInterfaces();
            foreach (var face in interfaces)
            {
                if (!face.IsGenericType)
                {
                    continue;
                }
                if (face.GetGenericTypeDefinition() != typeof(IWantToRunAfter<>))
                {
                    continue;
                }
                if (!dictionary.TryGetValue(type, out var dependencies))
                {
                    dictionary[type] = dependencies = new List<Type>();
                }
                dependencies.Add(face.GenericTypeArguments.First());
            }
        }
        return dictionary;
    }
}
