using System;
using System.Threading.Tasks;
using HandlerOrdering;
using NServiceBus;

class Program
{
    static async Task Main()
    {
        Console.Title = "Samples.HandlerOrdering";
        var endpointConfiguration = new EndpointConfiguration("Samples.HandlerOrdering");
        endpointConfiguration.UsePersistence<LearningPersistence>();
        endpointConfiguration.UseTransport<LearningTransport>();
        #region config
        endpointConfiguration.ApplyInterfaceHandlerOrdering();
        #endregion

        var endpointInstance = await Endpoint.Start(endpointConfiguration);
        var myMessage = new MyMessage();
        await endpointInstance.SendLocal(myMessage);
        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
        await endpointInstance.Stop();
    }
}