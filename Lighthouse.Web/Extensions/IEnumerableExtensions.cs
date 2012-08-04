using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace System.Collections.Generic
{
    public static class IEnumerableExtensions
    {
        public static bool IsNotNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable != null || enumerable.Any();
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable == null || !enumerable.Any();
        }
    }
}