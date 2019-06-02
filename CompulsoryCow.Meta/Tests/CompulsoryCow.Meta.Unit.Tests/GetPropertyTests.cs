using System.Reflection;
using System;
using CompulsoryCow;
using FluentAssertions;
using Xunit;

namespace MetaTest
{
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

        /// <summary>If this test fails it might be due to it being tested in release mode.
        /// The GetCallingMethod method does not work properly then.
        /// we should consider making the method obsolete.
        /// </summary>
		[Fact]
		public void GetProperty_given_InternalProperty_should_ReturnCaller()
		{
			//	#	Arrange.
			var myClass = new MyClass(Meta.GetCallingMethod);

			//	#	Act.
			var tmp = myClass.MyInternalProperty;

			//	#	Assert.
			myClass.MyMemberInfo.Name.Should().Be("MyInternalProperty");
		}

        /// <summary>If this test fails it might be due to it being tested in release mode.
        /// The GetCallingMethod method does not work properly then.
        /// we should consider making the method obsolete.
        /// </summary>
		[Fact]
		public void GetProperty_given_ProtectedProperty_should_ReturnCaller()
		{
			//	#	Arrange.
			var myClass = new MyClass(Meta.GetCallingMethod);

			//	#	Act.
			myClass.CallMyProtectedProperty(); ;

			//	#	Assert.
			myClass.MyMemberInfo.Name.Should().Be("MyProtectedProperty");
		}

        /// <summary>If this test fails it might be due to it being tested in release mode.
        /// The GetCallingMethod method does not work properly then.
        /// we should consider making the method obsolete.
        /// </summary>
		[Fact]
		public void GetProperty_given_PublicProperty_should_ReturnCaller()
		{
			//	#	Arrange.
			var myClass = new MyClass(Meta.GetCallingMethod);

			//	#	Act.
			var tmp = myClass.MyPublicProperty;

			//	#	Assert.
			myClass.MyMemberInfo.Name.Should().Be("MyPublicProperty");
		}

        /// <summary>If this test fails it might be due to it being tested in release mode.
        /// The GetCallingMethod method does not work properly then.
        /// we should consider making the method obsolete.
        /// </summary>
		[Fact]
		public void GetProperty_given_PrivateProperty_should_ReturnCaller()
		{
			//	#	Arrange.
			var myClass = new MyClass(Meta.GetCallingMethod);

			//	#	Act.
			myClass.CallMyPrivateProperty();

			//	#	Assert.
			myClass.MyMemberInfo.Name.Should().Be("MyPrivateProperty");
		}

	}
}
