using System;
using System.Collections.Generic;
using HandlerOrdering;
using NUnit.Framework;

[TestFixture]
public class TypeSorterTests
{

    [TestFixture]
    public class SimpleSort
    {

        [Test]
        public void Run()
        {
            var dependencies = new Dictionary<Type, List<Type>>();
            dependencies[typeof (Class1)] = new List<Type>
                {
                    typeof (Class2),
                    typeof (Class3)
                };
            dependencies[typeof (Class2)] = new List<Type>
                {
                    typeof (Class3)
                };
            var sorted = new TypeSorter(dependencies).Sorted;
            Assert.AreEqual(3, sorted.Count);
            Assert.AreEqual(typeof (Class3), sorted[0]);
            Assert.AreEqual(typeof (Class2), sorted[1]);
            Assert.AreEqual(typeof (Class1), sorted[2]);
        }

        class Class1
        {
        }

        class Class2
        {
        }

        class Class3
        {
        }

    }

    [TestFixture]
    public class Ensure_circular_dependencies_are_handled
    {
        [Test]
        public void Run()
        {
            var dependencies = new Dictionary<Type, List<Type>>();
            dependencies[typeof (Class1)] = new List<Type>
                {
                    typeof (Class2),
                };
            dependencies[typeof (Class2)] = new List<Type>
                {
                    typeof (Class3)
                };
            dependencies[typeof (Class3)] = new List<Type>
                {
                    typeof (Class1)
                };
            var exception = Assert.Throws<Exception>(() => new TypeSorter(dependencies));
            var expected = @"Cyclic dependency detected.
'Class1' wants to run after 'Class3'.
'Class3' wants to run after 'Class2'.
'Class2' wants to run after 'Class1'.
".Replace("\r\n","").Replace("\n","");
            Assert.AreEqual(expected, exception.Message.Replace("\r\n", "").Replace("\n", ""));
        }

        class Class1
        {
        }

        class Class2
        {
        }
        class Class3
        {
        }

    }
}