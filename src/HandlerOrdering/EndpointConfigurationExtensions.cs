using NServiceBus;
using NServiceBus.Configuration.AdvancedExtensibility;

namespace HandlerOrdering
{
    public static class EndpointConfigurationExtensions
    {
        public static void ApplyInterfaceHandlerOrdering(this EndpointConfiguration configuration)
        {
            Guard.AgainstNull(configuration, nameof(configuration));
            var settings = configuration.GetSettings();
            settings.Set("HandlerOrdering.ApplyInterfaceHandlerOrdering", true);
        }

        internal static bool GetApplyInterfaceHandlerOrdering(this EndpointConfiguration configuration)
        {
            var settings = configuration.GetSettings();
            settings.TryGet("HandlerOrdering.ApplyInterfaceHandlerOrdering", out bool isSet);
            return isSet;
        }
    }
}