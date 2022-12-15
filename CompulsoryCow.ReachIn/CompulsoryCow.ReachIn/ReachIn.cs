using System;
using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace CompulsoryCow.ReachIn;

public class ReachIn : DynamicObject
{
    private readonly object? _obj;
    private readonly Type _type;

    public ReachIn(Type type)
    {
        _obj = null;
        _type = type;
    }

    public ReachIn(object obj)
    {
        _obj = obj;
        _type = obj.GetType();
    }

    public override bool TryGetMember(GetMemberBinder binder, out object? result)
    {
        var member = GetMemberOrThrow(_type, binder.Name);
        switch (member.MemberType)
        {
            case MemberTypes.Field:
                var field = (FieldInfo)member;
                if (field.FieldType.IsValueType ||
                    field.FieldType == typeof(string))
                {
                    result = ((FieldInfo)member).GetValue(_obj);
                    return true;
                }
                else
                {
                    result = new ReachIn(((FieldInfo)member).GetValue(_obj));
                    return true;
                }
            case MemberTypes.Property:
                result = ((PropertyInfo)member).GetValue(_obj, null);
                return true;        
            //case MemberTypes.NestedType:
            //    result = new ReachIn(_obj);
            //    return true;
            default:
                result = null;
                return false;
        }
    }

    public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object? result)
    {
        var member = GetMemberOrThrow(_type, binder.Name);
        switch (member.MemberType)
        {
            case MemberTypes.Method:
                result = ((MethodInfo)member).Invoke(_obj, args);
                return true;
        }
        result = null;
        return false;
    }

    public override bool TrySetMember(SetMemberBinder binder, object value)
    {
        var member = GetMemberOrThrow(_type, binder.Name);

        switch (member.MemberType)
        {
            case MemberTypes.Field:
                ((FieldInfo)member).SetValue(_obj, value);
                return true;
            case MemberTypes.Property:
                ((PropertyInfo)member).SetValue(_obj, value, null);
                return true;
            default:
                return false;
        }
    }

    private static MemberInfo GetMemberOrThrow(Type  type, string name)
    {
        var members = type.GetMember(name,
            BindingFlags.Instance | BindingFlags.Static |
            BindingFlags.NonPublic | BindingFlags.Public 
            );

        //  We got no member at all by that name.
        //  Future: We could consider going to the parent to find if there is a member by that name.
        if (members == null || members.Count() == 0)
        {
            throw new Exception($"ReachIn:binder.Name=[{name}] for type=[{type.Name}] does not exist.");
        }

        //  There are 2 or more member by that name.
        //  Presently we cannot differentiate between them so instead we throw an exception.
        if( members.Count() >= 2)
        {
            throw new Exception($"ReachIn:binder.Name=[{name}] for type=[{type.Name}] gets {members.Count()} matches by its name. Only one match is supported.");
        }

        //  All good. Return the MemberInfo.
        return members.Single();
    }
}