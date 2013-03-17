using System;
using System.Collections.Generic;
using NServiceBus;

namespace HandlerOrdering
{
    static class ConfigureReader
    {
        static ConfigureReader()
        {
            TypesToScan = (IEnumerable<Type>)typeof(Configure).GetProperty("TypesToScan").GetValue(null);
        }

        public static IEnumerable<Type> TypesToScan;

    }
}