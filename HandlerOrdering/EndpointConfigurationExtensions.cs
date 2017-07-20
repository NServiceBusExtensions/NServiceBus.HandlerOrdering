using NServiceBus;
using NServiceBus.Configuration.AdvancedExtensibility;

namespace HandlerOrdering
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public static class EndpointConfigurationExtensions
    {
        public static void ApplyInterfaceHandlerOrdering(this EndpointConfiguration configuration)
        {
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