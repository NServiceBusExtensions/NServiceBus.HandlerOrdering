using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HandlerOrdering;
using NServiceBus;

class OrderHandlers : INeedInitialization
{

    public void Customize(EndpointConfiguration configuration)
    {
        if (configuration.GetApplyInterfaceHandlerOrdering())
        {
            ApplyInterfaceHandlerOrdering(configuration);
        }
    }

    public void ApplyInterfaceHandlerOrdering(EndpointConfiguration endpointConfiguration)
    {
        var handlerDependencies = GetHandlerDependencies(endpointConfiguration);
        var sorted = new TypeSorter(handlerDependencies).Sorted;
        endpointConfiguration.ExecuteTheseHandlersFirst(sorted);
    }

    internal static Dictionary<Type, List<Type>> GetHandlerDependencies(EndpointConfiguration endpointConfiguration)
    {
        var field = typeof(EndpointConfiguration)
            .GetField("scannedTypes", BindingFlags.Instance | BindingFlags.NonPublic);
        if (field == null)
        {
            throw new Exception($"Could not extract 'scannedTypes' field from {nameof(EndpointConfiguration)}. Raise an issue here https://github.com/SimonCropp/HandlerOrdering/issues/new");
        }
        var types = (List<Type>) field.GetValue(endpointConfiguration);
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
                if (!dictionary.TryGetValue(type, out List<Type> dependencies))
                {
                    dictionary[type] = dependencies = new List<Type>();
                }
                dependencies.Add(face.GenericTypeArguments.First());
            }
        }
        return dictionary;
    }

}
