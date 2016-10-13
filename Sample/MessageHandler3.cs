using System;
using System.Threading.Tasks;
using HandlerOrdering.Sample;
using NServiceBus;

public class MessageHandler3 :
    IHandleMessages<MyMessage>
{
    public static bool ReceivedMessage;

    public Task Handle(MyMessage message, IMessageHandlerContext context)
    {
        ReceivedMessage = true;
        Console.WriteLine("MessageHandler3");
        return Task.CompletedTask;
    }

}