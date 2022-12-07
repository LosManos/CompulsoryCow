using System;

namespace CompulsoryCow.AreEqual;

public static class AreEqual
	{
    public enum Depth
    {
        Infinite = -1,
        // 0 should not be used.
        None = 1
    }

    /// <summary>This method compares every public property of an object and returns True if all of them are equal.
    /// It returns False otherwise.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
		public static bool Public<T>(T a, T b)
		{
			var properties = Meta.GetPublicProperties(a);

			foreach (var property in properties)
			{
				var propertyA = property.GetValue(a, null);
				var propertyB = property.GetValue(b, null);

				if (Equals(propertyA, propertyB) == false)
				{
					return false;
				}
			}
			return true;
		}

    /// <summary>This method compares two objects to a certain depth.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="depth">Infinite means turtles all the way down.
    /// None is equal to 1 level deep and means just the first object and no check of any referenced object.
    /// For any other depth, call the methdo with (AreEqual.Depth)#.</param>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static bool Public<T>(Depth depth, T a, T b)
    {
        var properties = Meta.GetPublicProperties(a);

        foreach (var property in properties)
        {
            if (IsSimple(property.PropertyType))
            {
                var propertyA = property.GetValue(a, null);
                var propertyB = property.GetValue(b, null);

                if (Equals(propertyA, propertyB) == false)
                {
                    return false;
                }
            }
            else
            {
                if ((int)depth >= 2 || depth == Depth.Infinite)
                {
                    var propertyA = property.GetValue(a, null);
                    var propertyB = property.GetValue(b, null);

                    //  One is null and the other isn't means they are different.
                    if(( propertyA == null && propertyB != null) ||
                        (propertyA != null && propertyB == null))
                    {
                        return false;
                    }
                    if (propertyA != null && propertyB != null)
                    {
                        var lessDepth = depth == Depth.Infinite ? Depth.Infinite : (Depth)((int)depth - 1);
                        return Public(lessDepth, propertyA, propertyB);
                    }
                }
            }
        }

        return true;
    }

    private static bool IsSimple(Type type)
    {
        // https://stackoverflow.com/questions/863881/how-do-i-tell-if-a-type-is-a-simple-type-i-e-holds-a-single-value

        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
        {
            // nullable type, check if the nested type is simple.
            return IsSimple(type.GetGenericArguments()[0]);
        }
        return type.IsPrimitive
          || type.IsEnum
          || type.Equals(typeof(string))
          || type.Equals(typeof(decimal));
    }
}