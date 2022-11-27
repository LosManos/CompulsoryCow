using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CompulsoryCow;

public static class Meta
{
    /// <summary>This method returns information about the calling method.
    /// It walks the stack which might be expensive.
    /// /// <para>
    /// Use it like so:
    ///	void MyFirstMethod(){
    ///		MySecondMethod();
    ///	}
    ///	void MySecondMethod(){
    ///		var callingMethod = CompulsoryCow.Meta.GetCallingMethod();
    ///		//	callingMethod.Name is now "MyFirstMethod".
    ///	}
    ///	</para>
    /// </summary>
    /// <returns></returns>
    [Obsolete("This method only works in debug mode. Might be remedied by [MethodImplAttribute(MethodImplOptions.NoInlining)]. This method might be deprecated in the future.", false)]
    public static MethodBase GetCallingMethod()
    {
        return new System.Diagnostics.StackTrace().GetFrame(2).GetMethod();
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

    /// <summary>This method returns the MemberInfo of the property we are calling it from.
    /// Use it like:
    /// class MyClass{
    ///     public string Title{
    ///	      get{
    ///	          //  Just call with this.GetProperty.
    ///             Log( "The user just called the property" + this.GetProperty().Name );
    ///             return _title;
    ///         }
    ///     }
    /// }
    /// </summary>
    /// <param name="me"></param>
    /// <returns></returns>
    public static MemberInfo GetProperty(this object me)
    {
        const string Prefix = "get_";
#pragma warning disable CS0618 // Type or member is obsolete
        var callingMethod = GetCallingMethod();
#pragma warning restore CS0618 // Type or member is obsolete

        //	Remove the "get_"-prefix
        var propertyName = callingMethod.Name.StartsWith(Prefix) ?
            callingMethod.Name.Substring(Prefix.Length) :
            callingMethod.Name;

        var property = callingMethod.DeclaringType.GetProperty(
            propertyName,
            BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

        return property;
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

    /// <summary>This method returns <see cref="PropertyInfo"/> for all public properties in a class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="theClass"></param>
    /// <returns></returns>
    public static PropertyInfo[] GetPublicProperties<T>(T theClass)
    {
        if (theClass == null) { throw new ArgumentNullException(nameof(theClass)); }

        return theClass.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
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
