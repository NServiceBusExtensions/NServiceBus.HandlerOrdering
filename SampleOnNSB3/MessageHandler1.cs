using System;
using System.Diagnostics;
using HandlerOrdering;
using HandlerOrdering.Sample;
using NServiceBus;



public class MessageHandler1 : IHandleMessages<MyMessage>, IWantToRunAfter<MessageHandler3>
{
	public static bool ReceivedMessage;
	public void Handle(MyMessage message)
	{
		ReceivedMessage = true;
		Debug.Assert(MessageHandler3.ReceivedMessage);
		Console.WriteLine("MessageHandler1");
	}
}