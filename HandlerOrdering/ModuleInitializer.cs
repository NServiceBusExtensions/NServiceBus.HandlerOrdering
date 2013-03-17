using System;
using System.Collections.Generic;

namespace HandlerOrdering
{
    static class ModuleInitializer
    {
        public static void Initialize()
        {
            var types = ConfigureReader.TypesToScan as IList<Type>;
            if (types == null)
            {
                return;
            }
            var type = typeof (OrderHandlers);
            if (types.Contains(type))
            {
                return;
            }
            types.Add(type);
        }
    }
}