using System;
using System.Reflection;

namespace CompulsoryCow;

public partial class Meta
{
    /// <summary>This method returns the default constructor for the given type &lt;TClass&gt;
    /// If there is no default constructor null is returned.
    /// </summary>
    /// <typeparam name="TClass"></typeparam>
    /// <returns></returns>
    public static ConstructorInfo? GetDefaultConstructor<TClass>()
    {
        return typeof(TClass).GetConstructor(Type.EmptyTypes);
    }

}
