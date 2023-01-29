using System;
using System.Reflection;

namespace CompulsoryCow;

public static partial class Meta
{
    /// <summary>Deprecated.
    /// Instead use <see cref="System.Runtime.CompilerServices.CallerMemberNameAttribute"/>
    /// The reason for deprecation is that the implementation walked the stack
    /// and that only works in a non-optimised complile. Possibly only in debug compilation too.
    /// </summary>
    /// <returns></returns>
    [Obsolete("Deprecated. Instead use CallerMemberNameAttribute", true)]
    public static MethodBase GetCallingMethod()
    {
        throw new NotImplementedException("Do not use. Use CallerMemberNameAttribute instead.");
    }

    /// <summary>This method returns <see cref="MethodInfo"/> for the method in the parameter.
    /// It does not handle overloaded methods.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="theObject"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static MethodInfo GetPrivateMethod<T>(T theObject, string name)
    {
        if (theObject == null) { throw new ArgumentNullException(nameof(theObject)); }
        if (name == null) { throw new ArgumentNullException(nameof(name)); }

        return theObject.GetType().GetMethod(
            name,
            BindingFlags.NonPublic | BindingFlags.Instance);
    }

    /// <summary>This method returns <see cref="MethodInfo"/> for the static method in the parameter.
    /// It does not handle overloaded methods.
    /// </summary>
    /// <param name="objectType"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static MethodInfo GetPrivateStaticMethod(Type objectType, string name)
    {
        return objectType.GetMethod(
            name,
            BindingFlags.NonPublic | BindingFlags.Static);
    }
}
