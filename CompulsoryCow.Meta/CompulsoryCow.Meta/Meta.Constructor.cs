using System;
using System.Reflection;

namespace CompulsoryCow;

public partial class Meta
{
    /// <summary>This method returns the default constructor for the given <typeparamref name="TClass"/>.
    /// If there is no default constructor null is returned.
    /// </summary>
    /// <typeparam name="TClass"></typeparam>
    /// <returns></returns>
    public static ConstructorInfo? GetDefaultConstructor<TClass>()
    {
        return typeof(TClass).GetConstructor(Type.EmptyTypes);
    }

    /// <summary>This method returns teh default constructor for the given <paramref name="type"/>.
    /// If there is no default constructor null is returned.
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static ConstructorInfo? GetDefaultConstructor(Type type)
    {
        var res = type.GetConstructor(Type.EmptyTypes);
        return res;
    }
}
