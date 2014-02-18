using System;
using System.Diagnostics;
using HandlerOrdering;
using HandlerOrdering.Sample;
using NServiceBus;

public class MessageHandler2 : IHandleMessages<MyMessage>, IWantToRunAfter<MessageHandler1>
{
	public void Handle(MyMessage message)
	{
		Debug.Assert(MessageHandler1.ReceivedMessage);
		Console.WriteLine("MessageHandler2");
	}
}

