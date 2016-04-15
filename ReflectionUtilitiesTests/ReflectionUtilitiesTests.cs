using Microsoft.VisualStudio.TestTools.UnitTesting;
using CompulsoryCow;
using System.Reflection;
using System;

namespace ReflectionUtilitiesTests
{
	[TestClass]
	public class ReflectionUtilitiesTests
	{
		private class MyClass
		{
			internal MethodBase MyMethodBase{private set; get;}

			internal Func<MethodBase> Sut { set; private get; }

			/// <summary>Constructor for injecting the method we test.
			/// </summary>
			/// <param name="sut"></param>
			public MyClass(Func<MethodBase> sut)
			{
				Sut = sut;
			}

			internal void A()
			{
				B();
			}

			private void B()
			{
				MyMethodBase = Sut();	//	Doing the call.
			}
		}

		[TestMethod]
		public void GetCallingMethod_given_ProperData_should_ReturnCaller()
		{
			//	#	Arrange.
			var myClass = new MyClass(ReflectionUtilities.GetCallingMethod);

			//	#	Act.
			myClass.A();

			//	#	Assert.
			Assert.AreEqual("A", myClass.MyMethodBase.Name);
		}
	}
}
