using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System;
using CompulsoryCow;

namespace ReflectionUtilitiesTests
{
	[TestClass]
	public class GetPropertyTests
	{
		private class MyBaseClass
		{
			internal protected MemberInfo MyMemberInfo{protected set; get;}

			protected string MyProtectedProperty
			{
				get
				{
					MyMemberInfo = this.GetProperty();
					return null;
				}
			}
		}
		private class MyClass : MyBaseClass
		{

			internal Func<MemberInfo> Sut { set; private get; }

			internal string MyInternalProperty
			{
				get
				{
					MyMemberInfo = this.GetProperty();
					return null;
				}
			}

			private string MyPrivateProperty
			{
				get
				{
					MyMemberInfo = this.GetProperty();
					return null;
				}
			}

			public string MyPublicProperty
			{
				get
				{
					MyMemberInfo = this.GetProperty();
					return null;
				}
			}

			internal void CallMyPrivateProperty()
			{
				var temp = MyPrivateProperty;
			}

			internal void CallMyProtectedProperty()
			{
				var temp = MyProtectedProperty;
			}

			/// <summary>Constructor for injecting the method we test.
			/// </summary>
			/// <param name="sut"></param>
			public MyClass(Func<MemberInfo> sut)
			{
				Sut = sut;
			}

		}

		[TestMethod]
		public void GetProperty_given_InternalProperty_should_ReturnCaller()
		{
			//	#	Arrange.
			var myClass = new MyClass(Meta.GetCallingMethod);

			//	#	Act.
			var tmp = myClass.MyInternalProperty;

			//	#	Assert.
			Assert.AreEqual("MyInternalProperty", myClass.MyMemberInfo.Name);
		}

		[TestMethod]
		public void GetProperty_given_ProtectedProperty_should_ReturnCaller()
		{
			//	#	Arrange.
			var myClass = new MyClass(Meta.GetCallingMethod);

			//	#	Act.
			myClass.CallMyProtectedProperty(); ;

			//	#	Assert.
			Assert.AreEqual("MyProtectedProperty", myClass.MyMemberInfo.Name);
		}

		[TestMethod]
		public void GetProperty_given_PublicProperty_should_ReturnCaller()
		{
			//	#	Arrange.
			var myClass = new MyClass(Meta.GetCallingMethod);

			//	#	Act.
			var tmp = myClass.MyPublicProperty;

			//	#	Assert.
			Assert.AreEqual("MyPublicProperty", myClass.MyMemberInfo.Name);
		}

		[TestMethod]
		public void GetProperty_given_PrivateProperty_should_ReturnCaller()
		{
			//	#	Arrange.
			var myClass = new MyClass(Meta.GetCallingMethod);

			//	#	Act.
			myClass.CallMyPrivateProperty();

			//	#	Assert.
			Assert.AreEqual("MyPrivateProperty", myClass.MyMemberInfo.Name);
		}

	}
}
