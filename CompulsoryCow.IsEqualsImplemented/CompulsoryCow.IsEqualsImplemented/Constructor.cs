using System;
using System.Linq;

namespace CompulsoryCow.IsEqualsImplemented;

/// <summary>This class contains constructor related logic.
/// </summary>
public class Constructor
{
    /// <summary>Returns true if the  <paramref name="appDomain"/> contains classes 
    /// decorated with attribute <typeparamref name="TAttribute"/> which all can be constructed
    /// without any argument.
    /// The method returns false if any such decorated class does not contain an
    /// implicit or explicit default constructor.
    /// The method return false if there is no class decorated with the attribute.
    /// 
    /// Example of usage: 
    /// Decorate att DTOs in a project with a custom attribute `DtoAttribute`.
    /// Then call this method in a test like so: `Assert.True(IsDefaultImplemented<Dto>(AppDomain.CurrentDomain))`.
    /// </summary>
    /// <typeparam name="TAttribute"></typeparam>
    /// <param name="appDomain"></param>
    /// <returns></returns>
    public bool IsDefaultImplemented<TAttribute>(AppDomain appDomain) where TAttribute : Attribute
    {
        var classTypes = Meta.GetClassesWithAttribute<TAttribute>(appDomain);
        var res = classTypes.Any() && classTypes.All(ct => IsDefaultImplemented(ct));
        return res;
    }

    /// <summary>Returns true if the <typeparamref name="TClass"/> can be created
    /// without arguments. (it has an implicit or explicit default constructor)
    /// If <typeparamref name="TClass"/> must have argument(s) to be created
    /// the compiler will fail.
    /// </summary>
    /// <typeparam name="TClass"></typeparam>
    /// <returns></returns>
    public bool IsDefaultImplemented<TClass>() where TClass : new()
    {
        // Calling this method in runtime is not necessary, as the compiler will break if `TClass` does not contain an accessible default constructor.
        // So if the compiler allows for calling, the class contains a defautl constructor and we return true;
        return true;
    }

    /// <summary>Returns true if the <paramref name="type"/> can be created
    /// without arguments. (it has an implicit or explicit default constructor)
    /// If <paramref name="type"/> must have argument(s) to be created
    /// false is returned.
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public bool IsDefaultImplemented(Type type)
    {
        var res = Meta.GetDefaultConstructor(type);
        return res is not null;
    }
}
