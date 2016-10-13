using System;
using System.Collections.Generic;
using HandlerOrdering;
using NUnit.Framework;

public class OrderHandlersTests
{
    [TestFixture]
    public class Ensure_cascading_dependencies_are_resolved
    {
        [Test]
        public void Run()
        {
            var types = new List<Type>
            {
                typeof (Class1),
                typeof (Class2),
                typeof (Class3)
            };
            var handlerDependencies = OrderHandlers.GetHandlerDependencies(types);

            Assert.Contains(typeof (Class2), handlerDependencies[typeof (Class1)]);
            Assert.Contains(typeof (Class3), handlerDependencies[typeof (Class1)]);
            Assert.Contains(typeof (Class3), handlerDependencies[typeof (Class2)]);
        }

        class Class1 : IWantToRunAfter<Class2>, IWantToRunAfter<Class3>
        {
        }

        class Class2 : IWantToRunAfter<Class3>
        {
        }

        class Class3
        {
        }
    }

}