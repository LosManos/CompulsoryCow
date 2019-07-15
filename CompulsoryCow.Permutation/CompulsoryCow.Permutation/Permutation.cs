using System.Collections.Generic;
using System.Linq;
using Parameters = System.Collections.Generic.IEnumerable<object>;

namespace CompulsoryCow.Permutation
{
    public class Permutation
    {
        /// <summary>This method permutates the input parameters.
        /// The thought of usage is for testing, to make up all possible parameter inputs for a method
        /// and then permutate them.
        /// It would probably be unwise to have an <see cref="System.Int32"/> or <see cref="System.Char"/> as input parameters
        /// as the permutations would be ridiculously many.
        /// A <see cref="System.String"/> as input parameter would be even worse as it has in infinity of possible values.
        /// 
        /// Example of usage:
        /// If the signature of the method to test looks like:
        /// `bool Authenticate( bool isUserLoggedOn, RoleEnum role, string companyName )`
        /// and we know that having a blank `companyName` has a business value;
        /// the code would be:
        /// ```
        /// var permutations = Permutation.Permutate(
        ///     new object[][]{
        ///         new object[]{false, true}, 
        ///         new object[]{Role.User, Role.Admin, Role.System},
        ///         new string[]{"", "whatever"}
        ///     });
        ///     foreach( perm in permutation ){
        ///         var params = perm.ToList();
        ///         var isUserLoggedOn = (bool)params[0];
        ///         var role = (Role)params[1];
        ///         var companyName = (string)params[2[;
        ///         ...
        ///     }
        /// ```
        /// 
        /// For more example of usage, see test code.
        /// </summary>
        /// <param name="parametersCollection"></param>
        /// <returns></returns>
        public static IEnumerable<Parameters> Permutate(
            IEnumerable<Parameters> parametersCollection)
        {
            return GetAllPermutationsOf(parametersCollection, new List<object>());
        }

        /// <summary>This method returns a list of all possible permutations.
        /// The method is recursive.
        /// I am not too sure about its performance. Read more here:
        /// https://stackoverflow.com/a/2055946/521554
        /// If performance should be a problem we might get around it
        /// by creating a tree of the permutations and then loop through them. Read moere here:
        /// https://stackoverflow.com/a/30441479/521554
        /// AFAIK and by the time of writing C# is not tail recursion optimised. Read more here:
        /// https://thomaslevesque.com/2011/09/02/tail-recursion-in-c/
        /// https://github.com/dotnet/csharplang/issues/2544
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="values">Should be called with a `new List&lt;object&gt;()` to start.</param>
        /// <returns></returns>
        private static IEnumerable<Parameters> GetAllPermutationsOf(
            IEnumerable<Parameters> parameters,
            IList<object> values)
        {
            var tail = Tail(parameters);
            foreach (var value in Head(parameters))
            {
                var actualValues = new List<object>(values);
                actualValues.Add(value);

                if (tail.Any() == false)
                {
                    yield return actualValues;
                }
                else
                {
                    foreach (var v in GetAllPermutationsOf(tail, actualValues))
                    {
                        yield return v;
                    }
                }
            }
        }

        /// <summary>This method returns the head, the first object/value, of a list.
        /// If the list is empty, there is no head, then the default value of an object/value is returned.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lst"></param>
        /// <returns></returns>
        private static T Head<T>(IEnumerable<T> lst)
        {
            return lst.FirstOrDefault();
        }

        /// <summary>This method returns the tail of a list.
        /// If the list is empty an empty list is returned.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lst"></param>
        /// <returns></returns>
        private static IEnumerable<T> Tail<T>(IEnumerable<T> lst)
        {
            return Head(lst) == null ? lst.Take(0) : lst.Skip(1);
        }
    }
}
