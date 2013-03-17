using NServiceBus.Config;
using NServiceBus.Config.ConfigurationSource;

public class CustomConfigurationSource : IConfigurationSource
{
	public T GetConfiguration<T>() where T : class, new()
	{
		if (typeof(T) == typeof(MessageForwardingInCaseOfFaultConfig))
		{
			return new MessageForwardingInCaseOfFaultConfig
				{
					ErrorQueue = "Error",
				} as T;
		}

		return new T();
	}
}