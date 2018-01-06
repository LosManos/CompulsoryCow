using System;
using System.Dynamic;

namespace CompulsoryCow
{
    public class ReachPrivateIn<T> : DynamicObject
    {
        private T sut;

        public ReachPrivateIn(T sut)
        {
            this.sut = sut;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var property = Meta.GetPrivateProperty(sut, binder.Name);

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

            // TODO:Enumerate parameter types.
            throw new ArgumentException($"The methohd [{binder.Name}] does not exist to call with said parameters.");
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            var property = Meta.GetPrivateProperty(sut, binder.Name);
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
