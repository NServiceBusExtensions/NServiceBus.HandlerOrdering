using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HandlerOrdering
{
    class TypeSorter
    {
        Dictionary<Type, List<Type>> dependencies;
        List<Type> sorted = new List<Type>();
        List<Type> stack;
        public ReadOnlyCollection<Type> Sorted;
        HashSet<Type> visited = new HashSet<Type>();

        public TypeSorter(Dictionary<Type, List<Type>> dependencies)
        {
            this.dependencies = dependencies;
            foreach (var item in dependencies.Keys)
            {
                stack = new List<Type>();
                Visit(item);
            }
            Sorted = new ReadOnlyCollection<Type>(sorted);
        }

        void Visit(Type item)
        {
            stack.Add(item);
            if (visited.Contains(item))
            {
                if (!sorted.Contains(item))
                {
                    stack.Reverse();
					var stringBuilder = new StringBuilder();
                    stringBuilder.AppendLine("Cyclic dependency detected.");
                    for (var index = 0; index < stack.Count-1; index++)
                    {
                        var type = stack[index];
                        var dependantType = stack[index + 1];
                        stringBuilder.AppendLine(string.Format("'{0}' wants to run after '{1}'.", type.Name, dependantType.Name));
                    }

                    throw new Exception(stringBuilder.ToString() );
                }
                return;
            }
            visited.Add(item);
            List<Type> values;
            if (dependencies.TryGetValue(item, out values))
            {
                foreach (var dep in values)
                {
                    Visit(dep);
                }
            }
            sorted.Add(item);
        }
    }
}