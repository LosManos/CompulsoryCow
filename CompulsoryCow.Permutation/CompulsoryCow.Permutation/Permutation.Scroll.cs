using System.Collections.Generic;
using System.Linq;

namespace CompulsoryCow.Permutation
{
    partial class Permutation
    {

        /// <summary>This method returns a list like
        /// Scroll("X", "O", 3) =>
        /// [
        ///     ["X", "O", "O"],
        ///     ["O", "X", "O"],
        ///     ["O", "O", "X"]
        /// ]
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<string>> Scroll(string value, string defaultValue, int size)
        {
            for( int i = 0; i<size; ++i)
            {
                var array = Enumerable.Repeat(defaultValue, size).ToArray();
                array[i] = value;
                yield return array;
            }
        }
    }
}
