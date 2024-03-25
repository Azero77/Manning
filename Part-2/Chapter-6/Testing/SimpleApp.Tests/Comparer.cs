using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApp.Tests
{
    public class Comparer
    {
        public static Comparer<U> Get<U>(Func<U?, U?, bool> func)
        {
            return new Comparer<U>(func);
        }
    }

    public class Comparer<T> : Comparer, IEqualityComparer<T>
    {
        private Func<T?, T?, bool> function;

        public Comparer(Func<T?, T?, bool> fun) 
        {
            function = fun;
        }

        public bool Equals(T? obj1, T? obj2) => function(obj1, obj2);

        public int GetHashCode(T obj) =>obj?.GetHashCode() ?? 0;
        
        
    }
}
