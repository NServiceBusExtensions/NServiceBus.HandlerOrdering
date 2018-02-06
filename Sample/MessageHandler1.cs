using System;
using System.Diagnostics;
using System.Threading.Tasks;
using HandlerOrdering;
using HandlerOrdering.Sample;
using NServiceBus;

public class MessageHandler1 :
    IHandleMessages<MyMessage>,
    IWantToRunAfter<MessageHandler3>
{
    public static bool ReceivedMessage;

    public Task Handle(MyMessage message, IMessageHandlerContext context)
    {
        ReceivedMessage = true;
        Debug.Assert(MessageHandler3.ReceivedMessage);
        Console.WriteLine("MessageHandler1");
        return Task.CompletedTask;
    }
}