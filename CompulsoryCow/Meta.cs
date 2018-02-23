using System;
using System.Reflection;

namespace CompulsoryCow
{
    public static class Meta
	{
		/// <summary>This method returns information about the calling method.
		/// It walks the stack wich might be expensive.
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
		public static MethodBase GetCallingMethod()
		{
			return new System.Diagnostics.StackTrace().GetFrame(2).GetMethod();
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
			var callingMethod = GetCallingMethod();

			//	Remove the "get_"-prefix
			var propertyName = callingMethod.Name.StartsWith(Prefix) ?
				callingMethod.Name.Substring(Prefix.Length) :
				callingMethod.Name;

			var property = callingMethod.DeclaringType.GetProperty(
				propertyName,
				BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance );

			return property;
		}

        /// <summary>This method returns <see cref="FieldInfo"/> for the private field in the parameter.
        /// </summary>
        /// <param name="theObject"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static FieldInfo GetPrivateField<T>(T theObject, string name)
        {
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
            return theObject.GetType().GetProperty(
                name,
                BindingFlags.NonPublic | BindingFlags.Instance );

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

    }
}
