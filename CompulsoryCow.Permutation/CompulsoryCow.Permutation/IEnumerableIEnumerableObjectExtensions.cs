using System;
using System.Collections.Generic;
using System.Linq;

namespace CompulsoryCow.Permutation;

public static class IEnumerableIEnumerableObjectExtensions
{
    /// <summary>Helper method for returning
    /// data from a data driven test that takes an
    /// IEnumerable &lt; object[] &gt; dataset.
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static IEnumerable<object[]> ToTestData(
        this IEnumerable<IEnumerable<object>> data
        )
    {
        return data
            .Select(d => d.ToArray());
    }
}
