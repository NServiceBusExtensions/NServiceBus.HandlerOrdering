using HandlerOrdering;
using NServiceBus;

class Usage
{
    Usage(EndpointConfiguration configuration)
    {
        #region Usage

        configuration.ApplyInterfaceHandlerOrdering();

        #endregion
    }
}