using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CompulsoryCow;

public partial class Meta
{
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

}
