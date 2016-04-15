using CompulsoryCow.StringExtensions;
using System.Linq;
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
		///		var callingMethod = CompulsoryCow.ReflectionUtilities.GetCallingMethod();
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
	}
}
