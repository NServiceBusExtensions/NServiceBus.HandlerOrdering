using System;
using System.Diagnostics;
using System.Threading.Tasks;
using HandlerOrdering;
using HandlerOrdering.Sample;
using NServiceBus;

public class MessageHandler2 :
    IHandleMessages<MyMessage>,
    IWantToRunAfter<MessageHandler1>
{
    public Task Handle(MyMessage message, IMessageHandlerContext context)
    {
        Debug.Assert(MessageHandler1.ReceivedMessage);
        Console.WriteLine("MessageHandler2");
        return Task.CompletedTask;
    }
}