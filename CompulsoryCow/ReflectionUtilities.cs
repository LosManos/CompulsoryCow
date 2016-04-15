using System.Reflection;

namespace CompulsoryCow
{
	public static class ReflectionUtilities
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
	}
}
