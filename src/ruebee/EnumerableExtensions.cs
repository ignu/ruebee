using System;
using System.Collections.Generic;
using System.Linq;

namespace ruebee
{
    public static class EnumerableExtensions
    {
        public static void Each<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var item in collection)            
                action(item);            
        }

        [Obsolete("Use Linq.Distinct")]
        public static IEnumerable<T> Uniq<T>(this IEnumerable<T> value)
        {
            return value.Distinct();
        }
    }
}