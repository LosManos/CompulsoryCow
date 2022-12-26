using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CompulsoryCow;

public static class Meta
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

    /// <summary>Deprecated.
    /// Instead use <see cref="System.Runtime.CompilerServices.CallerMemberNameAttribute"/>
    /// The reason for deprecation is that the implementation walked the stack
    /// and that only works in a non-optimised complile. Possibly only in debug compilation too.
    /// </summary>
    /// <returns></returns>
    [Obsolete("Deprecated. Instead use CallerMemberNameAttribute", true)]
    public static MemberInfo GetProperty(this object me)
    {
        throw new NotImplementedException("Do not use. Use CallerMemberNameAttribute instead.");
    }

    /// <summary>This method returns <see cref="FieldInfo"/> for the private field in the parameter.
    /// </summary>
    /// <param name="theObject"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static FieldInfo GetPrivateField<T>(T theObject, string name)
    {
        if (theObject == null) { throw new ArgumentNullException(nameof(theObject)); }
        if (name == null) { throw new ArgumentNullException(nameof(name)); }

        return theObject.GetType().GetField(
            name,
            BindingFlags.NonPublic | BindingFlags.Instance);
    }

    /// <summary>This method returns <see cref="FieldInfo"/> for the private static field in the parameter.
    /// </summary>
    /// <param name="objectType"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static FieldInfo GetPrivateStaticField(Type objectType, string name)
    {
        return objectType.GetField(
            name,
            BindingFlags.NonPublic | BindingFlags.Static);
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

    /// <summary>This method returns <see cref="PropertyInfo"/> for the property in the parameter.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="theObject"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static PropertyInfo GetPrivateProperty<T>(T theObject, string name)
    {
        if (theObject == null) { throw new ArgumentNullException(nameof(theObject)); }
        if (name == null) { throw new ArgumentNullException(nameof(name)); }

        return theObject.GetType().GetProperty(
            name,
            BindingFlags.NonPublic | BindingFlags.Instance);

    }

    /// <summary>This method returns <see cref="PropertyInfo"/> for the static property in the parameter.
    /// </summary>
    /// <param name="objectType"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static PropertyInfo GetPrivateStaticProperty(Type objectType, string name)
    {
        return objectType.GetProperty(
            name,
            BindingFlags.NonPublic | BindingFlags.Static);
    }

    /// <summary>This method returns <see cref="PropertyInfo"/>for all public properties for a type.
    /// Use <paramref name="recurse"/> for telling it to, recursively, dive into properties.
    /// 
    /// Note: Types can be complex so make sure it can follow yor properties' types,
    /// them being classes or enumerations or arrays or whatnot.
    /// 
    /// Use it like so:
    /// var ps = GetPublicProperties(typeof(T), true);
    /// </summary>
    /// <param name="type"></param>
    /// <param name="recurse"></param>
    /// <param name="distinct"></param>
    /// <returns></returns>
    public static PropertyInfo[] GetPublicProperties(Type type, bool recurse = false, bool distinct = false)
    {
        if (type == null) { throw new ArgumentNullException(nameof(type)); }

        var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

        if (recurse == false)
        {
            return props;
        }

        foreach (var prop in props)
        {
            if (prop.PropertyType.IsArray)
            {
                props = props.Concat(GetPublicProperties(prop.PropertyType.GetTypeInfo().GetElementType(), true)).ToArray();
            }
            else if (ImplementsIEnumerable(prop))
            {
                // Code is copied with pride from https://stackoverflow.com/questions/906499/getting-type-t-from-ienumerablet
                props = props.Concat(GetPublicProperties(prop.PropertyType.GetGenericArguments()[0], true)).ToArray();
            }
            else if (prop.PropertyType.IsClass)
            {
                props = props.Concat(GetPublicProperties(prop.PropertyType, true)).ToArray();
            }
        }

        return distinct
            ? props.DistinctBy(p => p.Name).ToArray()
            : props;

        bool ImplementsIEnumerable(PropertyInfo pi)
        {
            var System_Collections_IEnumerable = (((System.Type[])((System.Reflection.TypeInfo)typeof(IEnumerable<>)).ImplementedInterfaces)[0]).FullName;
            return pi.PropertyType.GetInterfaces().FirstOrDefault(i => i.FullName == System_Collections_IEnumerable)?.ToString() != null;
        }
    }

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
