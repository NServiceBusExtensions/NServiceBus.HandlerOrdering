using System;
using System.Threading.Tasks;
using HandlerOrdering;
using HandlerOrdering.Sample;
using NServiceBus;

static class Program
{
    static async Task Main()
    {
        Console.Title = "Samples.HandlerOrdering";
        var configuration = new EndpointConfiguration("Samples.HandlerOrdering");

        configuration.UseTransport<LearningTransport>();
        configuration.UsePersistence<InMemoryPersistence>();
        configuration.EnableInstallers();
        configuration.SendFailedMessagesTo("error");

        configuration.ApplyInterfaceHandlerOrdering();

        var endpointInstance = await Endpoint.Start(configuration);
        await endpointInstance.SendLocal(new MyMessage());
        Console.ReadLine();
    }
}