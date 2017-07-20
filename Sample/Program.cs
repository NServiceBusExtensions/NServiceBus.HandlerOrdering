using System;
using System.Threading.Tasks;
using HandlerOrdering;
using HandlerOrdering.Sample;
using NServiceBus;

static class Program
{
    static void Main()
    {
        AsyncMain().GetAwaiter().GetResult();
    }

    static async Task AsyncMain()
    {
        Console.Title = "Samples.HandlerOrdering";
        var endpointConfiguration = new EndpointConfiguration("Samples.HandlerOrdering");

        endpointConfiguration.UseTransport<LearningTransport>();
        endpointConfiguration.UsePersistence<InMemoryPersistence>();
        endpointConfiguration.EnableInstallers();
        endpointConfiguration.SendFailedMessagesTo("error");

        endpointConfiguration.ApplyInterfaceHandlerOrdering();

        var endpointInstance = await Endpoint.Start(endpointConfiguration)
            .ConfigureAwait(false);
        await endpointInstance.SendLocal(new MyMessage())
            .ConfigureAwait(false);
        Console.ReadLine();
    }
}