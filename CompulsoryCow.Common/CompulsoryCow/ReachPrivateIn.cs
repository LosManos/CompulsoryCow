using System;
using System.Dynamic;

namespace CompulsoryCow
{
    /// <summary>This class should not be used. Use <see cref="ReachIn"/> instead.
    /// </summary>
    [Obsolete("Use ReachIn instead.", false)]
    public class ReachPrivateIn : DynamicObject
    {
        private readonly Type _type;

        public ReachPrivateIn(Type sut)
        {
            _type = sut;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var property = Meta.GetPrivateStaticProperty(_type, binder.Name);

            if (property != null)
            {
                result = property.GetValue(_type, null);
                return true;
            }

            var field = Meta.GetPrivateStaticField(_type, binder.Name);
            if (field != null)
            {
                result = field.GetValue(_type);
                return true;
            }

            throw new ArgumentException($"The property or field [{binder.Name}] does not exist to get a value from.");
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            var method = Meta.GetPrivateStaticMethod(_type, binder.Name);
            if (method != null)
            {
                result = method.Invoke(_type, args);
                return true;
            }

            // It would be a nice error message if we enumrated the parameters in the error message, 
            // maybe also together with members we found..
            throw new ArgumentException($"The method [{binder.Name}] does not exist to call with said parameters.");
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            var property = Meta.GetPrivateStaticProperty(_type, binder.Name);
            if (property != null)
            {
                property.SetValue(_type, value, null);
                return true;
            }

            var field = Meta.GetPrivateStaticField(_type, binder.Name);

            if (field != null)
            {
                field.SetValue(_type, value);
                return true;
            }

            throw new ArgumentException($"The property or field [{binder.Name}] does not exist to set a value to.");
        }
    }

    /// <summary>This class should not be used. Use <see cref="ReachIn"/> instead.
    /// </summary>
    [Obsolete("Use ReachIn instead.", error: false)]
    public class ReachPrivateIn<T> : DynamicObject
    {
        private T sut;

        public ReachPrivateIn(T sut)
        {
            this.sut = sut;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var property = 
                Meta.GetPrivateProperty(sut, binder.Name) ??
                Meta.GetPrivateStaticProperty(sut.GetType(), binder.Name);
            if (property != null)
            {
                result = property.GetValue(sut,null);
                return true;
            }

            var field = Meta.GetPrivateField(sut, binder.Name);
            if (field != null)
            {
                result = field.GetValue(sut);
                return true;
            }

            throw new ArgumentException($"The property or field [{binder.Name}] does not exist to get a value from.");
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            var method = Meta.GetPrivateMethod(sut, binder.Name);
            if (method != null)
            {
                result = method.Invoke(sut, args);
                return true;
            }

            // It would be a nice error message if we enumrated the parameters in the error message, 
            // maybe also together with members we found..
            throw new ArgumentException($"The method [{binder.Name}] does not exist to call with said parameters.");
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            var property = 
                Meta.GetPrivateProperty(sut, binder.Name) ??
                Meta.GetPrivateStaticProperty(sut.GetType(), binder.Name);
            if (property != null)
            {
                property.SetValue(sut, value,null);
                return true;
            }

            var field = Meta.GetPrivateField(sut, binder.Name);

            if (field != null)
            {
                field.SetValue(sut, value);
                return true;
            }

            throw new ArgumentException($"The property or field [{binder.Name}] does not exist to set a value to.");
        }
   }
}
