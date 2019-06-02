using System.Reflection;
using System;
using CompulsoryCow;
using Xunit;
using FluentAssertions;

namespace MetaTest
{
	public class GetCallingMethodsTests
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

        /// <summary>If this test fails it might be due to it being tested in release mode.
        //l/ The MyMethodBase.Name property does not work peorperly then.
        /// we should consider making the method obsolete.
        /// </summary>
		[Fact]
		public void GetCallingMethod_given_ProperData_should_ReturnCaller()
		{
			//	#	Arrange.
			var myClass = new MyClass(Meta.GetCallingMethod);

			//	#	Act.
			myClass.A();

			//	#	Assert.
			myClass.MyMethodBase.Name.Should().Be("A");
		}
	}
}
