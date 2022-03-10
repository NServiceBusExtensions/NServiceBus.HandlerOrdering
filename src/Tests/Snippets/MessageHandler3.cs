using NServiceBus;

public class MessageHandler3 :
    IHandleMessages<MyMessage>
{
    public Task Handle(MyMessage message, IMessageHandlerContext context) =>
        Task.CompletedTask;
}