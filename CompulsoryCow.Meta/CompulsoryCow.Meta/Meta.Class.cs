using System;
using System.Reflection;

namespace CompulsoryCow;

public static partial class Meta
{
    /// <summary>This method retuns the <see cref="System.Type"/> of the class in the parameter.
    /// If nothing is found an <see cref="System.ArgumentException"/> exception is thrown.
    /// </summary>
    /// <param name="me"></param>
    /// <param name="className"></param>
    /// <returns></returns>
    public static Type GetClass(this object me, string className)
    {
        return me.GetType().GetNestedType(className, BindingFlags.Public | BindingFlags.NonPublic) ??
            throw new ArgumentException($"[{className}] does not evaluate to a known class for [{me.GetType().FullName}].", nameof(className));
    }

    /// <summary>This method retuns the <see cref="System.Type"/> of the class in the parameter.
    /// If nothing is found null is returned.
    /// </summary>
    /// <param name="objectType"></param>
    /// <param name="className"></param>
    /// <returns></returns>
    public static Type GetClassOrNull(Type objectType, string className)
    {
        return objectType.GetNestedType(className, BindingFlags.Public | BindingFlags.NonPublic);
    }

    /// <summary>This method retuns the <see cref="System.Type"/> of the class in the parameter.
    /// If nothing is found an <see cref="System.ArgumentException"/> exception is thrown.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="className"></param>
    /// <returns></returns>
    public static Type GetClass<T>(string className)
    {
        return typeof(T).GetNestedType(className, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static) ??
            throw new ArgumentException($"[{className}] does not evaluate to a known class.", nameof(className));
    }

    /// <summary>This  method retrieves a class by its Assembly, Namespace and Class name.
    /// If nothing is found an <see cref="System.ArgumentException"/> exception is thrown.
    /// See <see cref="https://msdn.microsoft.com/en-us/library/w3f99sx1.aspx"/>for how to write more complex class names
    /// like nested and generic.
    /// Hint: Nested classes are denoted with a + character like "Customer+Address".
    /// </summary>
    /// <param name="assemblyName"></param>
    /// <param name="namespace"></param>
    /// <param name="className"></param>
    /// <returns></returns>
    public static Type GetClass(string assemblyName, string @namespace, string className)
    {
        Func<string> createTypeName = () => $"{@namespace}.{className}, {assemblyName}";
        return Type.GetType(createTypeName())
            ?? throw new ArgumentException($"The arguments evaluates to [{createTypeName()} to find the class. Nohting was found.");
    }
}
