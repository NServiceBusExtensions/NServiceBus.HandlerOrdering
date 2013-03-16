using System;
using HandlerOrdering.Sample;
using NServiceBus;

public class MessageHandler3 : IHandleMessages<MyMessage>
{
	public static bool ReceivedMessage;
	public void Handle(MyMessage message)
	{
		ReceivedMessage = true;
		Console.WriteLine("MessageHandler3");
	}
}