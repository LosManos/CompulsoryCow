using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CompulsoryCow;

public static partial class Meta
{
    /// <summary>Helper method `DistinctBy` as it does not exist in .net standard.
    /// This method is copied with pride from https://stackoverflow.com/questions/19890301/distinctby-not-recognized-as-method#19890330
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <param name="items"></param>
    /// <param name="property"></param>
    /// <returns></returns>
    private static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> items, Func<T, TKey> property)
    {
        return items.GroupBy(property).Select(x => x.First());
    }
}
