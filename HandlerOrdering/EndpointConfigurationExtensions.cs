using NServiceBus;
using NServiceBus.Configuration.AdvanceExtensibility;

namespace HandlerOrdering
{
    public static class EndpointConfigurationExtensions
    {
        public static void ApplyInterfaceHandlerOrdering(this EndpointConfiguration configuration)
        {
            var settings = configuration.GetSettings();
            settings.Set("HandlerOrdering.ApplyInterfaceHandlerOrdering", true);
        }

        internal static bool GetApplyInterfaceHandlerOrdering(this EndpointConfiguration configuration)
        {
            bool isSet;
            var settings = configuration.GetSettings();
            settings.TryGet("HandlerOrdering.ApplyInterfaceHandlerOrdering", out isSet);
            return isSet;
        }
    }
}