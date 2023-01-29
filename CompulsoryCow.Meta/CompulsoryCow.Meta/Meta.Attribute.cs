using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CompulsoryCow;

public partial class Meta
{
    /// <summary>This method returns the types of all classes that are decorated iwth the attribute.
    /// I nothing is found an empty enumerable is returned.
    /// Call it like so:
    /// 
    /// var myRunningDomain = AppDomain.CurrentDomain)
    /// IEnumerable&lt;Type&gt; result = Meta.GetClassesWithAttribute&lt;MyAttribute&gt(myRunningDomain)
    /// 
    /// and all loaded(?) classes decorated with `MyAttribute` are returned.
    /// </summary>
    /// <typeparam name="TAttribute"></typeparam>
    /// <param name="appDomain"></param>
    /// <returns></returns>
    public static IEnumerable<Type> GetClassesWithAttribute<TAttribute>(AppDomain appDomain) where TAttribute : Attribute
    {
        return appDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .Where(t => t.IsDefined(typeof(TAttribute)));
    }
}
