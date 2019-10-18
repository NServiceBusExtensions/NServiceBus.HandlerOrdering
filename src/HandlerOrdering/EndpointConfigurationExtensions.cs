using NServiceBus;
using NServiceBus.Configuration.AdvancedExtensibility;

namespace HandlerOrdering
{
    /// <summary>
    /// Extensions to <see cref="EndpointConfiguration"/> for enabling HandlerOrdering.
    /// </summary>
    public static class EndpointConfigurationExtensions
    {
        /// <summary>
        /// Enable HandlerOrdering.
        /// </summary>
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